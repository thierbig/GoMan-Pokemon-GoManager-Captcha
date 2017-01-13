using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoPlugin;
using GoPlugin.Enums;

namespace GoManCaptcha
{
    public partial class MainForm : Form
    {
        private readonly List<ManagerHandler> _accounts = new List<ManagerHandler>();

        public MainForm(Dictionary<IManager, ManagerHandler> accounts)
        {
            InitializeComponent();

            cbkEnabled.Checked = ApplicationModel.Settings.Enabled;
            cbkSaveLogs.Checked = ApplicationModel.Settings.SaveLogs;
            textBox2CaptchaApiKey.Text = ApplicationModel.Settings.CaptchaKey;
            numericUpDownSolveAttempts.Value = ApplicationModel.Settings.SolveAttemptsBeforeStop;

            foreach (var keyValuePair in accounts)
            {
                objectListView1.AddObject(keyValuePair.Value);
                _accounts.Add(keyValuePair.Value);
            }

            timer1.Enabled = true;

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var ctlTab = (TabControl)sender;
            var g = e.Graphics;
            var sText = ctlTab.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(sText, ctlTab.Font);
            var iX = e.Bounds.Left + 6;
            var iY = (int) (e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2);
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var managerHandler in _accounts)
            {
                objectListView1.RefreshObject(managerHandler);
            }
           
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            ManagerHandler managerHandler = (ManagerHandler)e.Model;

            if (e.Column == olvAccountState)
            {
                switch (managerHandler.Manager.AccountState)
                {
                    case AccountState.Good:
                        e.SubItem.ForeColor = Color.Green;
                        break;
                    case AccountState.CaptchaRequired:
                        e.SubItem.ForeColor = Color.LightSkyBlue;
                        break;
                    default:
                        e.SubItem.ForeColor = Color.Red;
                        break;
                }
            }
            else if (e.Column == olvBotState)
            {
                switch (managerHandler.Manager.State)
                {
                    case BotState.Running:
                        e.SubItem.ForeColor = Color.Green;
                        break;
                    case BotState.Starting:
                        e.SubItem.ForeColor = Color.LightGreen;
                        break;
                    case BotState.Waiting:
                        e.SubItem.ForeColor = Color.Orange;
                        break;
                    case BotState.Pausing:
                        e.SubItem.ForeColor = Color.Yellow;
                        break;
                    case BotState.Paused:
                        e.SubItem.ForeColor = Color.Yellow;
                        break;
                    default:
                        e.SubItem.ForeColor = Color.Red;
                        break;
                }
            }
            else if (e.Column == olvLastLog)
            {
                LogModel log = managerHandler.EventLog.LastOrDefault();

                if (log == null)
                {
                    return;
                }

                e.SubItem.ForeColor = log.GetLogColor();
            }
        }

        private void textBox2CaptchaApiKey_TextChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.CaptchaKey = textBox2CaptchaApiKey.Text;
            ApplicationModel.Settings.SaveSetting();
        }

        private void numericUpDownSolveAttempts_ValueChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.SolveAttemptsBeforeStop = (int) numericUpDownSolveAttempts.Value;
            ApplicationModel.Settings.SaveSetting();
        }

        private void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.Enabled = cbkEnabled.Checked;
            ApplicationModel.Settings.SaveSetting();
        }
        
        private void cbkSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.SaveLogs = cbkSaveLogs.Checked;
            ApplicationModel.Settings.SaveSetting();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplicationModel.Settings.CaptchaKey))
            {
                textBox2CaptchaApiKey.Focus();
                textBox2CaptchaApiKey.BackColor = Color.Red;
                tabControl1.SelectedTab = tpSettings;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goman.io");
        }
    }
}
