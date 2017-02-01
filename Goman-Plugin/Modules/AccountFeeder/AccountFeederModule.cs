using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Helpers;
using Goman_Plugin.Module;
using Goman_Plugin.Wrapper;
using Newtonsoft.Json;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.AccountFeeder
{
    public class AccountFeederModule : AbstractModule
    {
        private readonly Timer _accountTimer;
        public HashSet<AccountInformation> AccountDataInformation = new HashSet<AccountInformation>();
        public new BaseSettings<AccountFeederSettings> Settings { get; }
        public AccountFeederModule()
        {
            Settings = new BaseSettings<AccountFeederSettings>() { Enabled = true };
            _accountTimer = new Timer();
            _accountTimer.Elapsed += _accountTimer_Elapsed;
        }
        public async Task<MethodResult> Execute()
        {
            List<AccountInformation> copiedList;
            lock (AccountDataInformation)
            {
                copiedList = new List<AccountInformation>(AccountDataInformation);
                AccountDataInformation.Clear();
            }

            var jsonString = JsonConvert.SerializeObject(copiedList);
            var result = await GomanHttpHelper.AccountFeeder.SendAccounts(new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (!result.Success)
                lock (AccountDataInformation)
                    copiedList.ForEach(x => AccountDataInformation.Add(x));

            return result;
        }
        public override async Task<MethodResult> Enable()
        {
            var loadSettingsResult = await LoadSettings();

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AccountFeederSettings();
                await SaveSettings();
            }

            if (Settings.Enabled)
            {
                _accountTimer.Interval = Settings.Extra.IntervalMilliseconds;

                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;

                _accountTimer.Elapsed += _accountTimer_Elapsed;
                _accountTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult() { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable()
        {
            if (!_accountTimer.Enabled) return new MethodResult { Success = true };
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            _accountTimer.Elapsed -= _accountTimer_Elapsed;
            _accountTimer.Enabled = false;

            await Settings.Save(ModuleName);
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult() { Success = true };
        }
        private void PluginOnManagerAdded(object o, Manager manager)
        {
            manager.ManagerChanged += OnManagerChange;
        }
        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            manager.ManagerChanged -= OnManagerChange;
        }
        public async Task<MethodResult> LoadSettings()
        {
            return await Settings.Load(ModuleName);
        }
        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            return saveSettingsResult;
        }
        private void OnManagerChange(object sender, EventArgs e)
        {
            var manager = (Manager)sender;

            lock (AccountDataInformation)
            {
                AccountDataInformation.Add(new AccountInformation(manager));
            }
        }
        private async void _accountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (AccountDataInformation.Count == 0) return;
            await Execute();
        }
    }
}
