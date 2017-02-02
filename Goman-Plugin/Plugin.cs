using System;
using System.Collections.Generic;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Threading.Tasks;
using Goman_Plugin.Modules;
using Goman_Plugin.Modules.AccountFeeder;
using Goman_Plugin.Modules.Authentication;
using Goman_Plugin.Modules.Captcha;
using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.View;
using Goman_Plugin.Wrapper;
using GoPlugin;

namespace Goman_Plugin
{
    public class Plugin : IPlugin
    {
        public static readonly HashSet<Manager> Accounts;
        private readonly AccountFeederModule _accountFeederModule = new AccountFeederModule();
        private readonly AuthenticationModule _authenticationModule = new AuthenticationModule();
        private readonly PokemonFeederModule _pokemonFeederModule = new PokemonFeederModule();
        private readonly CaptchaModule _captchaModule = new CaptchaModule();

        private const String AppId = "Goman_Plugin";
        static Plugin()
        {
            Accounts = new HashSet<Manager>();
        }
        public override string PluginName { get; set; } = "New Plugin";
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }
        public static event Action<object, Manager> ManagerAdded;
        public static event Action<object, Manager> ManagerRemoved;
        public override async Task Run(IEnumerable<IManager> managers)
        {
            var captchaSettingsFrom = new MainForm(Accounts, _captchaModule, _pokemonFeederModule, _accountFeederModule);
            captchaSettingsFrom.Show();
            return;
        }
        public override async Task<bool> Save()
        {
            var disableResult = await _authenticationModule.Disable();
            return disableResult.Success;
        }
        public override async Task<bool> Load(IEnumerable<IManager> managers)
        {
            _authenticationModule.ModuleEvent += AuthenticationModuleEvent;
            _pokemonFeederModule.ModuleEvent += OnModuleEvent;
            _accountFeederModule.ModuleEvent += OnModuleEvent;
            _captchaModule.ModuleEvent += OnModuleEvent;
            var enableResults = await _authenticationModule.Enable();

            await base.Load(managers);
            return enableResults.Success;
        }
        private void OnModuleEvent(object o, ModuleEvent moduleEvent)
        {
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
                await _pokemonFeederModule.Enable();
                await _accountFeederModule.Enable();
                await _captchaModule.Enable();
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
                await _pokemonFeederModule.Disable();
                await _accountFeederModule.Disable();
                await _captchaModule.Disable();
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