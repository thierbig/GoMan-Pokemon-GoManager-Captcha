using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;

namespace GoManCaptcha
{
    class Captcha : IPlugin
    {
        public override string PluginName { get; set; } = "GoMan Auto Captcha";
        public static ApplicationModel Settings = ApplicationModel.Settings();

        //Subitems when hovering over plugin in menu
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }
        private IEnumerable<IManager> _managers;

        public Captcha()
        {
        }

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

            if (string.IsNullOrEmpty(Settings.CaptchaKey))
            {
                string captchaApiKey = Microsoft.VisualBasic.Interaction.InputBox("Enter your 2Captcha API key and make sure you leave 'Stop on Captcha' unchecked before starting bots.", 
                    "Enter 2Captcha.com API Key",
                    "2Captcha.com API Key", -1, -1);

                Settings.CaptchaKey = captchaApiKey;
                await Settings.SaveSetting();
            }
            _managers = managers;
            //Occurs when the plugin is loaded.
            foreach (var manager in _managers)
            {
                manager.OnCaptcha += CaptchaHandler;
            }
           
            return true;
        }
        private static readonly Func<string, string, IManager, Task<MethodResult>> SolveCaptchaAction = async (captchaKey, captchaUrl, manager) => await SolveCaptcha(captchaKey, captchaUrl, manager);

        public async void CaptchaHandler(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {

            IManager manager = sender as IManager;
            if (manager == null) return;

            if (!Settings.Enabled)
            {
                manager.Stop();
                return;
            }

            if (!manager.CaptchaRequired) return;

            while (manager.State != BotState.Paused)
                await Task.Delay(250);

           var solveCaptchaRetryActionResults = await RetryAction(
               SolveCaptchaAction, 
               Settings.CaptchaKey, 
               manager.CaptchaURL, 
               manager, 
               Settings.SolveAttemptsBeforeStop);

           if (!solveCaptchaRetryActionResults.Success) manager.Stop();
        }

        public static async Task<MethodResult> SolveCaptcha(string captchaKey, string captchaUrl, IManager manager)
        {
           MethodResult<string> captchaResponse = await HttpStuff.GetCaptchaResponse(captchaKey, captchaUrl);
           if (!captchaResponse.Success) return captchaResponse;
           
           return await manager.VerifyCaptcha(captchaResponse.Data);
        }

        private static async Task<MethodResult> RetryAction(Func<string, string, IManager, Task<MethodResult>> action, string captchaKey, string captchaUrl, IManager manager, int tryCount)
        {
            int tries = 1;
            MethodResult methodResult = new MethodResult();

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

        public void StartHandler(object sender, EventArgs eventArgs)
        {
            IManager manager = sender as IManager;
        }

        public void StopHandler(object sender, EventArgs eventArgs)
        {
            IManager manager = sender as IManager;
        }


        public override async Task Run(IEnumerable<IManager> managers)
        {
            Settings.Enabled = !Settings.Enabled;
            await Settings.SaveSetting();

            MessageBox.Show("Autosolve Captcha enabled: " + Settings.Enabled);
        }

        public override async Task<bool> Save()
        {
            return await Settings.SaveSetting();
        }
    }
}
