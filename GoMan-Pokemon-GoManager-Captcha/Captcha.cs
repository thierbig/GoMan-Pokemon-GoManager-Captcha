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
        public override string PluginName { get; set; } = "GoManCaptcha";
        public static ApplicationModel Settings = ApplicationModel.Settings();

        //Subitems when hovering over plugin in menu
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }

        public Captcha()
        {
        }

        public override void AddManager(IManager manager)
        {
            manager.OnCaptcha += CaptchaHandler;
            //manager.OnAccountStop += StopHandler;
            //manager.OnAccountStop += StartHandler;
            base.AddManager(manager);

        }

        public override void RemoveManager(IManager manager)
        {
            manager.OnCaptcha -= CaptchaHandler;
            //manager.OnAccountStop -= StopHandler;
            //manager.OnAccountStop -= StartHandler;
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
                Settings.SaveSetting();
            }

            //Occurs when the plugin is loaded.
            foreach (var manager in managers)
            {
                manager.OnCaptcha += CaptchaHandler;
               // manager.OnAccountStop += StopHandler;
               // manager.OnAccountStop += StartHandler;
            }
           
            return true;
        }
        private static readonly Func<string, string, Task<MethodResult<string>>> GetCaptchaResponseAction = async (captchaKey, captchaUrl) => await HttpStuff.GetCaptchaResponse(captchaKey, captchaUrl);

        public async void CaptchaHandler(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            IManager manager = sender as IManager;
            if (manager == null) return;

            while (manager.State != BotState.Paused)
            {
                await Task.Delay(250);
            }
            
            MethodResult<string> captchaResponse = await RetryAction(GetCaptchaResponseAction, Settings.CaptchaKey, manager.CaptchaURL, 5);
            Settings.TotalCaptchaSolved += 1;
            Settings.SaveSetting();
            var verifyCaptchaResults = await manager.VerifyCaptcha(captchaResponse.Data);

            if (!verifyCaptchaResults.Success) manager.Stop();
        }

        private static async Task<MethodResult<string>> RetryAction(Func<string, string, Task<MethodResult<string>>> action, string captchaKey, string captchaUrl, int tryCount)
        {
            int tries = 1;
            MethodResult<string> methodResult = new MethodResult<string>();

            while (tries < tryCount)
            {
                methodResult = await action(captchaKey, captchaUrl);

                var tryMsg = " Try #" + tries;

                if (!methodResult.Success)
                {
                    tries++;
                }

                if (methodResult.Success) break;
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
            MessageBox.Show("Fuck bitches get money");
        }

        public override async Task<bool> Save()
        {
            return true;
        }
    }
}
