namespace UserConfig
{
    partial class BackupConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backupPathLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.verifyCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checksumCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.logBrowseButton = new System.Windows.Forms.Button();
            this.timeoutComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.logFileLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backupTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(289, 32);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(121, 21);
            this.databaseComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Backup Directory";
            // 
            // backupPathLabel
            // 
            this.backupPathLabel.AutoSize = true;
            this.backupPathLabel.Location = new System.Drawing.Point(286, 66);
            this.backupPathLabel.Name = "backupPathLabel";
            this.backupPathLabel.Size = new System.Drawing.Size(0, 13);
            this.backupPathLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Verify After Backup";
            // 
            // verifyCheckBox
            // 
            this.verifyCheckBox.AutoSize = true;
            this.verifyCheckBox.Location = new System.Drawing.Point(289, 162);
            this.verifyCheckBox.Name = "verifyCheckBox";
            this.verifyCheckBox.Size = new System.Drawing.Size(44, 17);
            this.verifyCheckBox.TabIndex = 7;
            this.verifyCheckBox.Text = "Yes";
            this.verifyCheckBox.UseVisualStyleBackColor = true;
            this.verifyCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Checksum Check";
            // 
            // checksumCheckBox
            // 
            this.checksumCheckBox.AutoSize = true;
            this.checksumCheckBox.Location = new System.Drawing.Point(289, 192);
            this.checksumCheckBox.Name = "checksumCheckBox";
            this.checksumCheckBox.Size = new System.Drawing.Size(44, 17);
            this.checksumCheckBox.TabIndex = 9;
            this.checksumCheckBox.Text = "Yes";
            this.checksumCheckBox.UseVisualStyleBackColor = true;
            this.checksumCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(289, 92);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 10;
            this.browseButton.Text = "Bro&wse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(153, 332);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(148, 23);
            this.goButton.TabIndex = 11;
            this.goButton.Text = "&Backup Now";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // logBrowseButton
            // 
            this.logBrowseButton.Location = new System.Drawing.Point(282, 266);
            this.logBrowseButton.Name = "logBrowseButton";
            this.logBrowseButton.Size = new System.Drawing.Size(73, 23);
            this.logBrowseButton.TabIndex = 12;
            this.logBrowseButton.Text = "&Change";
            this.logBrowseButton.UseVisualStyleBackColor = true;
            this.logBrowseButton.Click += new System.EventHandler(this.logBrowseButton_Click);
            // 
            // timeoutComboBox
            // 
            this.timeoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeoutComboBox.FormattingEnabled = true;
            this.timeoutComboBox.Location = new System.Drawing.Point(289, 217);
            this.timeoutComboBox.Name = "timeoutComboBox";
            this.timeoutComboBox.Size = new System.Drawing.Size(121, 21);
            this.timeoutComboBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Query Execution Timeout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Log File Path";
            // 
            // logFileLabel
            // 
            this.logFileLabel.AutoSize = true;
            this.logFileLabel.Location = new System.Drawing.Point(286, 250);
            this.logFileLabel.Name = "logFileLabel";
            this.logFileLabel.Size = new System.Drawing.Size(69, 13);
            this.logFileLabel.TabIndex = 16;
            this.logFileLabel.Text = "Log File Path";
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(307, 332);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(134, 23);
            this.scheduleButton.TabIndex = 17;
            this.scheduleButton.Text = "Schedule &Backup";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Visible = false;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.AutoSize = true;
            this.scheduleLabel.Location = new System.Drawing.Point(187, 305);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(69, 13);
            this.scheduleLabel.TabIndex = 18;
            this.scheduleLabel.Text = "Log File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Backup Type";
            // 
            // backupTypeComboBox
            // 
            this.backupTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backupTypeComboBox.Enabled = false;
            this.backupTypeComboBox.FormattingEnabled = true;
            this.backupTypeComboBox.Items.AddRange(new object[] {
            "Full Backup",
            "Differential Backup",
            "Log Backup"});
            this.backupTypeComboBox.Location = new System.Drawing.Point(289, 128);
            this.backupTypeComboBox.Name = "backupTypeComboBox";
            this.backupTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.backupTypeComboBox.TabIndex = 5;
            // 
            // BackupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 453);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.logFileLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timeoutComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.logBrowseButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.checksumCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.verifyCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backupTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backupPathLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.label1);
            this.Name = "BackupConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Backup Parameters";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label backupPathLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox verifyCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checksumCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button logBrowseButton;
        private System.Windows.Forms.ComboBox timeoutComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label logFileLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Label scheduleLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox backupTypeComboBox;
    }
}