namespace GoManCaptcha
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tpAccounts = new System.Windows.Forms.TabPage();
            this.fastObjecttListView1 = new BrightIdeasSoftware.FastObjectListView();
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
            this.olvLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.cbkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbkSaveLogs = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDownSolveAttempts = new System.Windows.Forms.NumericUpDown();
            this.labelSolveAttempts = new System.Windows.Forms.Label();
            this.label2CaptchaApiKey = new System.Windows.Forms.Label();
            this.textBox2CaptchaApiKey = new System.Windows.Forms.TextBox();
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSuccessfulCaptchas = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFailedCaptchas = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListView1)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpAccounts
            // 
            this.tpAccounts.Controls.Add(this.fastObjecttListView1);
            this.tpAccounts.Location = new System.Drawing.Point(104, 4);
            this.tpAccounts.Name = "tpAccounts";
            this.tpAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccounts.Size = new System.Drawing.Size(1010, 319);
            this.tpAccounts.TabIndex = 0;
            this.tpAccounts.Text = "Accounts";
            this.tpAccounts.UseVisualStyleBackColor = true;
            // 
            // fastObjecttListView1
            // 
            this.fastObjecttListView1.AllColumns.Add(this.olvAccountName);
            this.fastObjecttListView1.AllColumns.Add(this.olvLevel);
            this.fastObjecttListView1.AllColumns.Add(this.olvAccountState);
            this.fastObjecttListView1.AllColumns.Add(this.olvSuccessCount);
            this.fastObjecttListView1.AllColumns.Add(this.olvFailedCount);
            this.fastObjecttListView1.AllColumns.Add(this.olvPokestopsFarmed);
            this.fastObjecttListView1.AllColumns.Add(this.olvPokemonCaught);
            this.fastObjecttListView1.AllColumns.Add(this.olvExp);
            this.fastObjecttListView1.AllColumns.Add(this.olvExpPerHour);
            this.fastObjecttListView1.AllColumns.Add(this.olvLevelUp);
            this.fastObjecttListView1.AllColumns.Add(this.olvRunningTime);
            this.fastObjecttListView1.AllColumns.Add(this.olvBotState);
            this.fastObjecttListView1.AllColumns.Add(this.olvProxy);
            this.fastObjecttListView1.AllColumns.Add(this.olvLastLog);
            this.fastObjecttListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjecttListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjecttListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.olvProxy,
            this.olvLastLog});
            this.fastObjecttListView1.ContextMenuStrip = this.contextMenuStrip;
            this.fastObjecttListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjecttListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjecttListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjecttListView1.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjecttListView1.FullRowSelect = true;
            this.fastObjecttListView1.Location = new System.Drawing.Point(3, 3);
            this.fastObjecttListView1.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjecttListView1.Name = "fastObjecttListView1";
            this.fastObjecttListView1.ShowGroups = false;
            this.fastObjecttListView1.Size = new System.Drawing.Size(1004, 313);
            this.fastObjecttListView1.TabIndex = 0;
            this.fastObjecttListView1.TintSortColumn = true;
            this.fastObjecttListView1.UseCellFormatEvents = true;
            this.fastObjecttListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjecttListView1.UseFilterIndicator = true;
            this.fastObjecttListView1.UseFiltering = true;
            this.fastObjecttListView1.View = System.Windows.Forms.View.Details;
            this.fastObjecttListView1.VirtualMode = true;
            this.fastObjecttListView1.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.objectListView1_FormatCell);
            // 
            // olvAccountName
            // 
            this.olvAccountName.AspectName = "Manager.AccountName";
            this.olvAccountName.Text = "Name";
            this.olvAccountName.Width = 94;
            // 
            // olvLevel
            // 
            this.olvLevel.AspectName = "Manager.Level";
            this.olvLevel.Text = "Level";
            this.olvLevel.Width = 42;
            // 
            // olvAccountState
            // 
            this.olvAccountState.AspectName = "Manager.AccountState";
            this.olvAccountState.Text = "Account State";
            this.olvAccountState.Width = 87;
            // 
            // olvSuccessCount
            // 
            this.olvSuccessCount.AspectName = "SuccessCount";
            this.olvSuccessCount.Text = "Success Count";
            this.olvSuccessCount.Width = 88;
            // 
            // olvFailedCount
            // 
            this.olvFailedCount.AspectName = "FailedCount";
            this.olvFailedCount.Text = "Failed Count";
            this.olvFailedCount.Width = 76;
            // 
            // olvPokestopsFarmed
            // 
            this.olvPokestopsFarmed.AspectName = "Manager.PokestopsFarmed";
            this.olvPokestopsFarmed.Text = "Pokestops/23hr";
            this.olvPokestopsFarmed.Width = 40;
            // 
            // olvPokemonCaught
            // 
            this.olvPokemonCaught.AspectName = "Manager.PokemonCaught";
            this.olvPokemonCaught.Text = "Pokemon/23hr";
            this.olvPokemonCaught.Width = 64;
            // 
            // olvExp
            // 
            this.olvExp.AspectName = "Manager.ExpRatio";
            this.olvExp.Text = "Exp";
            this.olvExp.Width = 50;
            // 
            // olvExpPerHour
            // 
            this.olvExpPerHour.AspectName = "Manager.ExpPerHour";
            this.olvExpPerHour.Text = "Exp/Hr";
            this.olvExpPerHour.Width = 52;
            // 
            // olvLevelUp
            // 
            this.olvLevelUp.AspectName = "Manager.TillLevelUp";
            this.olvLevelUp.Text = "Level Up";
            // 
            // olvRunningTime
            // 
            this.olvRunningTime.AspectName = "Manager.RunningTime";
            this.olvRunningTime.Text = "Time";
            // 
            // olvBotState
            // 
            this.olvBotState.AspectName = "Manager.State";
            this.olvBotState.Text = "Bot State";
            this.olvBotState.Width = 61;
            // 
            // olvProxy
            // 
            this.olvProxy.AspectName = "Manager.Proxy";
            this.olvProxy.Text = "Proxy";
            // 
            // olvLastLog
            // 
            this.olvLastLog.AspectName = "Log";
            this.olvLastLog.FillsFreeSpace = true;
            this.olvLastLog.Text = "Last Log";
            this.olvLastLog.Width = 258;
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
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tpAccounts);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(30, 100);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1118, 327);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.cbkAutoUpdate);
            this.tpSettings.Controls.Add(this.linkLabel1);
            this.tpSettings.Controls.Add(this.cbkSaveLogs);
            this.tpSettings.Controls.Add(this.richTextBox1);
            this.tpSettings.Controls.Add(this.numericUpDownSolveAttempts);
            this.tpSettings.Controls.Add(this.labelSolveAttempts);
            this.tpSettings.Controls.Add(this.label2CaptchaApiKey);
            this.tpSettings.Controls.Add(this.textBox2CaptchaApiKey);
            this.tpSettings.Controls.Add(this.cbkEnabled);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(104, 4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1010, 319);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            // 
            // cbkAutoUpdate
            // 
            this.cbkAutoUpdate.AutoSize = true;
            this.cbkAutoUpdate.Checked = true;
            this.cbkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkAutoUpdate.Location = new System.Drawing.Point(153, 8);
            this.cbkAutoUpdate.Name = "cbkAutoUpdate";
            this.cbkAutoUpdate.Size = new System.Drawing.Size(133, 28);
            this.cbkAutoUpdate.TabIndex = 11;
            this.cbkAutoUpdate.Text = "Auto Update";
            this.cbkAutoUpdate.UseVisualStyleBackColor = true;
            this.cbkAutoUpdate.CheckedChanged += new System.EventHandler(this.ckAutoUpdate_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(652, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(317, 24);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cheap Pokemon Go Proxy Services!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbkSaveLogs
            // 
            this.cbkSaveLogs.AutoSize = true;
            this.cbkSaveLogs.Checked = true;
            this.cbkSaveLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkSaveLogs.Location = new System.Drawing.Point(11, 43);
            this.cbkSaveLogs.Name = "cbkSaveLogs";
            this.cbkSaveLogs.Size = new System.Drawing.Size(117, 28);
            this.cbkSaveLogs.TabIndex = 9;
            this.cbkSaveLogs.Text = "Save Logs";
            this.cbkSaveLogs.UseVisualStyleBackColor = true;
            this.cbkSaveLogs.CheckedChanged += new System.EventHandler(this.cbkSaveLogs_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 177);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(958, 96);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "Disable \'Stop on Captcha\' for this plugin to work properly.  Highlight all accoun" +
    "ts, right click, and uncheck Captcha.  Settings>Auto Stops>Captcha";
            // 
            // numericUpDownSolveAttempts
            // 
            this.numericUpDownSolveAttempts.Location = new System.Drawing.Point(204, 124);
            this.numericUpDownSolveAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSolveAttempts.Name = "numericUpDownSolveAttempts";
            this.numericUpDownSolveAttempts.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownSolveAttempts.TabIndex = 4;
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
            this.labelSolveAttempts.Location = new System.Drawing.Point(36, 126);
            this.labelSolveAttempts.Name = "labelSolveAttempts";
            this.labelSolveAttempts.Size = new System.Drawing.Size(139, 24);
            this.labelSolveAttempts.TabIndex = 3;
            this.labelSolveAttempts.Text = "Solve Attempts:";
            // 
            // label2CaptchaApiKey
            // 
            this.label2CaptchaApiKey.AutoSize = true;
            this.label2CaptchaApiKey.Location = new System.Drawing.Point(6, 90);
            this.label2CaptchaApiKey.Name = "label2CaptchaApiKey";
            this.label2CaptchaApiKey.Size = new System.Drawing.Size(165, 24);
            this.label2CaptchaApiKey.TabIndex = 2;
            this.label2CaptchaApiKey.Text = "2Captcha API Key:";
            // 
            // textBox2CaptchaApiKey
            // 
            this.textBox2CaptchaApiKey.Location = new System.Drawing.Point(204, 87);
            this.textBox2CaptchaApiKey.Name = "textBox2CaptchaApiKey";
            this.textBox2CaptchaApiKey.Size = new System.Drawing.Size(487, 29);
            this.textBox2CaptchaApiKey.TabIndex = 1;
            this.textBox2CaptchaApiKey.TextChanged += new System.EventHandler(this.textBox2CaptchaApiKey_TextChanged);
            // 
            // cbkEnabled
            // 
            this.cbkEnabled.AutoSize = true;
            this.cbkEnabled.Checked = true;
            this.cbkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEnabled.Location = new System.Drawing.Point(11, 8);
            this.cbkEnabled.Name = "cbkEnabled";
            this.cbkEnabled.Size = new System.Drawing.Size(100, 28);
            this.cbkEnabled.TabIndex = 0;
            this.cbkEnabled.Text = "Enabled";
            this.cbkEnabled.UseVisualStyleBackColor = true;
            this.cbkEnabled.CheckedChanged += new System.EventHandler(this.cbkEnabled_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSuccessfulCaptchas,
            this.toolStripStatusLabelFailedCaptchas});
            this.statusStrip.Location = new System.Drawing.Point(0, 305);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1118, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSuccessfulCaptchas
            // 
            this.toolStripStatusLabelSuccessfulCaptchas.Name = "toolStripStatusLabelSuccessfulCaptchas";
            this.toolStripStatusLabelSuccessfulCaptchas.Size = new System.Drawing.Size(155, 17);
            this.toolStripStatusLabelSuccessfulCaptchas.Tag = "Total Successful Captchas: {0}";
            this.toolStripStatusLabelSuccessfulCaptchas.Text = "Total Successful Captchas: 0";
            // 
            // toolStripStatusLabelFailedCaptchas
            // 
            this.toolStripStatusLabelFailedCaptchas.Name = "toolStripStatusLabelFailedCaptchas";
            this.toolStripStatusLabelFailedCaptchas.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabelFailedCaptchas.Tag = "Total Failed Captchas: {0}";
            this.toolStripStatusLabelFailedCaptchas.Text = "Total Failed Captchas: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 327);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GoMan Captcha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListView1)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAccounts;
        private BrightIdeasSoftware.FastObjectListView fastObjecttListView1;
        private BrightIdeasSoftware.OLVColumn olvAccountName;
        private BrightIdeasSoftware.OLVColumn olvAccountState;
        private BrightIdeasSoftware.OLVColumn olvSuccessCount;
        private BrightIdeasSoftware.OLVColumn olvFailedCount;
        private BrightIdeasSoftware.OLVColumn olvBotState;
        private BrightIdeasSoftware.OLVColumn olvLastLog;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownSolveAttempts;
        private System.Windows.Forms.Label labelSolveAttempts;
        private System.Windows.Forms.Label label2CaptchaApiKey;
        private System.Windows.Forms.TextBox textBox2CaptchaApiKey;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbkSaveLogs;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem togglePauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvLevel;
        private BrightIdeasSoftware.OLVColumn olvPokestopsFarmed;
        private BrightIdeasSoftware.OLVColumn olvPokemonCaught;
        private BrightIdeasSoftware.OLVColumn olvExp;
        private BrightIdeasSoftware.OLVColumn olvExpPerHour;
        private BrightIdeasSoftware.OLVColumn olvLevelUp;
        private BrightIdeasSoftware.OLVColumn olvRunningTime;
        private BrightIdeasSoftware.OLVColumn olvProxy;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSuccessfulCaptchas;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFailedCaptchas;
        private System.Windows.Forms.CheckBox cbkAutoUpdate;
    }
}