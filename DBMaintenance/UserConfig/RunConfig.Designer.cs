namespace UserConfig
{
    partial class RunConfig
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.logDirectoryLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.updateStatsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timeoutComboBox = new System.Windows.Forms.ComboBox();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fillFactorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.highComboBox = new System.Windows.Forms.ComboBox();
            this.mediumComboBox = new System.Windows.Forms.ComboBox();
            this.lowCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.minPageCntTextBox = new System.Windows.Forms.TextBox();
            this.execTimeoutLabel = new System.Windows.Forms.Label();
            this.minPageCountLabel = new System.Windows.Forms.Label();
            this.frag2TextBox = new System.Windows.Forms.TextBox();
            this.frag1TextBox = new System.Windows.Forms.TextBox();
            this.frag1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.AutoSize = true;
            this.scheduleLabel.Location = new System.Drawing.Point(113, 326);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(110, 13);
            this.scheduleLabel.TabIndex = 29;
            this.scheduleLabel.Text = "Scheduling Paramters";
            this.scheduleLabel.Visible = false;
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(318, 353);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(128, 23);
            this.scheduleButton.TabIndex = 28;
            this.scheduleButton.Text = "Schedule &Maintenance";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Visible = false;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(237, 296);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(103, 23);
            this.browseButton.TabIndex = 27;
            this.browseButton.Text = "Change &Directory";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // logDirectoryLabel
            // 
            this.logDirectoryLabel.AutoSize = true;
            this.logDirectoryLabel.Location = new System.Drawing.Point(249, 280);
            this.logDirectoryLabel.Name = "logDirectoryLabel";
            this.logDirectoryLabel.Size = new System.Drawing.Size(35, 13);
            this.logDirectoryLabel.TabIndex = 10;
            this.logDirectoryLabel.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Log File Directory";
            // 
            // updateStatsComboBox
            // 
            this.updateStatsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateStatsComboBox.FormattingEnabled = true;
            this.updateStatsComboBox.Items.AddRange(new object[] {
            "All (Complete Statistics)",
            "Only Column Statistics",
            "Only Index Statistics"});
            this.updateStatsComboBox.Location = new System.Drawing.Point(250, 237);
            this.updateStatsComboBox.Name = "updateStatsComboBox";
            this.updateStatsComboBox.Size = new System.Drawing.Size(178, 21);
            this.updateStatsComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Update Statistics";
            // 
            // timeoutComboBox
            // 
            this.timeoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeoutComboBox.FormattingEnabled = true;
            this.timeoutComboBox.Location = new System.Drawing.Point(252, 175);
            this.timeoutComboBox.Name = "timeoutComboBox";
            this.timeoutComboBox.Size = new System.Drawing.Size(178, 21);
            this.timeoutComboBox.TabIndex = 7;
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(251, 16);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(178, 21);
            this.databaseComboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Database";
            // 
            // fillFactorTextBox
            // 
            this.fillFactorTextBox.Location = new System.Drawing.Point(252, 202);
            this.fillFactorTextBox.MaxLength = 3;
            this.fillFactorTextBox.Name = "fillFactorTextBox";
            this.fillFactorTextBox.Size = new System.Drawing.Size(129, 20);
            this.fillFactorTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fill Factor";
            // 
            // highComboBox
            // 
            this.highComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.highComboBox.FormattingEnabled = true;
            this.highComboBox.Items.AddRange(new object[] {
            "SEQUENCE_3",
            "-----------------------",
            "NO_OPERATION",
            "INDEX_REORGANIZE",
            "INDEX_REBUILD_ONLINE",
            "INDEX_REBUILD_OFFLINE"});
            this.highComboBox.Location = new System.Drawing.Point(250, 123);
            this.highComboBox.Name = "highComboBox";
            this.highComboBox.Size = new System.Drawing.Size(178, 21);
            this.highComboBox.TabIndex = 5;
            // 
            // mediumComboBox
            // 
            this.mediumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mediumComboBox.FormattingEnabled = true;
            this.mediumComboBox.Items.AddRange(new object[] {
            "SEQUENCE_2",
            "-------------------",
            "NO_OPERATION",
            "INDEX_REORGANIZE",
            "INDEX_REBUILD_ONLINE",
            "INDEX_REBUILD_OFFLINE"});
            this.mediumComboBox.Location = new System.Drawing.Point(250, 96);
            this.mediumComboBox.Name = "mediumComboBox";
            this.mediumComboBox.Size = new System.Drawing.Size(178, 21);
            this.mediumComboBox.TabIndex = 4;
            // 
            // lowCombobox
            // 
            this.lowCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lowCombobox.FormattingEnabled = true;
            this.lowCombobox.Items.AddRange(new object[] {
            "SEQUENCE_1",
            "--------------",
            "NO_OPERATION",
            "INDEX_REORGANIZE",
            "INDEX_REBUILD_ONLINE",
            "INDEX_REBUILD_OFFLINE"});
            this.lowCombobox.Location = new System.Drawing.Point(250, 69);
            this.lowCombobox.Name = "lowCombobox";
            this.lowCombobox.Size = new System.Drawing.Size(178, 21);
            this.lowCombobox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Operation Sequence";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(163, 353);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(149, 23);
            this.goButton.TabIndex = 11;
            this.goButton.Text = "&Optimize Indexes";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // minPageCntTextBox
            // 
            this.minPageCntTextBox.Location = new System.Drawing.Point(251, 150);
            this.minPageCntTextBox.Name = "minPageCntTextBox";
            this.minPageCntTextBox.Size = new System.Drawing.Size(129, 20);
            this.minPageCntTextBox.TabIndex = 6;
            // 
            // execTimeoutLabel
            // 
            this.execTimeoutLabel.AutoSize = true;
            this.execTimeoutLabel.Location = new System.Drawing.Point(131, 178);
            this.execTimeoutLabel.Name = "execTimeoutLabel";
            this.execTimeoutLabel.Size = new System.Drawing.Size(95, 13);
            this.execTimeoutLabel.TabIndex = 9;
            this.execTimeoutLabel.Text = "Execution Timeout";
            // 
            // minPageCountLabel
            // 
            this.minPageCountLabel.AutoSize = true;
            this.minPageCountLabel.Location = new System.Drawing.Point(119, 153);
            this.minPageCountLabel.Name = "minPageCountLabel";
            this.minPageCountLabel.Size = new System.Drawing.Size(107, 13);
            this.minPageCountLabel.TabIndex = 8;
            this.minPageCountLabel.Text = "Minimum Page Count";
            // 
            // frag2TextBox
            // 
            this.frag2TextBox.Location = new System.Drawing.Point(309, 43);
            this.frag2TextBox.MaxLength = 3;
            this.frag2TextBox.Name = "frag2TextBox";
            this.frag2TextBox.Size = new System.Drawing.Size(55, 20);
            this.frag2TextBox.TabIndex = 2;
            // 
            // frag1TextBox
            // 
            this.frag1TextBox.Location = new System.Drawing.Point(251, 43);
            this.frag1TextBox.MaxLength = 3;
            this.frag1TextBox.Name = "frag1TextBox";
            this.frag1TextBox.Size = new System.Drawing.Size(52, 20);
            this.frag1TextBox.TabIndex = 1;
            // 
            // frag1Label
            // 
            this.frag1Label.AutoSize = true;
            this.frag1Label.Location = new System.Drawing.Point(117, 46);
            this.frag1Label.Name = "frag1Label";
            this.frag1Label.Size = new System.Drawing.Size(109, 13);
            this.frag1Label.TabIndex = 4;
            this.frag1Label.Text = "Fragmentation Range";
            // 
            // RunConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 390);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.logDirectoryLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateStatsComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timeoutComboBox);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fillFactorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.highComboBox);
            this.Controls.Add(this.mediumComboBox);
            this.Controls.Add(this.lowCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.minPageCntTextBox);
            this.Controls.Add(this.execTimeoutLabel);
            this.Controls.Add(this.minPageCountLabel);
            this.Controls.Add(this.frag2TextBox);
            this.Controls.Add(this.frag1TextBox);
            this.Controls.Add(this.frag1Label);
            this.Name = "RunConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup DB Maintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frag1Label;
        private System.Windows.Forms.TextBox frag1TextBox;
        private System.Windows.Forms.TextBox frag2TextBox;
        private System.Windows.Forms.Label minPageCountLabel;
        private System.Windows.Forms.Label execTimeoutLabel;
        private System.Windows.Forms.TextBox minPageCntTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lowCombobox;
        private System.Windows.Forms.ComboBox mediumComboBox;
        private System.Windows.Forms.ComboBox highComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fillFactorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.ComboBox timeoutComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox updateStatsComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label logDirectoryLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Label scheduleLabel;
    }
}