namespace Goman_Plugin.Modules.PokemonFeeder
{
    partial class PokemonFeederUserControl
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
            this.tabControlCaptcha = new GoMan.View.BorderlessTabControl();
            this.tpAccounts = new GoMan.View.BorderlessTabPage();
            this.fastObjecttListViewAccounts = new BrightIdeasSoftware.FastObjectListView();
            this.olvAccountName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.tpSettings = new GoMan.View.BorderlessTabPage();
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.tpLogs = new System.Windows.Forms.TabPage();
            this.fastObjectListViewLogs = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnMethodName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStackTrace = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControlCaptcha.SuspendLayout();
            this.tpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListViewAccounts)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.tpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).BeginInit();
            this.SuspendLayout();
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
            this.tabControlCaptcha.Size = new System.Drawing.Size(752, 471);
            this.tabControlCaptcha.TabIndex = 2;
            // 
            // tpAccounts
            // 
            this.tpAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpAccounts.Controls.Add(this.fastObjecttListViewAccounts);
            this.tpAccounts.Location = new System.Drawing.Point(1, 31);
            this.tpAccounts.Name = "tpAccounts";
            this.tpAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccounts.Size = new System.Drawing.Size(750, 439);
            this.tpAccounts.TabIndex = 0;
            this.tpAccounts.Text = "Accounts";
            // 
            // fastObjecttListViewAccounts
            // 
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvAccountName);
            this.fastObjecttListViewAccounts.AllColumns.Add(this.olvLastLog);
            this.fastObjecttListViewAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjecttListViewAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjecttListViewAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvAccountName,
            this.olvLastLog});
            this.fastObjecttListViewAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjecttListViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjecttListViewAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjecttListViewAccounts.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjecttListViewAccounts.FullRowSelect = true;
            this.fastObjecttListViewAccounts.Location = new System.Drawing.Point(3, 3);
            this.fastObjecttListViewAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjecttListViewAccounts.Name = "fastObjecttListViewAccounts";
            this.fastObjecttListViewAccounts.ShowGroups = false;
            this.fastObjecttListViewAccounts.Size = new System.Drawing.Size(744, 433);
            this.fastObjecttListViewAccounts.TabIndex = 0;
            this.fastObjecttListViewAccounts.TintSortColumn = true;
            this.fastObjecttListViewAccounts.UseCellFormatEvents = true;
            this.fastObjecttListViewAccounts.UseCompatibleStateImageBehavior = false;
            this.fastObjecttListViewAccounts.UseFilterIndicator = true;
            this.fastObjecttListViewAccounts.UseFiltering = true;
            this.fastObjecttListViewAccounts.View = System.Windows.Forms.View.Details;
            this.fastObjecttListViewAccounts.VirtualMode = true;
            // 
            // olvAccountName
            // 
            this.olvAccountName.AspectName = "Manager.AccountName";
            this.olvAccountName.Text = "Name";
            this.olvAccountName.Width = 94;
            // 
            // olvLastLog
            // 
            this.olvLastLog.AspectName = "Log";
            this.olvLastLog.FillsFreeSpace = true;
            this.olvLastLog.Text = "Last Log";
            this.olvLastLog.Width = 258;
            // 
            // olvLevel
            // 
            this.olvLevel.AspectName = "Manager.Level";
            this.olvLevel.DisplayIndex = 1;
            this.olvLevel.Text = "Level";
            this.olvLevel.Width = 42;
            // 
            // olvAccountState
            // 
            this.olvAccountState.AspectName = "Manager.AccountState";
            this.olvAccountState.DisplayIndex = 2;
            this.olvAccountState.Text = "Account State";
            this.olvAccountState.Width = 87;
            // 
            // olvSuccessCount
            // 
            this.olvSuccessCount.AspectName = "SuccessCount";
            this.olvSuccessCount.DisplayIndex = 3;
            this.olvSuccessCount.Text = "Success Count";
            this.olvSuccessCount.Width = 54;
            // 
            // olvFailedCount
            // 
            this.olvFailedCount.AspectName = "FailedCount";
            this.olvFailedCount.DisplayIndex = 4;
            this.olvFailedCount.Text = "Failed Count";
            this.olvFailedCount.Width = 40;
            // 
            // olvPokestopsFarmed
            // 
            this.olvPokestopsFarmed.AspectName = "Manager.PokestopsFarmed";
            this.olvPokestopsFarmed.DisplayIndex = 5;
            this.olvPokestopsFarmed.Text = "Pokestops/23hr";
            this.olvPokestopsFarmed.Width = 40;
            // 
            // olvPokemonCaught
            // 
            this.olvPokemonCaught.AspectName = "Manager.PokemonCaught";
            this.olvPokemonCaught.DisplayIndex = 6;
            this.olvPokemonCaught.Text = "Pokemon/23hr";
            this.olvPokemonCaught.Width = 37;
            // 
            // olvExp
            // 
            this.olvExp.AspectName = "Manager.ExpRatio";
            this.olvExp.DisplayIndex = 7;
            this.olvExp.Text = "Exp";
            this.olvExp.Width = 50;
            // 
            // olvExpPerHour
            // 
            this.olvExpPerHour.AspectName = "Manager.ExpPerHour";
            this.olvExpPerHour.DisplayIndex = 8;
            this.olvExpPerHour.Text = "Exp/Hr";
            this.olvExpPerHour.Width = 52;
            // 
            // olvLevelUp
            // 
            this.olvLevelUp.AspectName = "Manager.TillLevelUp";
            this.olvLevelUp.DisplayIndex = 9;
            this.olvLevelUp.Text = "Level Up";
            this.olvLevelUp.Width = 42;
            // 
            // olvRunningTime
            // 
            this.olvRunningTime.AspectName = "Manager.RunningTime";
            this.olvRunningTime.DisplayIndex = 10;
            this.olvRunningTime.Text = "Time";
            this.olvRunningTime.Width = 48;
            // 
            // olvBotState
            // 
            this.olvBotState.AspectName = "Manager.State";
            this.olvBotState.DisplayIndex = 11;
            this.olvBotState.Text = "Bot State";
            this.olvBotState.Width = 61;
            // 
            // olvProxy
            // 
            this.olvProxy.AspectName = "Manager.Proxy";
            this.olvProxy.DisplayIndex = 12;
            this.olvProxy.Text = "Proxy";
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.cbkEnabled);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(1, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(750, 439);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            // 
            // cbkEnabled
            // 
            this.cbkEnabled.AutoSize = true;
            this.cbkEnabled.Checked = true;
            this.cbkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEnabled.Location = new System.Drawing.Point(17, 16);
            this.cbkEnabled.Name = "cbkEnabled";
            this.cbkEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbkEnabled.TabIndex = 12;
            this.cbkEnabled.Text = "Enabled";
            this.cbkEnabled.UseVisualStyleBackColor = true;
            // 
            // tpLogs
            // 
            this.tpLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpLogs.Controls.Add(this.fastObjectListViewLogs);
            this.tpLogs.ForeColor = System.Drawing.Color.LightGray;
            this.tpLogs.Location = new System.Drawing.Point(1, 31);
            this.tpLogs.Name = "tpLogs";
            this.tpLogs.Size = new System.Drawing.Size(750, 439);
            this.tpLogs.TabIndex = 3;
            this.tpLogs.Text = "Logs";
            // 
            // fastObjectListViewLogs
            // 
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnMethodName);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnStackTrace);
            this.fastObjectListViewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnMethodName,
            this.olvColumnMessage,
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
            this.fastObjectListViewLogs.Size = new System.Drawing.Size(750, 439);
            this.fastObjectListViewLogs.TabIndex = 1;
            this.fastObjectListViewLogs.TintSortColumn = true;
            this.fastObjectListViewLogs.UseCellFormatEvents = true;
            this.fastObjectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewLogs.UseFilterIndicator = true;
            this.fastObjectListViewLogs.UseFiltering = true;
            this.fastObjectListViewLogs.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewLogs.VirtualMode = true;
            // 
            // olvColumnMethodName
            // 
            this.olvColumnMethodName.AspectName = "Manager.AccountName";
            this.olvColumnMethodName.Text = "Method";
            this.olvColumnMethodName.Width = 123;
            // 
            // olvColumnMessage
            // 
            this.olvColumnMessage.AspectName = "Manager.Level";
            this.olvColumnMessage.Text = "Message";
            this.olvColumnMessage.Width = 239;
            // 
            // olvColumnStackTrace
            // 
            this.olvColumnStackTrace.AspectName = "Manager.AccountState";
            this.olvColumnStackTrace.FillsFreeSpace = true;
            this.olvColumnStackTrace.Text = "StackTrace";
            this.olvColumnStackTrace.Width = 372;
            // 
            // PokemonFeederUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCaptcha);
            this.Name = "PokemonFeederUserControl";
            this.Size = new System.Drawing.Size(752, 471);
            this.tabControlCaptcha.ResumeLayout(false);
            this.tpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjecttListViewAccounts)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GoMan.View.BorderlessTabControl tabControlCaptcha;
        private GoMan.View.BorderlessTabPage tpAccounts;
        private BrightIdeasSoftware.FastObjectListView fastObjecttListViewAccounts;
        private BrightIdeasSoftware.OLVColumn olvAccountName;
        private BrightIdeasSoftware.OLVColumn olvLastLog;
        private GoMan.View.BorderlessTabPage tpSettings;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private System.Windows.Forms.TabPage tpLogs;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnMethodName;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnStackTrace;
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
    }
}
