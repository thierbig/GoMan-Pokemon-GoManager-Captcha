using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Helpers;
using Goman_Plugin.Wrapper;
using GoPlugin.Events;
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
        public event Action<object, LocationUpdateEventArgs> LocationUpdate;
        public AccountFeederModule()
        {
            Settings = new BaseSettings<AccountFeederSettings>() { Enabled = true };
            _accountTimer = new Timer();
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


            result.MethodName = "Execute Uploading";
            OnLogEvent(this, GetLog(result));
            return result;
        }
        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {
                if (forceSubscribe)
                {
                    foreach (var account in Plugin.Accounts)
                    {
                        PluginOnManagerAdded(this, account);
                    }
                }
                _accountTimer.Interval = Settings.Extra.IntervalMilliseconds;
                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;
                _accountTimer.Elapsed += _accountTimer_Elapsed;
                _accountTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult() { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            if (!_accountTimer.Enabled) return new MethodResult { Success = true };
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            _accountTimer.Elapsed -= _accountTimer_Elapsed;
            _accountTimer.Enabled = false;

            await Settings.Save(ModuleName);

            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult() { Success = true };
        }
        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);
          
            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AccountFeederSettings();
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
            manager.ManagerChanged += OnManagerChange;
            manager.Bot.OnLocationUpdate += BotOnOnLocationUpdate;
        }

        private void BotOnOnLocationUpdate(object sender, LocationUpdateEventArgs locationUpdateEventArgs)
        {
            OnLocationUpdate(sender, locationUpdateEventArgs);
        }
        protected virtual void OnLocationUpdate(object arg1, LocationUpdateEventArgs arg2)
        {
            LocationUpdate?.Invoke(arg1, arg2);
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            //OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.ManagerChanged -= OnManagerChange;
            manager.Bot.OnLocationUpdate -= BotOnOnLocationUpdate;
        }
        private void OnManagerChange(object sender, EventArgs e)
        {
            var manager = (Manager)sender;
            var accountInformation = new AccountInformation(manager);

            lock (AccountDataInformation)
            {
                if (AccountDataInformation.Contains(accountInformation))
                    AccountDataInformation.Remove(accountInformation);

                AccountDataInformation.Add(accountInformation);
            }
        }
        private async void _accountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (AccountDataInformation.Count == 0) return;
            var results = await Execute();
        }
    }
}
