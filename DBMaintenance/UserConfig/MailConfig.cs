using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DBHealthCheck.Config;
using DBHealthCheck.Utils;
using DBManager.Utils;
using UserConfig.Utils;

namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MailConfig : BaseForm
    {
        private SystemConfig config;
        /// <summary>
        /// 
        /// </summary>
        public MailConfig()
        {
            InitializeComponent();

            config = SystemConfig.GetInstance();

            fromTextBox.Text = config.EmailFrom;
            displayNameTextBox.Text = config.DisplayName;
            mailServerTextBox.Text = config.MailServer;
            portTextBox.Text = config.MailServerPort.ToString();
            userNameTextBox.Text = config.UserName;
            passwordTextBox.Text = config.Password;
            string mailTo = config.MailTo;
            string[] parts = mailTo.Split(',');
            foreach (string part in parts)
            {
                if (!String.IsNullOrEmpty(part))
                    mailToListBox.Items.Add(part);
            }

            if (String.IsNullOrEmpty(config.MailServer) || String.IsNullOrEmpty(config.EmailFrom))
            {
                // config is not saved yet.
                testButton.Visible = false;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(config.MailServer))
                {
                    MessageBox.Show("Please save the configuration before sending the mail.", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                MailUtility utils = new MailUtility(config);
                utils.SendMail(config.TestMailText, "DB Health Check: Test Email Settings");
                MessageBox.Show("Test Mail Sent successfully. Please check both your inbox and spam folders",
                    "Mail Sending Successful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex.Message + Environment.NewLine + ex.StackTrace);
                MessageBox.Show("Mail sending failed due to " + ex.Message,
                    "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            bool success = SubmitForm(ref builder);
            if (success)
            {
                config.DisplayName = displayNameTextBox.Text.Trim();
                config.EmailFrom = fromTextBox.Text.Trim();
                config.MailServer = mailServerTextBox.Text.Trim();
                config.MailServerPort = Convert.ToInt32(portTextBox.Text.Trim());
                config.Password = passwordTextBox.Text.Trim();
                config.UserName = userNameTextBox.Text.Trim();

                string mailTo = "";
                foreach (object obj in mailToListBox.Items)
                {
                    if (!String.IsNullOrEmpty(obj.ToString()))
                        mailTo += obj.ToString() + ",";
                }
                mailTo = mailTo.Substring(0, mailTo.Length - 1);
                config.MailTo = mailTo;
                testButton.Visible = true;

                MessageBox.Show("Mail Alerts Parameters Saved Successfully. ",
                    "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override IDictionary<string, string> ValidateInput(ref StringBuilder builder)
        {
            IDictionary<string, string> values = new Dictionary<string, string>();

            #region Display Name
            if (String.IsNullOrEmpty(displayNameTextBox.Text))
                builder.AppendLine("ERR: Display Name field is required");
            else
                values["DISPLAY_NAME"] = displayNameTextBox.Text;
            #endregion

            #region Email
            if (String.IsNullOrEmpty(fromTextBox.Text))
                builder.AppendLine("ERR: Please enter a from email address");
            else
            {
                bool valid = IsValidEmail(fromTextBox.Text);
                if (valid)
                    values["EMAIL_FROM"] = fromTextBox.Text.Trim();
                else
                    builder.AppendLine("ERR: Please enter a valid email address");
            }
            #endregion

            #region Mail Server
            if (String.IsNullOrEmpty(displayNameTextBox.Text))
                builder.AppendLine("ERR: Mail Server is required");
            else
                values["MAIL_SERVER"] = mailServerTextBox.Text;
            #endregion

            #region Mail Server Port
            int port;
            bool success = Int32.TryParse(portTextBox.Text, out port);
            if (!success)
            {
                if (String.IsNullOrEmpty(portTextBox.Text))
                    builder.AppendLine("ERR: Port Number is required");
                else
                    builder.AppendLine("ERR: Please enter a numeric value for Port Number");
            }
            else if (port < 0)
            {
                builder.AppendLine("ERR: Please enter a positive value for Port Number");
            }
            else
                values["MAIL_SERVER_PORT"] = portTextBox.Text;
            #endregion

            #region User Name
            if (String.IsNullOrEmpty(userNameTextBox.Text))
                builder.AppendLine("ERR: User Name is required");
            else
                values["USER_NAME"] = userNameTextBox.Text;
            #endregion

            #region Password
            if (String.IsNullOrEmpty(passwordTextBox.Text))
                builder.AppendLine("ERR: Password is required");
            else
                values["PASSWORD"] = passwordTextBox.Text;
            #endregion

            #region Mail To Settings
            if (mailToListBox.Items.Count <= 0 && !IsValidEmail(mailToTextBox.Text))
            {
                builder.AppendLine("ERR: Email address is required. Please enter a valid email address.");
            }
            else if ((mailToListBox.Items.Count == 0 && IsValidEmail(mailToTextBox.Text)) 
                || mailToListBox.Items.Count > 0)
            {
                mailToListBox.Items.Add(mailToTextBox.Text.Trim());
                string mailTo = "";
                foreach (object obj in mailToListBox.Items)
                    mailTo += obj.ToString() + ",";
                values["MAIL_TO"] = mailTo;
            }
            #endregion

            return values;
        }

        private void mailToButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mailToTextBox.Text.Trim())
                || !IsValidEmail(mailToTextBox.Text))
            {
                MessageBox.Show("Valid Email Address is required", "Validation Errors",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            string email = mailToTextBox.Text.Trim();
            if (!mailToListBox.Items.Contains(email))
                mailToListBox.Items.Add(email);
            mailToTextBox.Text = "";
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (mailToListBox.SelectedItems == null || mailToListBox.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a mail Id to remove", "Validation Errors", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            List<object> itemsToRemove = new List<object>();
            foreach (object obj in mailToListBox.SelectedItems)
                itemsToRemove.Add(obj);

            foreach (object obj in itemsToRemove)
                mailToListBox.Items.Remove(obj);
        }
    }
}
