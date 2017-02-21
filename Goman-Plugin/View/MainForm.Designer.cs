using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.Modules.PokemonManager;

namespace Goman_Plugin.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new Goman_Plugin.View.BorderlessTabControl();
            this.tpCaptcha = new System.Windows.Forms.TabPage();
            this.captchaUserControl1 = new Goman_Plugin.Modules.Captcha.CaptchaUserControl();
            this.tpPokemonFeeder = new System.Windows.Forms.TabPage();
            this.pokemonFeederUserControl1 = new Goman_Plugin.Modules.PokemonFeeder.PokemonFeederUserControl();
            this.tpAccountFeeder = new System.Windows.Forms.TabPage();
            this.accountFeederUserControl1 = new Goman_Plugin.Modules.AccountFeeder.AccountFeederUserControl();
            this.tpGlobalSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.numericUpDownMaximumLogs = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumLogs = new System.Windows.Forms.Label();
            this.cbkSaveLogs = new System.Windows.Forms.CheckBox();
            this.cbkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tpPokemonManager = new System.Windows.Forms.TabPage();
            this.pokemonManagerUserControl1 = new Goman_Plugin.Modules.PokemonManager.PokemonManagerUserControl();
            this.statusStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tpCaptcha.SuspendLayout();
            this.tpPokemonFeeder.SuspendLayout();
            this.tpAccountFeeder.SuspendLayout();
            this.tpGlobalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).BeginInit();
            this.tpPokemonManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1118, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.LinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(193, 17);
            this.toolStripStatusLabel1.Tag = "";
            this.toolStripStatusLabel1.Text = "Cheap Pokemon Go Proxy Services!";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tpCaptcha);
            this.tabControlMain.Controls.Add(this.tpPokemonManager);
            this.tabControlMain.Controls.Add(this.tpPokemonFeeder);
            this.tabControlMain.Controls.Add(this.tpAccountFeeder);
            this.tabControlMain.Controls.Add(this.tpGlobalSettings);
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 115);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1118, 302);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpCaptcha
            // 
            this.tpCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpCaptcha.Controls.Add(this.captchaUserControl1);
            this.tpCaptcha.ForeColor = System.Drawing.Color.LightGray;
            this.tpCaptcha.Location = new System.Drawing.Point(116, 1);
            this.tpCaptcha.Name = "tpCaptcha";
            this.tpCaptcha.Size = new System.Drawing.Size(1001, 300);
            this.tpCaptcha.TabIndex = 0;
            this.tpCaptcha.Text = "Captcha";
            // 
            // captchaUserControl1
            // 
            this.captchaUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captchaUserControl1.Location = new System.Drawing.Point(0, 0);
            this.captchaUserControl1.Name = "captchaUserControl1";
            this.captchaUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.captchaUserControl1.TabIndex = 0;
            // 
            // tpPokemonFeeder
            // 
            this.tpPokemonFeeder.Controls.Add(this.pokemonFeederUserControl1);
            this.tpPokemonFeeder.Location = new System.Drawing.Point(116, 1);
            this.tpPokemonFeeder.Name = "tpPokemonFeeder";
            this.tpPokemonFeeder.Size = new System.Drawing.Size(1001, 300);
            this.tpPokemonFeeder.TabIndex = 2;
            this.tpPokemonFeeder.Text = "Pokemon Feeder";
            this.tpPokemonFeeder.UseVisualStyleBackColor = true;
            // 
            // pokemonFeederUserControl1
            // 
            this.pokemonFeederUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pokemonFeederUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonFeederUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonFeederUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pokemonFeederUserControl1.Name = "pokemonFeederUserControl1";
            this.pokemonFeederUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.pokemonFeederUserControl1.TabIndex = 0;
            // 
            // tpAccountFeeder
            // 
            this.tpAccountFeeder.Controls.Add(this.accountFeederUserControl1);
            this.tpAccountFeeder.Location = new System.Drawing.Point(116, 1);
            this.tpAccountFeeder.Name = "tpAccountFeeder";
            this.tpAccountFeeder.Size = new System.Drawing.Size(1001, 300);
            this.tpAccountFeeder.TabIndex = 3;
            this.tpAccountFeeder.Text = "Account Feeder";
            this.tpAccountFeeder.UseVisualStyleBackColor = true;
            // 
            // accountFeederUserControl1
            // 
            this.accountFeederUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.accountFeederUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountFeederUserControl1.Location = new System.Drawing.Point(0, 0);
            this.accountFeederUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accountFeederUserControl1.Name = "accountFeederUserControl1";
            this.accountFeederUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.accountFeederUserControl1.TabIndex = 0;
            // 
            // tpGlobalSettings
            // 
            this.tpGlobalSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpGlobalSettings.Controls.Add(this.numericUpDownMaximumLogs);
            this.tpGlobalSettings.Controls.Add(this.labelMaximumLogs);
            this.tpGlobalSettings.Controls.Add(this.cbkSaveLogs);
            this.tpGlobalSettings.Controls.Add(this.cbkAutoUpdate);
            this.tpGlobalSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpGlobalSettings.Location = new System.Drawing.Point(116, 1);
            this.tpGlobalSettings.Name = "tpGlobalSettings";
            this.tpGlobalSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpGlobalSettings.Size = new System.Drawing.Size(1001, 300);
            this.tpGlobalSettings.TabIndex = 1;
            this.tpGlobalSettings.Text = "Settings";
            // 
            // numericUpDownMaximumLogs
            // 
            this.numericUpDownMaximumLogs.Location = new System.Drawing.Point(6, 52);
            this.numericUpDownMaximumLogs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.Name = "numericUpDownMaximumLogs";
            this.numericUpDownMaximumLogs.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownMaximumLogs.TabIndex = 25;
            this.numericUpDownMaximumLogs.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.ValueChanged += new System.EventHandler(this.numericUpDownMaximumLogs_ValueChanged);
            // 
            // labelMaximumLogs
            // 
            this.labelMaximumLogs.AutoSize = true;
            this.labelMaximumLogs.Location = new System.Drawing.Point(66, 59);
            this.labelMaximumLogs.Name = "labelMaximumLogs";
            this.labelMaximumLogs.Size = new System.Drawing.Size(77, 13);
            this.labelMaximumLogs.TabIndex = 24;
            this.labelMaximumLogs.Text = "Maximum Logs";
            // 
            // cbkSaveLogs
            // 
            this.cbkSaveLogs.AutoSize = true;
            this.cbkSaveLogs.Checked = true;
            this.cbkSaveLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkSaveLogs.Location = new System.Drawing.Point(6, 29);
            this.cbkSaveLogs.Name = "cbkSaveLogs";
            this.cbkSaveLogs.Size = new System.Drawing.Size(77, 17);
            this.cbkSaveLogs.TabIndex = 22;
            this.cbkSaveLogs.Text = "Save Logs";
            this.cbkSaveLogs.UseVisualStyleBackColor = true;
            this.cbkSaveLogs.CheckedChanged += new System.EventHandler(this.cbkSaveLogs_CheckedChanged);
            // 
            // cbkAutoUpdate
            // 
            this.cbkAutoUpdate.AutoSize = true;
            this.cbkAutoUpdate.Checked = true;
            this.cbkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkAutoUpdate.Location = new System.Drawing.Point(6, 6);
            this.cbkAutoUpdate.Name = "cbkAutoUpdate";
            this.cbkAutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.cbkAutoUpdate.TabIndex = 21;
            this.cbkAutoUpdate.Text = "Auto Update";
            this.cbkAutoUpdate.UseVisualStyleBackColor = true;
            this.cbkAutoUpdate.CheckedChanged += new System.EventHandler(this.ckAutoUpdate_CheckedChanged);
            // 
            // tpPokemonManager
            // 
            this.tpPokemonManager.Controls.Add(this.pokemonManagerUserControl1);
            this.tpPokemonManager.Location = new System.Drawing.Point(116, 1);
            this.tpPokemonManager.Name = "tpPokemonManager";
            this.tpPokemonManager.Size = new System.Drawing.Size(1001, 300);
            this.tpPokemonManager.TabIndex = 4;
            this.tpPokemonManager.Text = "Pokemon Manager";
            this.tpPokemonManager.UseVisualStyleBackColor = true;
            // 
            // pokemonManagerUserControl1
            // 
            this.pokemonManagerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonManagerUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonManagerUserControl1.Name = "pokemonManagerUserControl1";
            this.pokemonManagerUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.pokemonManagerUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1118, 327);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GoMan Plugin";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tpCaptcha.ResumeLayout(false);
            this.tpPokemonFeeder.ResumeLayout(false);
            this.tpAccountFeeder.ResumeLayout(false);
            this.tpGlobalSettings.ResumeLayout(false);
            this.tpGlobalSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).EndInit();
            this.tpPokemonManager.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderlessTabControl tabControlMain;
        private System.Windows.Forms.TabPage tpCaptcha;
        private BorderlessTabPage tpGlobalSettings;
        private System.Windows.Forms.CheckBox cbkAutoUpdate;
        private System.Windows.Forms.CheckBox cbkSaveLogs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tpPokemonFeeder;
        private System.Windows.Forms.TabPage tpAccountFeeder;
        private PokemonFeederUserControl pokemonFeederUserControl1;
        private Modules.AccountFeeder.AccountFeederUserControl accountFeederUserControl1;
        private Modules.Captcha.CaptchaUserControl captchaUserControl1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaximumLogs;
        private System.Windows.Forms.Label labelMaximumLogs;
        private System.Windows.Forms.TabPage tpPokemonManager;
        private PokemonManagerUserControl pokemonManagerUserControl1;
    }
}