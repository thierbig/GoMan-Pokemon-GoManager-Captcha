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
        private readonly PokemonFeeder _pokemonFeeder = new PokemonFeeder();



        public ManagerHandler(IManager manager)
        {
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
