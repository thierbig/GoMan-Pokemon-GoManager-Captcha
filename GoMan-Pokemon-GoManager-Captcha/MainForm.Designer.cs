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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvAccountName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAccountState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBotState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSuccessCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFailedCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbkSaveLogs = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDownSolveAttempts = new System.Windows.Forms.NumericUpDown();
            this.labelSolveAttempts = new System.Windows.Forms.Label();
            this.label2CaptchaApiKey = new System.Windows.Forms.Label();
            this.textBox2CaptchaApiKey = new System.Windows.Forms.TextBox();
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).BeginInit();
            this.SuspendLayout();
            // 
            // tpAccounts
            // 
            this.tpAccounts.Controls.Add(this.objectListView1);
            this.tpAccounts.Location = new System.Drawing.Point(104, 4);
            this.tpAccounts.Name = "tpAccounts";
            this.tpAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccounts.Size = new System.Drawing.Size(979, 292);
            this.tpAccounts.TabIndex = 0;
            this.tpAccounts.Text = "Accounts";
            this.tpAccounts.UseVisualStyleBackColor = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvAccountName);
            this.objectListView1.AllColumns.Add(this.olvAccountState);
            this.objectListView1.AllColumns.Add(this.olvBotState);
            this.objectListView1.AllColumns.Add(this.olvSuccessCount);
            this.objectListView1.AllColumns.Add(this.olvFailedCount);
            this.objectListView1.AllColumns.Add(this.olvLastLog);
            this.objectListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.objectListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvAccountName,
            this.olvAccountState,
            this.olvBotState,
            this.olvSuccessCount,
            this.olvFailedCount,
            this.olvLastLog});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.objectListView1.ForeColor = System.Drawing.Color.LightGray;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(3, 3);
            this.objectListView1.Margin = new System.Windows.Forms.Padding(2);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(973, 286);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.TintSortColumn = true;
            this.objectListView1.UseCellFormatEvents = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.objectListView1_FormatCell);
            // 
            // olvAccountName
            // 
            this.olvAccountName.AspectName = "Manager.AccountName";
            this.olvAccountName.Text = "Name";
            this.olvAccountName.Width = 122;
            // 
            // olvAccountState
            // 
            this.olvAccountState.AspectName = "Manager.AccountState";
            this.olvAccountState.Text = "Account State";
            this.olvAccountState.Width = 87;
            // 
            // olvBotState
            // 
            this.olvBotState.AspectName = "Manager.State";
            this.olvBotState.Text = "Bot State";
            this.olvBotState.Width = 61;
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
            // olvLastLog
            // 
            this.olvLastLog.AspectName = "Log";
            this.olvLastLog.FillsFreeSpace = true;
            this.olvLastLog.Text = "Log";
            this.olvLastLog.Width = 258;
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
            this.tabControl1.Size = new System.Drawing.Size(1087, 300);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
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
            this.tpSettings.Size = new System.Drawing.Size(979, 292);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 300);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GoMan Captcha";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolveAttempts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAccounts;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvAccountName;
        private BrightIdeasSoftware.OLVColumn olvAccountState;
        private BrightIdeasSoftware.OLVColumn olvSuccessCount;
        private BrightIdeasSoftware.OLVColumn olvFailedCount;
        private BrightIdeasSoftware.OLVColumn olvBotState;
        private BrightIdeasSoftware.OLVColumn olvLastLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownSolveAttempts;
        private System.Windows.Forms.Label labelSolveAttempts;
        private System.Windows.Forms.Label label2CaptchaApiKey;
        private System.Windows.Forms.TextBox textBox2CaptchaApiKey;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbkSaveLogs;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}