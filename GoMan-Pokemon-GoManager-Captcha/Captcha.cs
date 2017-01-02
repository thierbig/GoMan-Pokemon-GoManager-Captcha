using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;
using Microsoft.VisualBasic;

namespace GoManCaptcha
{
    internal class Captcha : IPlugin
    {
        public static ApplicationModel Settings = ApplicationModel.Settings();
        public static ArrayList AccountsBeingChecked = new ArrayList();
        private static readonly Func<string, string, IManager, Task<MethodResult>> SolveCaptchaAction =
            async (captchaKey, captchaUrl, manager) => await SolveCaptcha(captchaKey, captchaUrl, manager);

        public override string PluginName { get; set; } = "GoMan Auto Captcha";
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }

        public override void AddManager(IManager manager)
        {
            manager.OnCaptcha += CaptchaHandler;
            base.AddManager(manager);
        }

        public override void RemoveManager(IManager manager)
        {
            manager.OnCaptcha -= CaptchaHandler;
            base.RemoveManager(manager);
        }

        public override async Task<bool> Load(IEnumerable<IManager> managers)
        {
            if (!Directory.Exists("./Plugins/GoManLogs")) Directory.CreateDirectory("./Plugins/GoManLogs");

            if (string.IsNullOrEmpty(Settings.CaptchaKey))
            {
                var captchaApiKey =
                    Interaction.InputBox(
                        "Enter your 2Captcha API key and make sure you leave 'Stop on Captcha' unchecked before starting bots.",
                        "Enter 2Captcha.com API Key",
                        "2Captcha.com API Key", -1, -1);

                Settings.CaptchaKey = captchaApiKey;
                await Settings.SaveSetting();
            }

            //Occurs when the plugin is loaded.
            foreach (var manager in managers)
            {
                manager.OnCaptcha += CaptchaHandler;
            }

            return true;
        }

        public async void CaptchaHandler(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            var manager = sender as IManager;
            if (manager == null) return;

            if (!Settings.Enabled)
            {
                manager.Stop();
                return;
            }

            if (!manager.CaptchaRequired || AccountsBeingChecked.Contains(manager)) return;
            AccountsBeingChecked.Add(manager);

            var logPath = $"./Plugins/GoManLogs/{manager.AccountName}_log.txt";
            LogMessageToFile(logPath, $"Solving captcha at URL: {manager.CaptchaURL}");

            while (manager.State != BotState.Paused)
                await Task.Delay(250);

            var solveCaptchaRetryActionResults = await RetryAction(
                SolveCaptchaAction,
                Settings.CaptchaKey,
                manager.CaptchaURL,
                manager,
                Settings.SolveAttemptsBeforeStop);

            LogMessageToFile(logPath, solveCaptchaRetryActionResults.Message);
            AccountsBeingChecked.Remove(manager);

            if (!solveCaptchaRetryActionResults.Success) manager.Stop();

        }

        public static async Task<MethodResult> SolveCaptcha(string captchaKey, string captchaUrl, IManager manager)
        {
            var captchaResponse = await HttpStuff.GetCaptchaResponse(captchaKey, captchaUrl);
            if (!captchaResponse.Success) return captchaResponse;

            return await manager.VerifyCaptcha(captchaResponse.Data);
        }

        private static async Task<MethodResult> RetryAction(Func<string, string, IManager, Task<MethodResult>> action,
            string captchaKey, string captchaUrl, IManager manager, int tryCount)
        {
            var tries = 1;
            var methodResult = new MethodResult();

            while (tries < tryCount)
            {
                methodResult = await action(captchaKey, captchaUrl, manager);

                if (!methodResult.Success)
                    tries++;

                if (methodResult.Success) break;
                await Task.Delay(1000);
            }
            return methodResult;
        }

        public override async Task Run(IEnumerable<IManager> managers)
        {
            Settings.Enabled = !Settings.Enabled;
            await Settings.SaveSetting();

            MessageBox.Show(
                "Autosolve Captcha enabled: " + Settings.Enabled +
                "\n\n Make sure you leave 'Stop on Captcha' unchecked before starting bots.",
                PluginName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LogMessageToFile(string path, string msg)
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

        public override async Task<bool> Save()
        {
            return await Settings.SaveSetting();
        }
    }
}