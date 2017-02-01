                                                                                                    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BrightIdeasSoftware;
                                                                                                    using GoMan.Helpers;
                                                                                                    using GoMan.Model;
using GoMan.View;
using GoPlugin;
using GoPlugin.Enums;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;


namespace GoMan.Captcha
{
    internal class Captcha : IPlugin
    {
        public override string PluginName { get; set; } = "GoMan Plugin";
        public static readonly Dictionary<IManager, ManagerHandler> Accounts = new Dictionary<IManager, ManagerHandler>();
        private static Timer _timer; // From System.Timers
        private static Timer _pingTimer; // From System.Timers
        private static Timer _accountTimer; // From System.Timers
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }

        public override void AddManager(IManager manager)
        {
            Accounts.Add(manager, new ManagerHandler(manager));
            base.AddManager(manager);
        }

        public override void RemoveManager(IManager manager)
        {
            Accounts.Remove(manager);
            base.RemoveManager(manager);
        }

        public override async Task<bool> Load(IEnumerable<IManager> managers)
        {
            if (!GomanWebsiteHelper.Login()) return false;

            if (!Directory.Exists("./Plugins/GoManLogs")) Directory.CreateDirectory("./Plugins/GoManLogs");

            if(ApplicationModel.Settings.AutoUpdate)
                await Update();

            _timer = new Timer(1000); 
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;

            _pingTimer = new Timer(60000);
            _pingTimer.Elapsed += _pingTimer_Elapsed;
            _pingTimer.Enabled = true;

            _accountTimer = new Timer(1000);
            _accountTimer.Elapsed += _accountTimer_Elapsed;
            _accountTimer.Enabled = true;

            if (string.IsNullOrEmpty(ApplicationModel.Settings.CaptchaKey))
            {
                using (var captchaSettingsFrom = new MainForm(Accounts))
                {
                    captchaSettingsFrom.ShowDialog();
                }
            }

            //Occurs when the plugin is loaded.
            foreach (var manager in managers)
            {
                Accounts.Add(manager, new ManagerHandler(manager));
            }

            return true;
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
        static  void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!ApplicationModel.Settings.Enabled) return;
            lock (Accounts)
            {
                foreach (var keyValuePair in Accounts)
                {
                    if (keyValuePair.Key.AccountState == AccountState.CaptchaRequired &&
                        keyValuePair.Key.State == BotState.Stopped)
                    {
                        keyValuePair.Value.StoppedSolveCaptcha();
                    }
                }
            }
        }

        private static bool _uploading = false;
        static async void _accountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_uploading || Accounts == null || Accounts.Count == 0) return;
            List<AccountData> listAccountData;
            _uploading = true;
            lock (Accounts)
            {
                listAccountData = Accounts.Select(keyValuePair => new AccountData(keyValuePair.Key)).ToList();
            }

            var jsonString = JsonConvert.SerializeObject(listAccountData);
            var result = await GomanWebsiteHelper.TryUploadAccountInfo(new StringContent(jsonString, Encoding.UTF8, "application/json"));

            _uploading = false;
        }
        private class AccountData
        {
            private static readonly Munger LevelMunger = new Munger("Level");
            private static readonly Munger LogMunger = new Munger("Logs");
            private static readonly Munger LastLogMessageMunger = new Munger("LastLogMessage");
            private static readonly Munger ExpPerHourMunger = new Munger("ExpPerHour");
            private static readonly Munger RunTimeMunger = new Munger("RunningTime");
            private static readonly Munger TillLevelUpMunger = new Munger("TillLevelUp");

            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("account_state")]
            public string AccountState { get; set; }
            [JsonProperty("level")]
            public string Level { get; set; }
            [JsonProperty("bot_state")]
            public string BotState { get; set; }
            [JsonProperty("run_time")]
            public string RunningTime { get; set; }
            [JsonProperty("exp_per_hour")]
            public string ExpPerHour { get; set; }
            [JsonProperty("level_up_time")]
            public string TillLevelUp { get; set; }

            [JsonProperty("log_type")]
            public string LogType { get; set; } = "0";
            [JsonProperty("last_log")]
            public string LastLog { get; set; } = "";

            public AccountData(IManager manager)
            {
                Name = manager.AccountName;
                AccountState = ((int) manager.AccountState).ToString();
                Level = LevelMunger.GetValue(manager).ToString();
                BotState = ((int) manager.State).ToString();
                ExpPerHour = ExpPerHourMunger.GetValue(manager).ToString();
                TillLevelUp = TillLevelUpMunger.GetValue(manager).ToString();
                RunningTime = RunTimeMunger.GetValue(manager).ToString();
                LastLog = LastLogMessageMunger.GetValue(manager).ToString();

                var logs = ((ICollection<Log>) LogMunger.GetValue(manager));
                if (logs == null || logs.Count == 0) return;

                var log = logs.Last();
                LogType = ((int)log.LoggerType).ToString();
            }
        }

        static async void  _pingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await GomanWebsiteHelper.TryPing();
        }

        public override async Task Run(IEnumerable<IManager> managers)
        {
            if (!GomanWebsiteHelper.Login()) return;

            if (Accounts.Count == 0 && (_timer == null || _pingTimer == null))
            {
                _timer = new Timer(1000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Enabled = true;

                _pingTimer = new Timer(60000);
                _pingTimer.Elapsed += _pingTimer_Elapsed;
                _pingTimer.Enabled = true;

                _accountTimer = new Timer(1000);
                _accountTimer.Elapsed += _accountTimer_Elapsed;
                _accountTimer.Enabled = true;

                if (string.IsNullOrEmpty(ApplicationModel.Settings.CaptchaKey))
                {
                    using (var captchaSettingsFrom = new MainForm(Accounts))
                    {
                        captchaSettingsFrom.ShowDialog();
                    }
                }

                //Occurs when the plugin is loaded.
                foreach (var manager in _uniqueManagers)
                {
                    Accounts.Add(manager, new ManagerHandler(manager));
                }
            }
            else
            {
                var captchaSettingsFrom = new MainForm(Accounts);
                captchaSettingsFrom.Show();
            }
        }

        public override async Task<bool> Save()
        {
            await GomanWebsiteHelper.TryLogout();
            return await ApplicationModel.Settings.SaveSetting();
        }
    }
}