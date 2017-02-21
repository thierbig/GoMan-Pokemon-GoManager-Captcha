using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Modules;
using Goman_Plugin.Modules.AccountFeeder;
using Goman_Plugin.Modules.Authentication;
using Goman_Plugin.Modules.Captcha;
using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.Modules.PokemonManager;
using Goman_Plugin.View;
using Goman_Plugin.Wrapper;
using GoPlugin;
using Newtonsoft.Json;

namespace Goman_Plugin
{
    public class Plugin : IPlugin
    {
        public static readonly ConcurrentHashSet<Manager> Accounts;
        internal static readonly BaseSettings<GlobalSettings> GlobalSettings;
        internal static readonly AccountFeederModule AccountFeederModule;
        internal static readonly AuthenticationModule AuthenticationModule;
        internal static readonly PokemonFeederModule PokemonFeederModule;
        internal static readonly CaptchaModule CaptchaModule;
        internal static readonly PokemonManagerModule PokemonManagerModule;
        public override string PluginName { get; set; } = "Goman Plugin";
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }
        public static event Action<object, Manager> ManagerAdded;
        public static event Action<object, Manager> ManagerRemoved;
        static Plugin()
        {
            Accounts = new ConcurrentHashSet<Manager>();
            GlobalSettings = new BaseSettings<GlobalSettings>();

            var globalSettingsLoadResult = GlobalSettings.Load("PluginModule").Result;
            if (!globalSettingsLoadResult.Success)
            {
                GlobalSettings.Extra = new GlobalSettings();
                var globalSettingsSaveResult = GlobalSettings.Save("PluginModule").Result;
            }


            AuthenticationModule = new AuthenticationModule();
            AccountFeederModule = new AccountFeederModule();
            CaptchaModule = new CaptchaModule();
            PokemonFeederModule = new PokemonFeederModule();
            PokemonManagerModule = new PokemonManagerModule();
        }

        public override async Task Run(IEnumerable<IManager> managers)
        {
            var captchaSettingsFrom = new MainForm(Accounts);
            captchaSettingsFrom.Show();
        }
        public override async Task<bool> Save()
        {
            var disableResult = await AuthenticationModule.Disable();
            return disableResult.Success;
        }
        public override async Task<bool> Load(IEnumerable<IManager> managers)
        {
            if (GlobalSettings.Extra.AutoUpdate)
                await Update();

            AuthenticationModule.ModuleEvent += AuthenticationModuleEvent;
            var enableResults = await AuthenticationModule.Enable();

            await base.Load(managers);
            return enableResults.Success;
        }
        private async Task Update()
        {
            using (var wc = new WebClient())
            {
                var result = await wc.DownloadStringTaskAsync(VersionModel.Uri);
                var version = JsonConvert.DeserializeObject<VersionModel>(result);

                if (!version.Version.Equals(VersionModel.CurrentVersion))
                {
                    var updateQuestionResults =
                        MessageBox.Show("GoMan Plugin has been updated! Would you like to download the update?",
                            "GoMan Plugin Updated!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (updateQuestionResults == DialogResult.Yes)
                    {
                        await wc.DownloadFileTaskAsync(version.UpdateUrl, VersionModel.SavePath);
                        MessageBox.Show("GoMan Plugin has been updated! Restart to use updated version!",
                            "GoMan Plugin Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private async void AuthenticationModuleEvent(object o, ModuleEvent moduleEvent)
        {
            if (moduleEvent == ModuleEvent.Enabled)
            {
                await PokemonFeederModule.Enable();
                await AccountFeederModule.Enable();
                await CaptchaModule.Enable();
                await PokemonManagerModule.Enable();

                foreach (var manager in _uniqueManagers)
                {
                    var wrappedManager = new Manager(manager);
                    Accounts.Add(wrappedManager);
                    OnManagerAdded(this, wrappedManager);
                }
            }
            else
            {
                foreach (var manager in _uniqueManagers)
                {
                    var wrappedManager = new Manager(manager);
                    Accounts.Add(wrappedManager);
                    OnManagerRemoved(this, wrappedManager);
                }

                await PokemonFeederModule.Disable();
                await AccountFeederModule.Disable();
                await CaptchaModule.Disable();
                await PokemonManagerModule.Disable();
            }
        }
        public override void AddManager(IManager manager)
        {
            var wrappedManager = new Manager(manager);
            Accounts.Add(wrappedManager);
            OnManagerAdded(this, wrappedManager);
            base.AddManager(manager);
        }
        private void OnManagerAdded(object arg1, Manager arg2)
        {
            ManagerAdded?.Invoke(arg1, arg2);
        }
        public override void RemoveManager(IManager manager)
        {
            var wrappedManager = new Manager(manager);
            Accounts.Remove(wrappedManager);
            OnManagerRemoved(this, wrappedManager);
            base.RemoveManager(manager);
        }
        private void OnManagerRemoved(object arg1, Manager arg2)
        {
            ManagerRemoved?.Invoke(arg1, arg2);
        }
    }
}