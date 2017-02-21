using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Module.Captcha;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;
using GoPlugin.Extensions;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.Captcha
{
    public class CaptchaModule : AbstractModule
    {
        public CaptchaModule()
        {
            Settings = new BaseSettings<CaptchaSettings> { Enabled = true };
        }
        public new BaseSettings<CaptchaSettings> Settings { get; }
        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
           await LoadSettings();
            if (string.IsNullOrEmpty(Settings.Extra.CaptchaKey))
                Settings.Extra.CaptchaKey = Prompt.ShowDialog("Enter your 2Captcha API key", "2Captcha");
            if (Settings.Enabled)
            {
                if (forceSubscribe)
                {
                    foreach (var account in Plugin.Accounts)
                    {
                        PluginOnManagerAdded(this, account);
                    }
                }
                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }
            return new MethodResult { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
            await Settings.Save(ModuleName);

            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }

            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
        }
        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new CaptchaSettings();
                await SaveSettings();
            }

            loadSettingsResult.MethodName = "LoadSettings";
            OnLogEvent(this, GetLog(loadSettingsResult));
            return loadSettingsResult;
        }
        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            saveSettingsResult.MethodName = "SaveSettings";
            OnLogEvent(this, GetLog(saveSettingsResult));
            return saveSettingsResult;
        }
        private void PluginOnManagerAdded(object o, Manager manager)
        {
           // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Subscribing to account {manager.Bot.AccountName}"));
            manager.OnCaptchaEvent += OnCaptcha;
        }
        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            //OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.OnCaptchaEvent -= OnCaptcha;
        }
        public async Task StoppedSolveCaptcha(Manager manager)
        {
            if (manager.SolvingCaptcha) return;
            manager.SolvingCaptcha = true;
            await manager.Bot.Login();
            manager.SolvingCaptcha = false;

        }
        private async void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            var managerWrapper = (Manager)sender;
            var manager = managerWrapper.Bot;
            if (manager == null) return;

            if (!Plugin.CaptchaModule.Settings.Enabled)
            {
                OnLogEvent(this, new LogModel(LoggerTypes.Warning, "Captcha Module is disabled, stopping account"), manager);
                manager.Stop();
                return;
            }

            if (manager.AccountState == AccountState.CaptchaRequired && manager.State == BotState.Stopped && !manager.LoggedIn)
            {
                await StoppedSolveCaptcha(managerWrapper);
                return;
            }

            if(Plugin.CaptchaModule.Settings.Extra == null) return;

            if (managerWrapper.SolvingCaptcha || !manager.CaptchaRequired && !string.IsNullOrEmpty(manager.CaptchaURL)) return;
            OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Solving captcha at URL: {manager.CaptchaURL}"), manager);

            managerWrapper.SolvingCaptcha = true;
            var results = await CaptchaHandler.Handle(managerWrapper);

            OnLogEvent(this, GetLog(results), manager);
            if (!results.Success) manager.Stop();
            managerWrapper.SolvingCaptcha = false;
        }
    }
}