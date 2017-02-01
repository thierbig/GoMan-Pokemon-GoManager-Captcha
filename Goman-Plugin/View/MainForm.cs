using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoMan.View;
using GoPlugin;
using GoPlugin.Enums;

namespace Goman_Plugin.View
{
    public partial class MainForm : Form
    {
        private readonly System.Timers.Timer _timer;
        public MainForm()
        {
            
            InitializeComponent();

            this.fastObjecttListView1.PrimarySortColumn = this.olvBotState;
            this.fastObjecttListView1.PrimarySortOrder = SortOrder.Descending;

            //toolStripStatusLabelSuccessfulCaptchas.Text = string.Format(toolStripStatusLabelSuccessfulCaptchas.Tag.ToString(), ManagerHandler.TotalSuccessCount);
            //toolStripStatusLabelFailedCaptchas.Text = string.Format(toolStripStatusLabelFailedCaptchas.Tag.ToString(), ManagerHandler.TotalFailedCount);
            //toolStripStatusLabelCaptchaRate.Text = string.Format(toolStripStatusLabelCaptchaRate.Tag.ToString(), _stringCaptchaRate, ManagerHandler.GetCaptchasRate());

            cbkEnabled.Checked = ApplicationModel.Settings.Enabled;
            cbkSaveLogs.Checked = ApplicationModel.Settings.SaveLogs;
            textBox2CaptchaApiKey.Text = ApplicationModel.Settings.CaptchaKey;
            numericUpDownSolveAttempts.Value = ApplicationModel.Settings.SolveAttemptsBeforeStop;

           // ManagerHandler.SolvedCaptchaEvent += UpdateCounters_Event;

           // foreach (var keyValuePair in accounts)
           //     _accounts.Add(keyValuePair.Value);

            
            //fastObjecttListView1.SetObjects(_accounts);


        }
        private void UpdateCounters_Event(object sender, EventArgs e)
        {
            //toolStripStatusLabelSuccessfulCaptchas.Text = string.Format(toolStripStatusLabelSuccessfulCaptchas.Tag.ToString(), ManagerHandler.TotalSuccessCount);
            //toolStripStatusLabelFailedCaptchas.Text = string.Format(toolStripStatusLabelFailedCaptchas.Tag.ToString(), ManagerHandler.TotalFailedCount);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
           var ctlTab = (BorderlessTabControl)sender;
            var g = e.Graphics;
            var sText = ctlTab.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(sText, ctlTab.Font);
            var iX = e.Bounds.Left + 6;
            var iY = (int) (e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2);
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            var managerWrapper = (Manager)e.Model;
            var manager = managerWrapper.Bot;

            if (manager != null)
            {
                if (e.Column == this.olvAccountState)
                {
                    switch (manager.AccountState)
                    {
                        case AccountState.Good:
                            e.SubItem.ForeColor = Color.Green;
                            break;
                        case AccountState.PermAccountBan:
                        case AccountState.NotVerified:
                            e.SubItem.ForeColor = Color.Red;
                            break;
                        case AccountState.AccountWarning:
                        case AccountState.PokemonBanAndPokestopBanTemp:
                        case AccountState.PokestopBanTemp:
                        case AccountState.PokemonBanTemp:
                            e.SubItem.ForeColor = Color.Yellow;
                            break;
                        case AccountState.CaptchaRequired:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                    }
                }
                else if (e.Column == this.olvBotState)
                {
                    switch (manager.State)
                    {
                        case BotState.Stopped:
                            e.SubItem.ForeColor = Color.Red;
                            break;
                        case BotState.Stopping:
                            e.SubItem.ForeColor = Color.OrangeRed;
                            break;
                        case BotState.Starting:
                            e.SubItem.ForeColor = Color.LightGreen;
                            break;
                        case BotState.Running:
                            e.SubItem.ForeColor = Color.Green;
                            break;
                        case BotState.Pausing:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                        case BotState.Paused:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                    }
                }
                else if (e.Column == olvLastLog)
                {
                    if (managerWrapper.Log == null)
                    {
                        return;
                    }

                    e.SubItem.ForeColor = managerWrapper.Log.GetLogColor();
                }
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
        private void ckAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationModel.Settings.AutoUpdate = cbkAutoUpdate.Checked;
            ApplicationModel.Settings.SaveSetting();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "GoMan Plugin - v" + VersionModel.CurrentVersion;
            if (string.IsNullOrEmpty(ApplicationModel.Settings.CaptchaKey))
            {
                textBox2CaptchaApiKey.Focus();
                textBox2CaptchaApiKey.BackColor = Color.Red;
                tabControlMain.SelectedTab = tpCaptcha;
                tabControlCaptcha.SelectedTab = tpSettings;

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Dispose();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListView1.SelectedObjects)
            {
                selectedObject.Bot.Start();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListView1.SelectedObjects)
            {
                selectedObject.Bot.Restart();
            }
        }

        private void togglePauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListView1.SelectedObjects)
            {
                selectedObject.Bot.TogglePause();
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListView1.SelectedObjects)
            {
                selectedObject.Bot.Stop();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://goman.io");
        }

        private string _stringCaptchaRate = "1 Minute";

        private void minute1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _stringCaptchaRate = "1 Minute";
           // toolStripStatusLabelCaptchaRate.Text = string.Format(toolStripStatusLabelCaptchaRate.Tag.ToString(), _stringCaptchaRate, ManagerHandler.GetCaptchasRate());
        }

        private void minutes30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _stringCaptchaRate = "30 Minute";
          //  toolStripStatusLabelCaptchaRate.Text = string.Format(toolStripStatusLabelCaptchaRate.Tag.ToString(), _stringCaptchaRate, ManagerHandler.GetCaptchasRate());
        }

        private void hour1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _stringCaptchaRate = "1 Hour";
         //   toolStripStatusLabelCaptchaRate.Text = string.Format(toolStripStatusLabelCaptchaRate.Tag.ToString(), _stringCaptchaRate, ManagerHandler.GetCaptchasRate());
        }
    }
}
