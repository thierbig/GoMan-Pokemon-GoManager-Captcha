using Goman_Plugin.View;

namespace Goman_Plugin.Modules.Captcha
{
    partial class CaptchaUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.olvLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControlCaptcha = new Goman_Plugin.View.BorderlessTabControl();
            this.tpAccounts = new Goman_Plugin.View.BorderlessTabPage();
            this.fastObjecttListViewAccounts = new BrightIdeasSoftware.FastObjectListView();
            this.olvAccountName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAccountState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSuccessCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFailedCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPokestopsFarmed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPokemonCaught = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvExp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvExpPerHour = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLevelUp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRunningTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBotState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvProxy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tpSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.numericUpDownSolveAttempts = new System.Windows.Forms.NumericUpDown();
            this.labelSolveAttempts = new System.Windows.Forms.Label();
            this.label2CaptchaApiKey = new System.Windows.Forms.Label();
            this.textBox2CaptchaApiKey = new System.Windows.Forms.TextBox();
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.tpLogs = new Goman_Plugin.View.BorderlessTabPage();
            this.fastObjectListViewLogs = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExceptionMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStackTrace = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip.SuspendLayout();
            this.tabControlCaptcha.SuspendLayout();
            this.tpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListViewAccounts)).BeginInit();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).BeginInit();
            this.tpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.togglePauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(145, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // togglePauseToolStripMenuItem
            // 
            this.togglePauseToolStripMenuItem.Name = "togglePauseToolStripMenuItem";
            this.togglePauseToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.togglePauseToolStripMenuItem.Text = "Toggle Pause";
            this.togglePauseToolStripMenuItem.Click += new System.EventHandler(this.togglePauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // olvLastLog
            // 
            this.olvLastLog.AspectName = "Log";
            this.olvLastLog.DisplayIndex = 13;
            this.olvLastLog.FillsFreeSpace = true;
            this.olvLastLog.IsVisible = false;
            this.olvLastLog.Text = "Last Log";
            this.olvLastLog.Width = 258;
            // 
            // tabControlCaptcha
            // 
            this.tabControlCaptcha.Controls.Add(this.tpAccounts);
            this.tabControlCaptcha.Controls.Add(this.tpSettings);
            this.tabControlCaptcha.Controls.Add(this.tpLogs);
            this.tabControlCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCaptcha.ItemSize = new System.Drawing.Size(26, 30);
            this.tabControlCaptcha.Location = new System.Drawing.Point(0, 0);
            this.tabControlCaptcha.Multiline = true;
            this.tabControlCaptcha.Name = "tabControlCaptcha";
            this.tabControlCaptcha.SelectedIndex = 0;
            this.tabControlCaptcha.Size = new System.Drawing.Size(796, 458);
            this.tabControlCaptcha.TabIndex = 3;
            // 
            // tpAccounts
            // 
            this.tpAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpAccounts.Controls.Add(this.fastObjecttListViewAccounts);
            this.tpAccounts.Location = new System.Drawing.Point(1, 31);
            this.tpAccounts.Name = "tpAccounts";
            this.tpAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccounts.Size = new System.Drawing.Size(794, 426);
            this.tpAccounts.TabIndex = 0;
            this.tpAccounts.Text = "Accounts";
            // 
            // fastObjecttListViewAccounts
            // 
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvAccountName);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvLevel);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvAccountState);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvSuccessCount);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvFailedCount);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvPokestopsFarmed);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvPokemonCaught);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvExp);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvExpPerHour);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvLevelUp);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvRunningTime);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvBotState);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvProxy);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvLastLog);
            this.fastObjecttListViewAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjecttListViewAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjecttListViewAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvAccountName,
            this.olvLevel,
            this.olvAccountState,
            this.olvSuccessCount,
            this.olvFailedCount,
            this.olvPokestopsFarmed,
            this.olvPokemonCaught,
            this.olvExp,
            this.olvExpPerHour,
            this.olvLevelUp,
            this.olvRunningTime,
            this.olvBotState,
            this.olvProxy});
            this.fastObjecttListViewAccounts.ContextMenuStrip = this.contextMenuStrip;
            this.fastObjecttListViewAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjecttListViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjecttListViewAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjecttListViewAccounts.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjecttListViewAccounts.FullRowSelect = true;
            this.fastObjecttListViewAccounts.Location = new System.Drawing.Point(3, 3);
            this.fastObjecttListViewAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjecttListViewAccounts.Name = "fastObjecttListViewAccounts";
            this.fastObjecttListViewAccounts.ShowGroups = false;
            this.fastObjecttListViewAccounts.Size = new System.Drawing.Size(788, 420);
            this.fastObjecttListViewAccounts.TabIndex = 1;
            this.fastObjecttListViewAccounts.UseCellFormatEvents = true;
            this.fastObjecttListViewAccounts.UseCompatibleStateImageBehavior = false;
            this.fastObjecttListViewAccounts.UseFilterIndicator = true;
            this.fastObjecttListViewAccounts.UseFiltering = true;
            this.fastObjecttListViewAccounts.View = System.Windows.Forms.View.Details;
            this.fastObjecttListViewAccounts.VirtualMode = true;
            this.fastObjecttListViewAccounts.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjecttListViewAccounts_FormatCell);
            // 
            // olvAccountName
            // 
            this.olvAccountName.AspectName = "Bot.AccountName";
            this.olvAccountName.Text = "Name";
            this.olvAccountName.Width = 94;
            // 
            // olvLevel
            // 
            this.olvLevel.AspectName = "Bot.Level";
            this.olvLevel.Text = "Level";
            this.olvLevel.Width = 42;
            // 
            // olvAccountState
            // 
            this.olvAccountState.AspectName = "Bot.AccountState";
            this.olvAccountState.Text = "Account State";
            this.olvAccountState.Width = 87;
            // 
            // olvSuccessCount
            // 
            this.olvSuccessCount.AspectName = "SuccessCount";
            this.olvSuccessCount.Text = "Success Count";
            this.olvSuccessCount.Width = 54;
            // 
            // olvFailedCount
            // 
            this.olvFailedCount.AspectName = "FailedCount";
            this.olvFailedCount.Text = "Failed Count";
            this.olvFailedCount.Width = 40;
            // 
            // olvPokestopsFarmed
            // 
            this.olvPokestopsFarmed.AspectName = "Bot.PokestopsFarmed";
            this.olvPokestopsFarmed.Text = "Pokestops/23hr";
            this.olvPokestopsFarmed.Width = 40;
            // 
            // olvPokemonCaught
            // 
            this.olvPokemonCaught.AspectName = "Bot.PokemonCaught";
            this.olvPokemonCaught.Text = "Pokemon/23hr";
            this.olvPokemonCaught.Width = 37;
            // 
            // olvExp
            // 
            this.olvExp.AspectName = "Bot.ExpRatio";
            this.olvExp.Text = "Exp";
            this.olvExp.Width = 50;
            // 
            // olvExpPerHour
            // 
            this.olvExpPerHour.AspectName = "Bot.ExpPerHour";
            this.olvExpPerHour.Text = "Exp/Hr";
            this.olvExpPerHour.Width = 52;
            // 
            // olvLevelUp
            // 
            this.olvLevelUp.AspectName = "Bot.TillLevelUp";
            this.olvLevelUp.Text = "Level Up";
            this.olvLevelUp.Width = 42;
            // 
            // olvRunningTime
            // 
            this.olvRunningTime.AspectName = "Bot.RunningTime";
            this.olvRunningTime.Text = "Time";
            this.olvRunningTime.Width = 48;
            // 
            // olvBotState
            // 
            this.olvBotState.AspectName = "Bot.State";
            this.olvBotState.Text = "Bot State";
            this.olvBotState.Width = 61;
            // 
            // olvProxy
            // 
            this.olvProxy.AspectName = "Bot.Proxy";
            this.olvProxy.Text = "Proxy";
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.numericUpDownSolveAttempts);
            this.tpSettings.Controls.Add(this.labelSolveAttempts);
            this.tpSettings.Controls.Add(this.label2CaptchaApiKey);
            this.tpSettings.Controls.Add(this.textBox2CaptchaApiKey);
            this.tpSettings.Controls.Add(this.cbkEnabled);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(1, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(794, 426);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            // 
            // numericUpDownSolveAttempts
            // 
            this.numericUpDownSolveAttempts.Location = new System.Drawing.Point(109, 67);
            this.numericUpDownSolveAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSolveAttempts.Name = "numericUpDownSolveAttempts";
            this.numericUpDownSolveAttempts.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSolveAttempts.TabIndex = 16;
            this.numericUpDownSolveAttempts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSolveAttempts.ValueChanged += new System.EventHandler(this.numericUpDownSolveAttempts_ValueChanged);
            // 
            // labelSolveAttempts
            // 
            this.labelSolveAttempts.AutoSize = true;
            this.labelSolveAttempts.Location = new System.Drawing.Point(6, 67);
            this.labelSolveAttempts.Name = "labelSolveAttempts";
            this.labelSolveAttempts.Size = new System.Drawing.Size(81, 13);
            this.labelSolveAttempts.TabIndex = 15;
            this.labelSolveAttempts.Text = "Solve Attempts:";
            // 
            // label2CaptchaApiKey
            // 
            this.label2CaptchaApiKey.AutoSize = true;
            this.label2CaptchaApiKey.Location = new System.Drawing.Point(6, 35);
            this.label2CaptchaApiKey.Name = "label2CaptchaApiKey";
            this.label2CaptchaApiKey.Size = new System.Drawing.Size(97, 13);
            this.label2CaptchaApiKey.TabIndex = 14;
            this.label2CaptchaApiKey.Text = "2Captcha API Key:";
            // 
            // textBox2CaptchaApiKey
            // 
            this.textBox2CaptchaApiKey.Location = new System.Drawing.Point(109, 35);
            this.textBox2CaptchaApiKey.Name = "textBox2CaptchaApiKey";
            this.textBox2CaptchaApiKey.Size = new System.Drawing.Size(487, 20);
            this.textBox2CaptchaApiKey.TabIndex = 13;
            this.textBox2CaptchaApiKey.TextChanged += new System.EventHandler(this.textBox2CaptchaApiKey_TextChanged);
            // 
            // cbkEnabled
            // 
            this.cbkEnabled.AutoSize = true;
            this.cbkEnabled.Checked = true;
            this.cbkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEnabled.Location = new System.Drawing.Point(6, 6);
            this.cbkEnabled.Name = "cbkEnabled";
            this.cbkEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbkEnabled.TabIndex = 12;
            this.cbkEnabled.Text = "Enabled";
            this.cbkEnabled.UseVisualStyleBackColor = true;
            this.cbkEnabled.CheckedChanged += new System.EventHandler(this.cbkEnabled_CheckedChanged);
            // 
            // tpLogs
            // 
            this.tpLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpLogs.Controls.Add(this.fastObjectListViewLogs);
            this.tpLogs.ForeColor = System.Drawing.Color.LightGray;
            this.tpLogs.Location = new System.Drawing.Point(1, 31);
            this.tpLogs.Name = "tpLogs";
            this.tpLogs.Size = new System.Drawing.Size(794, 426);
            this.tpLogs.TabIndex = 3;
            this.tpLogs.Text = "Logs";
            // 
            // fastObjectListViewLogs
            // 
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnDate);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnExceptionMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnStackTrace);
            this.fastObjectListViewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDate,
            this.olvColumnMessage,
            this.olvColumnExceptionMessage,
            this.olvColumnStackTrace});
            this.fastObjectListViewLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjectListViewLogs.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewLogs.FullRowSelect = true;
            this.fastObjectListViewLogs.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListViewLogs.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjectListViewLogs.Name = "fastObjectListViewLogs";
            this.fastObjectListViewLogs.ShowGroups = false;
            this.fastObjectListViewLogs.Size = new System.Drawing.Size(794, 426);
            this.fastObjectListViewLogs.TabIndex = 2;
            this.fastObjectListViewLogs.UseCellFormatEvents = true;
            this.fastObjectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewLogs.UseFilterIndicator = true;
            this.fastObjectListViewLogs.UseFiltering = true;
            this.fastObjectListViewLogs.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewLogs.VirtualMode = true;
            this.fastObjectListViewLogs.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListViewLogs_FormatCell);
            // 
            // olvColumnDate
            // 
            this.olvColumnDate.AspectName = "Date";
            this.olvColumnDate.Text = "Date";
            this.olvColumnDate.Width = 123;
            // 
            // olvColumnMessage
            // 
            this.olvColumnMessage.AspectName = "Message";
            this.olvColumnMessage.Text = "Message";
            this.olvColumnMessage.Width = 176;
            // 
            // olvColumnExceptionMessage
            // 
            this.olvColumnExceptionMessage.AspectName = "ExceptionMessage";
            this.olvColumnExceptionMessage.Text = "Message";
            this.olvColumnExceptionMessage.Width = 174;
            // 
            // olvColumnStackTrace
            // 
            this.olvColumnStackTrace.AspectName = "StackTrace";
            this.olvColumnStackTrace.FillsFreeSpace = true;
            this.olvColumnStackTrace.Text = "StackTrace";
            this.olvColumnStackTrace.Width = 372;
            // 
            // CaptchaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCaptcha);
            this.Name = "CaptchaUserControl";
            this.Size = new System.Drawing.Size(796, 458);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControlCaptcha.ResumeLayout(false);
            this.tpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListViewAccounts)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).EndInit();
            this.tpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderlessTabControl tabControlCaptcha;
        private BorderlessTabPage tpAccounts;
        private BorderlessTabPage tpSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownSolveAttempts;
        private System.Windows.Forms.Label labelSolveAttempts;
        private System.Windows.Forms.Label label2CaptchaApiKey;
        private System.Windows.Forms.TextBox textBox2CaptchaApiKey;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private BorderlessTabPage tpLogs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem togglePauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private BrightIdeasSoftware.FastObjectListView fastObjecttListViewAccounts;
        private BrightIdeasSoftware.OLVColumn olvAccountName;
        private BrightIdeasSoftware.OLVColumn olvLevel;
        private BrightIdeasSoftware.OLVColumn olvAccountState;
        private BrightIdeasSoftware.OLVColumn olvSuccessCount;
        private BrightIdeasSoftware.OLVColumn olvFailedCount;
        private BrightIdeasSoftware.OLVColumn olvPokestopsFarmed;
        private BrightIdeasSoftware.OLVColumn olvPokemonCaught;
        private BrightIdeasSoftware.OLVColumn olvExp;
        private BrightIdeasSoftware.OLVColumn olvExpPerHour;
        private BrightIdeasSoftware.OLVColumn olvLevelUp;
        private BrightIdeasSoftware.OLVColumn olvRunningTime;
        private BrightIdeasSoftware.OLVColumn olvBotState;
        private BrightIdeasSoftware.OLVColumn olvProxy;
        private BrightIdeasSoftware.OLVColumn olvLastLog;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnDate;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnStackTrace;
        private BrightIdeasSoftware.OLVColumn olvColumnExceptionMessage;
    }
}
