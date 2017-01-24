using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GoMan.Captcha;
using GoMan.View;
using GoPlugin;

namespace GoMan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm(new Dictionary<IManager, ManagerHandler>()));
            Application.Run(new LoginForm());
        }
    }
}
