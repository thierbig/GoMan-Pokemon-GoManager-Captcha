using Goman_Plugin.View;

namespace Goman_Plugin.Modules.AccountFeeder
{
    partial class AccountFeederUserControl
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
            this.tabControlAccountFeeder = new Goman_Plugin.View.BorderlessTabControl();
            this.tpAccountMap = new Goman_Plugin.View.BorderlessTabPage();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.tpSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.tpLogs = new Goman_Plugin.View.BorderlessTabPage();
            this.fastObjectListViewLogs = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExceptionMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStackTrace = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControlAccountFeeder.SuspendLayout();
            this.tpAccountMap.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAccountFeeder
            // 
            this.tabControlAccountFeeder.Controls.Add(this.tpAccountMap);
            this.tabControlAccountFeeder.Controls.Add(this.tpSettings);
            this.tabControlAccountFeeder.Controls.Add(this.tpLogs);
            this.tabControlAccountFeeder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccountFeeder.ItemSize = new System.Drawing.Size(26, 30);
            this.tabControlAccountFeeder.Location = new System.Drawing.Point(0, 0);
            this.tabControlAccountFeeder.Multiline = true;
            this.tabControlAccountFeeder.Name = "tabControlAccountFeeder";
            this.tabControlAccountFeeder.SelectedIndex = 0;
            this.tabControlAccountFeeder.Size = new System.Drawing.Size(796, 458);
            this.tabControlAccountFeeder.TabIndex = 3;
            // 
            // tpAccountMap
            // 
            this.tpAccountMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpAccountMap.Controls.Add(this.gMapControl1);
            this.tpAccountMap.ForeColor = System.Drawing.Color.LightGray;
            this.tpAccountMap.Location = new System.Drawing.Point(1, 31);
            this.tpAccountMap.Name = "tpAccountMap";
            this.tpAccountMap.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccountMap.Size = new System.Drawing.Size(794, 426);
            this.tpAccountMap.TabIndex = 2;
            this.tpAccountMap.Text = "Account Map";
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 24;
            this.gMapControl1.MinZoom = 1;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(788, 420);
            this.gMapControl1.TabIndex = 13;
            this.gMapControl1.Zoom = 2D;
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.cbkEnabled);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(1, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(794, 426);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
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
            this.fastObjectListViewLogs.TabIndex = 4;
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
            // AccountFeederUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlAccountFeeder);
            this.Name = "AccountFeederUserControl";
            this.Size = new System.Drawing.Size(796, 458);
            this.tabControlAccountFeeder.ResumeLayout(false);
            this.tpAccountMap.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderlessTabControl tabControlAccountFeeder;
        private BorderlessTabPage tpAccountMap;
        private BorderlessTabPage tpLogs;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private BorderlessTabPage tpSettings;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnDate;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnExceptionMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnStackTrace;
    }
}
