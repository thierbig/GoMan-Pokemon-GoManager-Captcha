using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Helpers;
using Goman_Plugin.Model;
using Goman_Plugin.Module;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.Authentication
{
    public class AuthenticationModule : AbstractModule
    {
        public new BaseSettings<AuthenticationSettings> Settings { get; }
        private static Timer _pingTimer;
        public AuthenticationModule()
        {
            Settings = new BaseSettings<AuthenticationSettings>() { Enabled = true};
            _pingTimer = new Timer(1000);
            _pingTimer.Elapsed += _pingTimer_Elapsed;
        }
        private async void _pingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var pingMethodResult = await GomanHttpHelper.Authentication.Ping();
            pingMethodResult.MethodName = "AuthenticationModule._pingTimer_Elapsed";
            OnLogEvent(this,GetLog(pingMethodResult));
        }
        public override async Task<MethodResult> Enable()
        {
            var loadSettingsResult = await LoadSettings();
            if(!Settings.Enabled) return new MethodResult() {Success = true};
            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AuthenticationSettings();
                await SaveSettings();
            }

            var loginMethodResult = Login();

            if (loginMethodResult.Success)
            {
                _pingTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }
            loginMethodResult.MethodName = "AuthenticationModule.Enable";
            OnLogEvent(this, GetLog(loginMethodResult));
            return loginMethodResult;
        }

        public override async Task<MethodResult> Disable()
        {
            var methodResults = new MethodResult() { Success = true, MethodName = "AuthenticationModule.Disable" };
            _pingTimer.Elapsed -= _pingTimer_Elapsed;
            _pingTimer.Enabled = false;
            await Logout();
            await SaveSettings();
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            OnLogEvent(this, GetLog(methodResults));
            return methodResults;
        }
        private async Task<MethodResult> Logout()
        {
            var methodResult = new MethodResult() { MethodName = "AuthenticationModule.Logout" }; ;

            if (Settings.Extra.NonStaticLoggedIn)
            {
                var logoutMethodResult = await GomanHttpHelper.Authentication.Logout();
                methodResult.Success = logoutMethodResult.Success;
            }
            OnLogEvent(this, GetLog(methodResult));
            return methodResult;
        }
        private MethodResult Login()
        {
            var methodResult = new MethodResult() { MethodName = "AuthenticationModule.Login" }; ;
            var loginForm = new AuthenticationUi();
            if (loginForm.ShowDialog() == DialogResult.OK)
                methodResult.Success = true;

            OnLogEvent(this, GetLog(methodResult));
            return methodResult;
        }
        public  async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);
            OnLogEvent(this, GetLog(loadSettingsResult));
            return loadSettingsResult;
        }
        public  async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            OnLogEvent(this, GetLog(saveSettingsResult));
            return saveSettingsResult;
        }
    }
}
