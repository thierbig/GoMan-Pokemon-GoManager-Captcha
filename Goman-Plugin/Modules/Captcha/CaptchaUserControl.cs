using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;

namespace Goman_Plugin.Modules.Captcha
{
    public partial class CaptchaUserControl : UserControl
    {
        public CaptchaUserControl()
        {
            InitializeComponent();
        }

        private void textBox2CaptchaApiKey_TextChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.CaptchaKey = textBox2CaptchaApiKey.Text;
            ApplicationModel.Settings.SaveSetting();
        }

        private void numericUpDownSolveAttempts_ValueChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.SolveAttemptsBeforeStop = (int)numericUpDownSolveAttempts.Value;
            ApplicationModel.Settings.SaveSetting();
        }

        private void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.Enabled = cbkEnabled.Checked;
            ApplicationModel.Settings.SaveSetting();
        }
    }
}
