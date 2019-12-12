using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DBHealthCheck.Config;
using DBHealthCheck.Utils;
using UserConfig.Utils;

namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class IntegrityConfig : BaseForm
    {
        private RunInterval interval = RunInterval.None;
        private string additionalInfo = "";

        /// <summary>
        /// 
        /// </summary>
        public IntegrityConfig()
        {
            InitializeComponent();

            InitializeDatabaseComboBox(databaseComboBox);

            InitializeTimeoutComboBox(timeoutComboBox);

            LogDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fileLabel.Text = LogDirectory;

            SystemConfig systemConfig = SystemConfig.GetInstance();
            if (systemConfig.AutomaticScheduling)
                scheduleButton.Visible = true;

            IntegrityCheckConfig config = IntegrityCheckConfig.GetInstance();
            if (!String.IsNullOrEmpty(config.DatabaseName))
            {
                int index = databaseComboBox.FindString(config.DatabaseName);
                if (index != -1)
                    databaseComboBox.SelectedIndex = index;
            }
            physicalCheckBox.Checked = config.PhysicalOnly.Equals("Y") ? true : false;
            GetCheckBoxText(physicalCheckBox);

            indexesCheckBox.Checked = config.ExcludeIndexes.Equals("Y") ? true : false;
            GetCheckBoxText(indexesCheckBox);

            extendedChecksCheckBox.Checked = config.ExtendedLogicalChecks.Equals("Y") ? true : false;
            GetCheckBoxText(extendedChecksCheckBox);

            interval = config.RunInterval;
            additionalInfo = config.AdditionalInfo;

            if (!String.IsNullOrEmpty(config.CheckCommand))
            {
                int index = commandComboBox.FindString(GetMappedCommand(config.CheckCommand));
                if (index != -1)
                    commandComboBox.SelectedIndex = index;
            }

            commandComboBox.SelectedIndex = commandComboBox.FindString(GetMappedCommand(config.CheckCommand));
            
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            GetCheckBoxText(sender as CheckBox);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            int timeout = GetTimeOutValue(timeoutComboBox);

            if (okButton.Text == "Save Scheduling &Settings")
            {
                // save the scheduling configurations
                IntegrityCheckConfig config = IntegrityCheckConfig.GetInstance();
                string operationName = "Integrity Check Config";
                bool success = SaveConfigurations(config) && ScheduleOperation(operationName, config, @"-c IntegrityCheckConfig");
                if (success) // All Validation passed.
                {
                    MessageBox.Show("Configuration Saved Successfully. " + operationName + " successfully " +
                        GetDisplaySchedule(config.RunInterval, config.AdditionalInfo),
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    scheduleLabel.Text = GetDisplaySchedule(config.RunInterval, config.AdditionalInfo) 
                        + ". Next Execution @ " + config.NextExecution;
                }
            }
            else
            {
                bool success = SubmitForm(ref builder, "[DatabaseIntegrityCheck]", timeout);
                if (success)
                {
                    MessageBox.Show("Command Executed Successfully. Please check the log file"
                        + "for more details.", "Print Commands output",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(builder.ToString(), "Validation Errors",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
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

            #region Database Combo Box
            if (databaseComboBox.SelectedIndex < 0)
            {
                builder.Append("ERR: Please select a Database Name");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values[Constants.DATABASE_NAME] = databaseComboBox.Items[databaseComboBox.SelectedIndex].ToString();
            }
            #endregion

            #region Command Combo Box
            if (commandComboBox.SelectedIndex < 0)
            {
                builder.Append("ERR: Please select a Valid Command");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values[Constants.CHECK_COMMAND] = GetMappedCommand(commandComboBox.Items[commandComboBox.SelectedIndex].ToString());
            }
            #endregion

            if (physicalCheckBox.Checked && extendedChecksCheckBox.Checked)
                builder.AppendLine("ERR: Physical Only and Extended Logical Checks options cannot be selected at the same time");

            values[Constants.PHYSICAL_ONLY] = physicalCheckBox.Checked ? "Y" : "N";
            values[Constants.EXTENDED_LOGICAL_CHECKS] = extendedChecksCheckBox.Checked ? "Y" : "N";
            values[Constants.EXCLUDE_INDEXES] = indexesCheckBox.Checked ? "Y" : "N";
            values[Constants.EXECUTION_TIMEOUT] = GetTimeOutValue(timeoutComboBox).ToString();

            #region Scheduling Settings
            if (okButton.Text == "Save Scheduling &Settings")
            {
                // no validation required here as all the settings
                // are validated in the popup windows
                values[Constants.RUN_INTERVAL] = interval.ToString();
                values[Constants.ADDITIONAL_INFO] = additionalInfo.Trim();
            }
            #endregion

            return values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        protected override List<SqlParameter> GetSqlParameters(IDictionary<string, string> values)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Databases", values[Constants.DATABASE_NAME]));
            parameters.Add(new SqlParameter("@CheckCommands", values[Constants.CHECK_COMMAND]));
            parameters.Add(new SqlParameter("@PhysicalOnly", values[Constants.PHYSICAL_ONLY]));
            parameters.Add(new SqlParameter("@ExtendedLogicalChecks", values[Constants.EXTENDED_LOGICAL_CHECKS]));
            parameters.Add(new SqlParameter("@NoIndex", values[Constants.EXCLUDE_INDEXES]));

            return parameters;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fileLabel.Text = folderBrowserDialog1.SelectedPath;
                LogDirectory = fileLabel.Text;
            }
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ScheduleDialog.ShowDialog("Scheduling Parameters", ref interval, ref additionalInfo);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string message = "Please Click the Save Button to store the Settings";
                okButton.Text = "Save Scheduling &Settings";
                okButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                MessageBox.Show(message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                scheduleLabel.Text = GetDisplaySchedule(interval, additionalInfo);
            }
        }
    }
}
