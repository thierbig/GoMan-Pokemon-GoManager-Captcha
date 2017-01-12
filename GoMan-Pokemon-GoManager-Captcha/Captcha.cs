using System;
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
        public override string PluginName { get; set; } = "GoMan Auto Captcha";
        private static readonly Dictionary<IManager, ManagerHandler> Accounts = new Dictionary<IManager, ManagerHandler>();


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