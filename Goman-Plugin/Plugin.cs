using System;
using System.Collections.Generic;
using System.Net;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Modules;
using Goman_Plugin.Modules.AccountFeeder;
using Goman_Plugin.Modules.Authentication;
using Goman_Plugin.Modules.Captcha;
using Goman_Plugin.Modules.PokemonFeeder;
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
        private const string AppId = "Goman_Plugin";
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
            PokemonFeederModule.ModuleEvent += OnModuleEvent;
            AccountFeederModule.ModuleEvent += OnModuleEvent;
            CaptchaModule.ModuleEvent += OnModuleEvent;
            var enableResults = await AuthenticationModule.Enable();

            await base.Load(managers);
            return enableResults.Success;
        }
        private static async Task Update()
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
        private void OnModuleEvent(object o, ModuleEvent moduleEvent)
        {
            if (!GlobalSettings.Extra.ToastNotifications) return;
            // Using the ToastText02 toast template.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;

            // Retrieve the content part of the toast so we can change the text.
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            //Find the text component of the content
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(o.GetType().Name));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(moduleEvent.ToString()));

            // Create the actual toast object using this toast specification.
            ToastNotification toast = new ToastNotification(toastXml);

            // Set SuppressPopup = true on the toast in order to send it directly to action center without 
            // producing a popup on the user's phone.
            toast.SuppressPopup = false;

            // Send the toast.
            ToastNotificationManager.CreateToastNotifier(AppId).Show(toast);
        }
        private async void AuthenticationModuleEvent(object o, ModuleEvent moduleEvent)
        {
            if (moduleEvent == ModuleEvent.Enabled)
            {
                await PokemonFeederModule.Enable();
                await AccountFeederModule.Enable();
                await CaptchaModule.Enable();

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
            }
        }
        public override void AddManager(IManager manager)
        {
            var wrappedManager = new Manager(manager);
            Accounts.Add(wrappedManager);
            OnManagerAdded(this, wrappedManager);
            base.AddManager(manager);
        }
        private static void OnManagerAdded(object arg1, Manager arg2)
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
        private static void OnManagerRemoved(object arg1, Manager arg2)
        {
            ManagerRemoved?.Invoke(arg1, arg2);
        }
    }
}