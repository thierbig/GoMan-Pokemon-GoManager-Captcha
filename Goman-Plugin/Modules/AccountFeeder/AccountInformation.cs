using System.Linq;
using Goman_Plugin.Wrapper;
using GoPlugin;
using Newtonsoft.Json;

namespace Goman_Plugin.Modules.AccountFeeder
{
    public class AccountInformation
    {
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
        public string LastLog { get; set; }

        public AccountInformation(Manager wrappedManager)
        {
            IManager manager = wrappedManager.Bot;

            Name = manager.AccountName;
            AccountState = ((int)manager.AccountState).ToString();
            Level = wrappedManager.Level.ToString();
            BotState = ((int)manager.State).ToString();
            ExpPerHour = wrappedManager.ExpPerHour.ToString();
            TillLevelUp = wrappedManager.TillLevelUp;
            RunningTime = wrappedManager.RunTime;
            LastLog = wrappedManager.LastLog;

            var logs = wrappedManager.Logs;
            if (logs == null || logs.Count == 0) return;

            var log = logs.Last();
            LogType = ((int)log.LoggerType).ToString();
        }
    }
}
