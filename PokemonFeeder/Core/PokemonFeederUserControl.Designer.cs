
using PokemonFeeder.View;

namespace PokemonFeeder.Core
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
            this.components = new System.ComponentModel.Container();
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
            this.tabControlCaptcha = new BorderlessTabControl();
            this.tpSettings = new BorderlessTabPage();
            this.fastObjectListViewScrapper = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnUri = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTotalScrapedPokemon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripScraper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpLogs = new BorderlessTabPage();
            this.fastObjectListViewLogs = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExceptionMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStackTrace = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControlCaptcha.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewScrapper)).BeginInit();
            this.contextMenuStripScraper.SuspendLayout();
            this.tpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).BeginInit();
            this.SuspendLayout();
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
            // tabControlCaptcha
            // 
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
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.fastObjectListViewScrapper);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(1, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(750, 439);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            // 
            // fastObjectListViewScrapper
            // 
            this.fastObjectListViewScrapper.AllColumns.Add(this.olvColumnUri);
            this.fastObjectListViewScrapper.AllColumns.Add(this.olvColumnTotalScrapedPokemon);
            this.fastObjectListViewScrapper.AllColumns.Add(this.olvColumnLastLog);
            this.fastObjectListViewScrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastObjectListViewScrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewScrapper.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewScrapper.CellEditUseWholeCell = false;
            this.fastObjectListViewScrapper.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnUri,
            this.olvColumnTotalScrapedPokemon,
            this.olvColumnLastLog});
            this.fastObjectListViewScrapper.ContextMenuStrip = this.contextMenuStripScraper;
            this.fastObjectListViewScrapper.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewScrapper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjectListViewScrapper.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewScrapper.FullRowSelect = true;
            this.fastObjectListViewScrapper.Location = new System.Drawing.Point(0, 28);
            this.fastObjectListViewScrapper.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjectListViewScrapper.Name = "fastObjectListViewScrapper";
            this.fastObjectListViewScrapper.ShowGroups = false;
            this.fastObjectListViewScrapper.Size = new System.Drawing.Size(750, 412);
            this.fastObjectListViewScrapper.TabIndex = 13;
            this.fastObjectListViewScrapper.UseCellFormatEvents = true;
            this.fastObjectListViewScrapper.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewScrapper.UseFilterIndicator = true;
            this.fastObjectListViewScrapper.UseFiltering = true;
            this.fastObjectListViewScrapper.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewScrapper.VirtualMode = true;
            // 
            // olvColumnUri
            // 
            this.olvColumnUri.AspectName = "RocketMapUri";
            this.olvColumnUri.FillsFreeSpace = true;
            this.olvColumnUri.Text = "Uri";
            this.olvColumnUri.Width = 258;
            // 
            // olvColumnTotalScrapedPokemon
            // 
            this.olvColumnTotalScrapedPokemon.AspectName = "TotalScrapedPokemon";
            this.olvColumnTotalScrapedPokemon.Text = "Total Scraped Pokemon";
            this.olvColumnTotalScrapedPokemon.Width = 131;
            // 
            // olvColumnLastLog
            // 
            this.olvColumnLastLog.AspectName = "LastLog";
            this.olvColumnLastLog.FillsFreeSpace = true;
            this.olvColumnLastLog.Text = "Log";
            this.olvColumnLastLog.Width = 195;
            // 
            // contextMenuStripScraper
            // 
            this.contextMenuStripScraper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addFromFileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripScraper.Name = "contextMenuStripScraper";
            this.contextMenuStripScraper.Size = new System.Drawing.Size(149, 92);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addFromFileToolStripMenuItem
            // 
            this.addFromFileToolStripMenuItem.Name = "addFromFileToolStripMenuItem";
            this.addFromFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addFromFileToolStripMenuItem.Text = "Add From File";
            this.addFromFileToolStripMenuItem.Click += new System.EventHandler(this.addFromFileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
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
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnDate);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnExceptionMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnStackTrace);
            this.fastObjectListViewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewLogs.CellEditUseWholeCell = false;
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
            this.fastObjectListViewLogs.Size = new System.Drawing.Size(750, 439);
            this.fastObjectListViewLogs.TabIndex = 3;
            this.fastObjectListViewLogs.UseCellFormatEvents = true;
            this.fastObjectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewLogs.UseFilterIndicator = true;
            this.fastObjectListViewLogs.UseFiltering = true;
            this.fastObjectListViewLogs.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewLogs.VirtualMode = true;
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PokemonFeederUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCaptcha);
            this.Name = "PokemonFeederUserControl";
            this.Size = new System.Drawing.Size(752, 471);
            this.tabControlCaptcha.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewScrapper)).EndInit();
            this.contextMenuStripScraper.ResumeLayout(false);
            this.tpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderlessTabControl tabControlCaptcha;
        private BorderlessTabPage tpSettings;
        private BorderlessTabPage tpLogs;
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
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnDate;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnExceptionMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnStackTrace;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewScrapper;
        private BrightIdeasSoftware.OLVColumn olvColumnUri;
        private BrightIdeasSoftware.OLVColumn olvColumnTotalScrapedPokemon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripScraper;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumnLastLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem addFromFileToolStripMenuItem;
    }
}
