namespace UserConfig
{
    partial class ScheduleDialog
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
            this.intervalComboBox = new System.Windows.Forms.ComboBox();
            this.addInfoLabel = new System.Windows.Forms.Label();
            this.addInfoDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addInfoComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Run interval";
            // 
            // intervalComboBox
            // 
            this.intervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalComboBox.FormattingEnabled = true;
            this.intervalComboBox.Location = new System.Drawing.Point(210, 12);
            this.intervalComboBox.Name = "intervalComboBox";
            this.intervalComboBox.Size = new System.Drawing.Size(121, 21);
            this.intervalComboBox.TabIndex = 1;
            this.intervalComboBox.SelectedIndexChanged += new System.EventHandler(this.intervalComboBox_SelectedIndexChanged);
            // 
            // addInfoLabel
            // 
            this.addInfoLabel.AutoSize = true;
            this.addInfoLabel.Location = new System.Drawing.Point(86, 45);
            this.addInfoLabel.Name = "addInfoLabel";
            this.addInfoLabel.Size = new System.Drawing.Size(35, 13);
            this.addInfoLabel.TabIndex = 2;
            this.addInfoLabel.Text = "label2";
            this.addInfoLabel.Visible = false;
            // 
            // addInfoDateTimePicker1
            // 
            this.addInfoDateTimePicker1.Location = new System.Drawing.Point(210, 39);
            this.addInfoDateTimePicker1.Name = "addInfoDateTimePicker1";
            this.addInfoDateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.addInfoDateTimePicker1.TabIndex = 3;
            this.addInfoDateTimePicker1.Visible = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(175, 92);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(256, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addInfoComboBox
            // 
            this.addInfoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addInfoComboBox.FormattingEnabled = true;
            this.addInfoComboBox.Location = new System.Drawing.Point(210, 65);
            this.addInfoComboBox.Name = "addInfoComboBox";
            this.addInfoComboBox.Size = new System.Drawing.Size(121, 21);
            this.addInfoComboBox.TabIndex = 6;
            this.addInfoComboBox.Visible = false;
            // 
            // ScheduleDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(456, 130);
            this.ControlBox = false;
            this.Controls.Add(this.addInfoComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addInfoDateTimePicker1);
            this.Controls.Add(this.addInfoLabel);
            this.Controls.Add(this.intervalComboBox);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scheduling Parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox intervalComboBox;
        private System.Windows.Forms.Label addInfoLabel;
        private System.Windows.Forms.DateTimePicker addInfoDateTimePicker1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox addInfoComboBox;
    }
}