using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using GoMan.Model;
using GoPlugin;
using GoPlugin.Events;
using Newtonsoft.Json;

namespace GoMan.Captcha
{
    public class ManagerHandler
    {
        public IManager Manager { get; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        private bool SolvingCaptcha { get; set; }
        public LogModel Log { get; set; }
        private static Timer _timer;

        private static int _totalSuccessCount = 0;
        private static int _totalFailedCount = 0;

        public static int TotalSuccessCount => _totalSuccessCount;
        public static int TotalFailedCount => _totalFailedCount;

        public delegate void SolvedCaptcha(object sender, EventArgs e);
        public static event SolvedCaptcha SolvedCaptchaEvent;
        public static ConcurrentDictionary<string, int> CaptchaRateLog = new ConcurrentDictionary<string, int>();
        private readonly PokemonFeeder _pokemonFeeder = new PokemonFeeder();

        public static double GetCaptchasRate()
        {
            if (CaptchaRateLog.IsEmpty) return 0;

            var data = CaptchaRateLog.ToDictionary(d => DateTime.Parse(d.Key, CultureInfo.InvariantCulture), d => d.Value);

            var result = from kvp in data
                let key = RoundToNearestInterval(kvp.Key, TimeSpan.FromMinutes(ApplicationModel.Settings.CaptchaSamplingTimeMinutes))
                group kvp by key into g
                select new { g.Key, Value = g.Average(x => x.Value) };

            var results = result.ToDictionary(r => r.Key, v => v.Value).OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            return results.Average(g => g.Value);
        }
        private static DateTime RoundToNearestInterval(DateTime dt, TimeSpan d)
        {
            var f = 0;
            var m = (double)(dt.Ticks % d.Ticks) / d.Ticks;
            if (m >= 0.5) f = 1;
            return new DateTime(((dt.Ticks / d.Ticks) + f) * d.Ticks);
        }

        public ManagerHandler(IManager manager)
        {
            if (_timer == null)
            {
                _timer = new Timer(6000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Enabled = true;
            }
            Manager = manager;
            
            manager.OnCaptcha += OnCaptcha;
            manager.OnPokemonCaught += OnPokemonCaught;
        }

        private void OnPokemonCaught(object sender, PokemonCaughtEventArgs e)
        {
            lock (PokemonFeeder.PokemonDataInformation)
            {
                var iv = Manager.CalculateIVPerfection(e.Pokemon).Data;
                PokemonFeeder.PokemonDataInformation.Add(new PokemonLocationInfo(e, iv));
            }
        }

       
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            CaptchaRateLog.AddOrUpdate(time, 0, (k, v) => v + 0);

            if (CaptchaRateLog.Count >= 10080)
            {
                int removedValue;
                CaptchaRateLog.TryRemove(CaptchaRateLog.Keys.ElementAt(0), out removedValue);
            }
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

        private void UpdateCounters(bool success)
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

            var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            CaptchaRateLog.AddOrUpdate(time, 1, (k, v) => v + 1);
            SolvedCaptchaEvent?.Invoke(this, EventArgs.Empty);
        }
        public void AddLog(LoggerTypes type, string message, Exception ex = null)
        {
            LogModel newLog = new LogModel(type, message, ex);
            this.Log = newLog;
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
