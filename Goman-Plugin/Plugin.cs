using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Module;
using Goman_Plugin.Modules;
using Goman_Plugin.Modules.AccountFeeder;
using Goman_Plugin.Modules.Authentication;
using Goman_Plugin.Modules.PokemonFeeder;
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

        static Plugin()
        {
            Accounts = new HashSet<Manager>();
        }

        public override string PluginName { get; set; } = "New Plugin";
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }
        public static event Action<object, Manager> ManagerAdded;
        public static event Action<object, Manager> ManagerRemoved;

        public override Task Run(IEnumerable<IManager> managers)
        {
            throw new NotImplementedException();
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
            var enableResults = await _authenticationModule.Enable();

            await base.Load(managers);
            return enableResults.Success;
        }

        private void OnModuleEvent(object o, ModuleEvent moduleEvent)
        {
            MessageBox.Show(o.GetType().Name + ": " + moduleEvent);
        }

        private async void AuthenticationModuleEvent(object o, ModuleEvent moduleEvent)
        {
            if (moduleEvent == ModuleEvent.Enabled)
            {
                await _pokemonFeederModule.Enable();
                await _accountFeederModule.Enable();

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