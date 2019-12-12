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
    public partial class BackupConfig : BaseForm
    {
        private string _backupType;
        private RunInterval interval = RunInterval.None;
        private string additionalInfo = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backupType"></param>
        public BackupConfig(string backupType)
        {
            this._backupType = backupType;

            InitializeComponent();

            folderBrowserDialog1.Description = "Select a Backup Directory";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;

            folderBrowserDialog1.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;

            InitializeDatabaseComboBox(databaseComboBox);
            InitializeTimeoutComboBox(timeoutComboBox);

            GetCheckBoxText(verifyCheckBox);
            GetCheckBoxText(checksumCheckBox);

            LogDirectory = AppDomain.CurrentDomain.BaseDirectory;
            logFileLabel.Text = LogDirectory;

            SystemConfig systenConfig = SystemConfig.GetInstance();
            if (systenConfig.AutomaticScheduling)
                scheduleButton.Visible = true;

            DoBackupConfig config = DoBackupConfig.GetInstance(_backupType);
            if (!String.IsNullOrEmpty(config.DatabaseName))
            {
                int index = databaseComboBox.FindString(config.DatabaseName);
                if (index != -1)
                    databaseComboBox.SelectedIndex = index;
            }

            checksumCheckBox.Checked = config.ChecksumCheck == "Y";
            verifyCheckBox.Checked = config.VerifyBackup == "Y";
            folderBrowserDialog1.SelectedPath = config.DatabaseDirectory;
            backupPathLabel.Text = config.DatabaseDirectory;

            int i = timeoutComboBox.FindString((config.QueryExecutionTimeout / 60).ToString() + " minute");
            if (i != -1)
                timeoutComboBox.SelectedIndex = i;
            backupTypeComboBox.Text = GetMappedCommand(_backupType);

            interval = config.RunInterval;
            additionalInfo = config.AdditionalInfo;
            if (config.NextExecution != null)
            {
                scheduleLabel.Text = "Scheduled to Run " + interval + " at " + additionalInfo
                    + " i.e. " + config.NextExecution;
                scheduleLabel.Visible = true;
            }
            else
            {
                scheduleLabel.Visible = false;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                backupPathLabel.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                MessageBox.Show("Please select a backup directory", "Validation Errors",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            int timeout = GetTimeOutValue(timeoutComboBox); // convert to seconds
            bool success = false;
            if (goButton.Text == "Save Scheduling &Settings")// save scheduling settings
            {
                DoBackupConfig dbConfig = DoBackupConfig.GetInstance(_backupType);
                string operationName = "Database Backup";
                success = SaveConfigurations(dbConfig) && 
                    ScheduleOperation(operationName, dbConfig, @"-c DoBackupConfig -type " + _backupType.ToUpper());
                if (success) // All Validation passed.
                {
                    MessageBox.Show("Configuration Saved Successfully. " + operationName 
                        + GetDisplaySchedule(dbConfig.RunInterval, dbConfig.AdditionalInfo),
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    scheduleLabel.Text = GetDisplaySchedule(dbConfig.RunInterval, dbConfig.AdditionalInfo) + ". Next Execution @ " + dbConfig.NextExecution;
                }
                return;
            }
            success = SubmitForm(ref builder, "[DatabaseBackup]", timeout);
            SystemConfig sytemConfig = SystemConfig.GetInstance();
            string compressedPath = null;
            if (sytemConfig.CompressBackup) // enable Compression by default
            {
                compressedPath = Utility.CompressLastBackup();
            }
            if (success)
            {
                if (!String.IsNullOrEmpty(compressedPath))
                {
                    MessageBox.Show("Backup Completed Successfully. Compressed Backup @ " + compressedPath,
                        "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Backup Completed Successfully. Please check the log file for more details",
                        "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                }
            }
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
            parameters.Add(new SqlParameter("@Directory", values[Constants.BACKUP_DIRECTORY]));
            parameters.Add(new SqlParameter("@BackupType", values[Constants.BACKUP_TYPE]));
            parameters.Add(new SqlParameter("@Verify", values[Constants.VERIFY_ONLY]));
            parameters.Add(new SqlParameter("@Checksum", values[Constants.CHECKSUM]));

            return parameters;
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
                builder.AppendLine("ERR: Please select the database to Backup");
            }
            else
            {
                values[Constants.DATABASE_NAME] = databaseComboBox.Items[databaseComboBox.SelectedIndex].ToString();
            }
            #endregion

            #region backup path 
            if (String.IsNullOrEmpty(backupPathLabel.Text))
                builder.AppendLine("ERR: Backup Path is required");
            else
                values[Constants.BACKUP_DIRECTORY] = backupPathLabel.Text;
            #endregion

            #region QueryExecutionTimeout
            if (timeoutComboBox.SelectedIndex < 0)
                builder.AppendLine("ERR: Please select a valid time value");
            else
            {
                string timeout = timeoutComboBox.Items[timeoutComboBox.SelectedIndex].ToString();
                if (timeout.IndexOf("Minute") != -1)
                    timeout = timeout.Substring(0, timeout.IndexOf("Minute")).Trim();
                values[Constants.EXECUTION_TIMEOUT] = timeout;
            }
            #endregion

            values[Constants.VERIFY_ONLY] = verifyCheckBox.Checked ? "Y" : "N";
            values[Constants.CHECKSUM] = checksumCheckBox.Checked ? "Y" : "N";
            values[Constants.BACKUP_TYPE] = _backupType;

            #region Scheduling Settings
            if (goButton.Text == "Save Scheduling &Settings")
            {
                // no validation required here as all the settings
                // are validated in the popup windows
                values[Constants.RUN_INTERVAL] = interval.ToString();
                values[Constants.ADDITIONAL_INFO] = additionalInfo.Trim();
            }
            #endregion

            return values;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            GetCheckBoxText(sender as CheckBox);
        }

        private void logBrowseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                logFileLabel.Text = folderBrowserDialog2.SelectedPath;
                LogDirectory = logFileLabel.Text;
            }
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ScheduleDialog.ShowDialog("Scheduling Parameters", ref interval, ref additionalInfo);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string message = "Please Click the Save Button to store the Settings";
                goButton.Text = "Save Scheduling &Settings";
                goButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                MessageBox.Show(message, "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                scheduleLabel.Text = GetDisplaySchedule(interval, additionalInfo);
                scheduleLabel.Visible = true;
            }
        }
    }
}
