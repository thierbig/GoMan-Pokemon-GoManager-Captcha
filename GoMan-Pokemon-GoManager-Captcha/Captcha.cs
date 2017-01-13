using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using GoPlugin;
using GoPlugin.Enums;
using Timer = System.Timers.Timer;


namespace GoManCaptcha
{
    internal class Captcha : IPlugin
    {
        public override string PluginName { get; set; } = "GoMan Auto Captcha";
        private static readonly Dictionary<IManager, ManagerHandler> Accounts = new Dictionary<IManager, ManagerHandler>();
        private static Timer _timer; // From System.Timers

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
            if (!Directory.Exists("./Plugins/GoManLogs")) Directory.CreateDirectory("./Plugins/GoManLogs");
            _timer = new Timer(200); 
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; 


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

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var keyValuePair in Accounts)
            {
                if (keyValuePair.Key.AccountState == AccountState.CaptchaRequired && keyValuePair.Key.State == BotState.Stopped)
                {
                    keyValuePair.Value.StoppedSolveCaptcha();
                }
            }
        }

        public override async Task Run(IEnumerable<IManager> managers)
        {
            using (var captchaSettingsFrom = new MainForm(Accounts))
            {
                captchaSettingsFrom.ShowDialog();
            }
        }

        public override async Task<bool> Save()
        {
            return await ApplicationModel.Settings.SaveSetting();
        }
    }
}