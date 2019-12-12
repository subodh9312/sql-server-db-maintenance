namespace UserConfig
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.runScheduleParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseIntegrityCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentialBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableMailAlertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mailSetupParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticSchedulingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.databaseCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolStripMenuItem1,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(643, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runScheduleParametersToolStripMenuItem,
            this.databaseIntegrityCheckToolStripMenuItem,
            this.databaseBackupToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(77, 20);
            this.fileMenu.Text = "&Operations";
            // 
            // runScheduleParametersToolStripMenuItem
            // 
            this.runScheduleParametersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runScheduleParametersToolStripMenuItem.Image")));
            this.runScheduleParametersToolStripMenuItem.Name = "runScheduleParametersToolStripMenuItem";
            this.runScheduleParametersToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.runScheduleParametersToolStripMenuItem.Text = "Update &Statistics";
            this.runScheduleParametersToolStripMenuItem.Click += new System.EventHandler(this.runScheduleParametersToolStripMenuItem_Click);
            // 
            // databaseIntegrityCheckToolStripMenuItem
            // 
            this.databaseIntegrityCheckToolStripMenuItem.Name = "databaseIntegrityCheckToolStripMenuItem";
            this.databaseIntegrityCheckToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.databaseIntegrityCheckToolStripMenuItem.Text = "Database &Integrity Check";
            this.databaseIntegrityCheckToolStripMenuItem.Click += new System.EventHandler(this.databaseIntegrityCheckToolStripMenuItem_Click);
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullBackupToolStripMenuItem,
            this.differentialBackupToolStripMenuItem,
            this.logBackupToolStripMenuItem});
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.databaseBackupToolStripMenuItem.Text = "&Backup Database";
            // 
            // fullBackupToolStripMenuItem
            // 
            this.fullBackupToolStripMenuItem.Name = "fullBackupToolStripMenuItem";
            this.fullBackupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.fullBackupToolStripMenuItem.Text = "F&ull Backup";
            this.fullBackupToolStripMenuItem.Click += new System.EventHandler(this.fullBackupToolStripMenuItem_Click);
            // 
            // differentialBackupToolStripMenuItem
            // 
            this.differentialBackupToolStripMenuItem.Name = "differentialBackupToolStripMenuItem";
            this.differentialBackupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.differentialBackupToolStripMenuItem.Text = "&Differential Backup";
            this.differentialBackupToolStripMenuItem.Click += new System.EventHandler(this.differentialBackupToolStripMenuItem_Click);
            // 
            // logBackupToolStripMenuItem
            // 
            this.logBackupToolStripMenuItem.Name = "logBackupToolStripMenuItem";
            this.logBackupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logBackupToolStripMenuItem.Text = "&Log Backup";
            this.logBackupToolStripMenuItem.Click += new System.EventHandler(this.logBackupToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionParametersToolStripMenuItem,
            this.toolStripSeparator3,
            this.reportsToolStripMenuItem,
            this.automaticSchedulingToolStripMenuItem,
            this.databaseCompressionToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 20);
            this.toolStripMenuItem1.Text = "&Configuration";
            // 
            // connectionParametersToolStripMenuItem
            // 
            this.connectionParametersToolStripMenuItem.Name = "connectionParametersToolStripMenuItem";
            this.connectionParametersToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.connectionParametersToolStripMenuItem.Text = "C&onnection Parameters";
            this.connectionParametersToolStripMenuItem.Click += new System.EventHandler(this.connectionParametersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableMailAlertsToolStripMenuItem,
            this.toolStripSeparator1,
            this.mailSetupParametersToolStripMenuItem});
            this.reportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportsToolStripMenuItem.Image")));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.reportsToolStripMenuItem.Text = "Mail &Alerts";
            // 
            // enableMailAlertsToolStripMenuItem
            // 
            this.enableMailAlertsToolStripMenuItem.Name = "enableMailAlertsToolStripMenuItem";
            this.enableMailAlertsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.enableMailAlertsToolStripMenuItem.Text = "Mail Alerts";
            this.enableMailAlertsToolStripMenuItem.Click += new System.EventHandler(this.enableMailAlertsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // mailSetupParametersToolStripMenuItem
            // 
            this.mailSetupParametersToolStripMenuItem.Name = "mailSetupParametersToolStripMenuItem";
            this.mailSetupParametersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.mailSetupParametersToolStripMenuItem.Text = "Mail &Setup Parameters";
            this.mailSetupParametersToolStripMenuItem.Click += new System.EventHandler(this.mailSetupParametersToolStripMenuItem_Click);
            // 
            // automaticSchedulingToolStripMenuItem
            // 
            this.automaticSchedulingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedulingToolStripMenuItem});
            this.automaticSchedulingToolStripMenuItem.Name = "automaticSchedulingToolStripMenuItem";
            this.automaticSchedulingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.automaticSchedulingToolStripMenuItem.Text = "Automatic &Scheduling";
            // 
            // schedulingToolStripMenuItem
            // 
            this.schedulingToolStripMenuItem.Name = "schedulingToolStripMenuItem";
            this.schedulingToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.schedulingToolStripMenuItem.Text = "&Scheduling";
            this.schedulingToolStripMenuItem.Click += new System.EventHandler(this.schedulingToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(196, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutToolStripMenuItem.Text = "&About DB Health Check";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // databaseCompressionToolStripMenuItem
            // 
            this.databaseCompressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressBackupToolStripMenuItem});
            this.databaseCompressionToolStripMenuItem.Name = "databaseCompressionToolStripMenuItem";
            this.databaseCompressionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.databaseCompressionToolStripMenuItem.Text = "Database &Compression";
            // 
            // compressBackupToolStripMenuItem
            // 
            this.compressBackupToolStripMenuItem.Name = "compressBackupToolStripMenuItem";
            this.compressBackupToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.compressBackupToolStripMenuItem.Text = "Compress &Backup";
            this.compressBackupToolStripMenuItem.Click += new System.EventHandler(this.compressBackupToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(643, 453);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem runScheduleParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseIntegrityCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectionParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableMailAlertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mailSetupParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem automaticSchedulingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentialBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseCompressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressBackupToolStripMenuItem;
    }
}



