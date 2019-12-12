namespace UserConfig
{
    partial class IntegrityConfig
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
            this.scheduleButton = new System.Windows.Forms.Button();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.timeoutComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.extendedChecksCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.indexesCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.physicalCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.commandComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(307, 309);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(110, 23);
            this.scheduleButton.TabIndex = 18;
            this.scheduleButton.Text = "Schedule &Check";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Visible = false;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.AutoSize = true;
            this.scheduleLabel.Location = new System.Drawing.Point(131, 281);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(0, 13);
            this.scheduleLabel.TabIndex = 17;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(254, 223);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(0, 13);
            this.fileLabel.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Log File";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(257, 242);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 13;
            this.browseButton.Text = "Bro&wse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // timeoutComboBox
            // 
            this.timeoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeoutComboBox.FormattingEnabled = true;
            this.timeoutComboBox.Location = new System.Drawing.Point(257, 182);
            this.timeoutComboBox.Name = "timeoutComboBox";
            this.timeoutComboBox.Size = new System.Drawing.Size(208, 21);
            this.timeoutComboBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "QueryExecutionTimeout";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(156, 309);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(145, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "&Run Check Now";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // extendedChecksCheckBox
            // 
            this.extendedChecksCheckBox.AutoSize = true;
            this.extendedChecksCheckBox.Location = new System.Drawing.Point(257, 159);
            this.extendedChecksCheckBox.Name = "extendedChecksCheckBox";
            this.extendedChecksCheckBox.Size = new System.Drawing.Size(44, 17);
            this.extendedChecksCheckBox.TabIndex = 9;
            this.extendedChecksCheckBox.Text = "Yes";
            this.extendedChecksCheckBox.UseVisualStyleBackColor = true;
            this.extendedChecksCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Extended Logical Checks";
            // 
            // indexesCheckBox
            // 
            this.indexesCheckBox.AutoSize = true;
            this.indexesCheckBox.Location = new System.Drawing.Point(257, 129);
            this.indexesCheckBox.Name = "indexesCheckBox";
            this.indexesCheckBox.Size = new System.Drawing.Size(44, 17);
            this.indexesCheckBox.TabIndex = 7;
            this.indexesCheckBox.Text = "Yes";
            this.indexesCheckBox.UseVisualStyleBackColor = true;
            this.indexesCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exclude Indexes";
            // 
            // physicalCheckBox
            // 
            this.physicalCheckBox.AutoSize = true;
            this.physicalCheckBox.Location = new System.Drawing.Point(257, 100);
            this.physicalCheckBox.Name = "physicalCheckBox";
            this.physicalCheckBox.Size = new System.Drawing.Size(44, 17);
            this.physicalCheckBox.TabIndex = 5;
            this.physicalCheckBox.Text = "Yes";
            this.physicalCheckBox.UseVisualStyleBackColor = true;
            this.physicalCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Physical Only";
            // 
            // commandComboBox
            // 
            this.commandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commandComboBox.FormattingEnabled = true;
            this.commandComboBox.Items.AddRange(new object[] {
            "Check logical and physical integrity",
            "Check allocation and structural integrity",
            "Check for catalog consistency",
            "Check consistency of disk space allocation"});
            this.commandComboBox.Location = new System.Drawing.Point(257, 68);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(208, 21);
            this.commandComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check Command";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(257, 41);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(208, 21);
            this.databaseComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database";
            // 
            // IntegrityConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 390);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.timeoutComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.extendedChecksCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.indexesCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.physicalCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.label1);
            this.Name = "IntegrityConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DB Integrity Check";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox commandComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox physicalCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox indexesCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox extendedChecksCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox timeoutComboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label scheduleLabel;
        private System.Windows.Forms.Button scheduleButton;
    }
}