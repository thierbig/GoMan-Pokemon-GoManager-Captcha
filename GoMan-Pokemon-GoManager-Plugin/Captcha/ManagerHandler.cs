using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GoMan.Model;
using GoPlugin;
using GoPlugin.Events;

namespace GoManCaptcha.Captcha
{
    public class ManagerHandler
    {
        public IManager Manager { get; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        private bool SolvingCaptcha { get; set; }
        public string Log { get; set; } = "";

        private static int _totalSuccessCount = 0;
        private static int _totalFailedCount = 0;

        public static int TotalSuccessCount => _totalSuccessCount;
        public static int TotalFailedCount => _totalFailedCount;

        public delegate void SolvedCaptcha(object sender, EventArgs e);
        public static event SolvedCaptcha SolvedCaptchaEvent;

        public List<LogModel> EventLog = new List<LogModel>();

        public ManagerHandler(IManager manager)
        {
            Manager = manager;
            manager.OnCaptcha += OnCaptcha;
        }
        public async void StoppedSolveCaptcha()
        {
            if (SolvingCaptcha || !ApplicationModel.Settings.Enabled) return;

            await Task.Run(delegate
            {
                Manager.Login();
                Manager.LoginWait();
            });
        }

        private async void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            if (SolvingCaptcha || !Manager.CaptchaRequired && !string.IsNullOrEmpty(Manager.CaptchaURL)) return;

            if (!ApplicationModel.Settings.Enabled)
            {
                Manager.Stop();
                return;
            }

            SolvingCaptcha = true;

            var results = await CaptchaHandler.Handle(this);

             UpdateCounters(results.Success);
            if (!results.Success) Manager.Stop();

            SolvingCaptcha = false;
        }

        public void UpdateCounters(bool success)
        {
            if (success)
            {
                Interlocked.Increment(ref _totalSuccessCount);
                SuccessCount += 1;
            }
            else
            {
                Interlocked.Increment(ref _totalFailedCount);
                FailedCount += 1;
            }

            SolvedCaptchaEvent?.Invoke(this, EventArgs.Empty);
        }
        public void AddLog(LoggerTypes type, string message, Exception ex = null)
        {
            LogModel newLog = new LogModel(type, message, ex);
            EventLog.Add(newLog);
            this.Log = newLog.ToString();
            Manager.LogCallerPlugin(new LoggerEventArgs(newLog));

            if (ApplicationModel.Settings.SaveLogs)
                LogMessageToFile($"./Plugins/GoManLogs/{Manager.AccountName}_log.txt", message);
        }

        private static void LogMessageToFile(string path, string msg)
        {
            if (!Directory.Exists("./Plugins/GoManLogs")) Directory.CreateDirectory("./Plugins/GoManLogs");

            try
            {
                using (var sw = File.AppendText(path))
                    sw.WriteLine($"{DateTime.Now:G}: {msg}.");
            }
            catch (Exception)
            {
                //ignore
            }
        }

        public override bool Equals(object obj)
        {
            ManagerHandler managerHandler = (ManagerHandler) obj;

            return Manager.Equals(managerHandler?.Manager);
        }

        public override int GetHashCode()
        {
            return Manager.GetHashCode();
        }
    }
}
