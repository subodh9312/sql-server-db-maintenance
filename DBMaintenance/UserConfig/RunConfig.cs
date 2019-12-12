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
    public partial class RunConfig : BaseForm
    {
        private RunInterval interval;
        private string additionalInfo;

        /// <summary>
        /// 
        /// </summary>
        public RunConfig()
        {
            InitializeComponent();

            InitializeDatabaseComboBox(databaseComboBox);
            InitializeTimeoutComboBox(timeoutComboBox);

            logDirectoryLabel.Text = AppDomain.CurrentDomain.BaseDirectory;
            LogDirectory = logDirectoryLabel.Text;

            SystemConfig systemConfig = SystemConfig.GetInstance();
            if (systemConfig.AutomaticScheduling)
                scheduleButton.Visible = true;

            IndexConfig config = IndexConfig.GetInstance();
            if (!String.IsNullOrEmpty(config.DatabaseName))
            {
                int index = databaseComboBox.FindString(config.DatabaseName);
                if (index != -1)
                    databaseComboBox.SelectedIndex = index;
            }

            frag1TextBox.Text = config.FragmentationLevel1.ToString();
            frag2TextBox.Text = config.FragmentationLevel2.ToString();

            if (config.OperationSequence != null)
            {
                string[] parts = config.OperationSequence.Split(',');
                if (parts.Length > 0)
                    lowCombobox.SelectedIndex = lowCombobox.FindString(parts[0]);
                if (parts.Length > 1)
                    mediumComboBox.SelectedIndex = mediumComboBox.FindString(parts[1]);
                if (parts.Length > 2)
                    highComboBox.SelectedIndex = highComboBox.FindString(parts[2]);
            }

            minPageCntTextBox.Text = config.MinimumPageCountLevel.ToString();
            int i = timeoutComboBox.FindString((config.QueryExecutionTimeout / 60).ToString() + " minute");
            if (i != -1)
                timeoutComboBox.SelectedIndex = i;
            fillFactorTextBox.Text = config.FillFactor.ToString();
            updateStatsComboBox.Text = GetMappedCommand(config.UpdateStatistics);
            interval = config.RunInterval;
            additionalInfo = config.AdditionalInfo;
            if (config.NextExecution != null)
            {
                scheduleLabel.Text = GetDisplaySchedule(interval, additionalInfo)
                    + ". Next Execution @ " + config.NextExecution;
                scheduleLabel.Visible = true;
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
            
            parameters.Add(new SqlParameter("@Databases",
                values[Constants.DATABASE_NAME]));
            parameters.Add(new SqlParameter("@FragmentationLevel1", 
                Convert.ToInt32(values[Constants.FRAGMENTATION_LEVEL_1])));
            parameters.Add(new SqlParameter("@FragmentationLevel2",
                Convert.ToInt32(values[Constants.FRAGMENTATION_LEVEL_2])));
            parameters.Add(new SqlParameter("@FragmentationLow",
                DBNull.Value));
            parameters.Add(new SqlParameter("@FragmentationMedium",
                values[Constants.OPERATION_SEQUENCE]));
            parameters.Add(new SqlParameter("@FragmentationHigh",
                values[Constants.OPERATION_SEQUENCE]));
            parameters.Add(new SqlParameter("@PageCountLevel",
                Convert.ToInt32(values[Constants.MINIMUM_PAGE_COUNT])));
            parameters.Add(new SqlParameter("@FillFactor", 
                Convert.ToInt32(values[Constants.FILL_FACTOR])));
            parameters.Add(new SqlParameter("@UpdateStatistics", 
                values[Constants.UPDATE_STATISTICS]));

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

            #region Database Name Combo Box
            if (databaseComboBox.SelectedIndex < 0)
            {
                builder.AppendLine("ERR: Database Name is required to schedule a DB Maintenance");
            }
            else
            {
                values.Add(Constants.DATABASE_NAME,
                    databaseComboBox.Items[databaseComboBox.SelectedIndex].ToString());
            }
            #endregion

            #region Fragmentation Range
            int fragLevel1 = 5;
            bool success = Int32.TryParse(frag1TextBox.Text, out fragLevel1);
            if (!success)
            {
                if (String.IsNullOrEmpty(frag1TextBox.Text))
                {
                    builder.AppendLine("WARN: Minimum Fragmentation 1 Level value not entered, setting to default 5%");
                    frag1TextBox.Text = "5";
                }
                else
                {
                    builder.AppendLine("ERR: Please enter numeric value for fragmentation Level 1\n");
                }
            }
            else if (fragLevel1 > 100 || fragLevel1 < 0)
            {
                builder.AppendLine("ERR: Fragmentation Level 1 Percentage should have range from 0 - 100");
            }
            else
            {
                // everything seems ok
                values[Constants.FRAGMENTATION_LEVEL_1] = fragLevel1.ToString();
            }

            int fragLevel2 = 25;
            success = Int32.TryParse(frag2TextBox.Text, out fragLevel2);
            if (!success)
            {
                if (String.IsNullOrEmpty(frag2TextBox.Text))
                {
                    builder.AppendLine("WARN: Minimum Fragmentation 2 Level value not entered, setting to default 25%");
                    frag2TextBox.Text = "25";
                }
                else
                {
                    builder.AppendLine("ERR: Please enter numeric value for fragmentation Level 2");
                }
            }
            else if (fragLevel2 > 100 || fragLevel2 < 0)
            {
                builder.AppendLine("ERR: Fragmentation Level 2 Percentage should have range from 0 - 100");
            }
            else
            {
                // everything seems Ok
                values[Constants.FRAGMENTATION_LEVEL_2] = fragLevel2.ToString();
            }
            #endregion

            #region Operation Sequence
            string lowOperation = "", mediumOperation = "", highOperation = "";
            if (lowCombobox.SelectedIndex < 2)
            {
                builder.AppendLine("ERR: Please select a Value in first operation Sequence Drop Down");
            }
            else if (lowCombobox.SelectedIndex != 2)
            {
                lowOperation = lowCombobox.Items[lowCombobox.SelectedIndex].ToString();
            }

            if (mediumComboBox.SelectedIndex < 2)
            {
                builder.AppendLine("ERR: Please select a Value in second operation Sequence Drop Down");
            }
            else if (mediumComboBox.SelectedIndex != 2)
            {
                mediumOperation = mediumComboBox.Items[mediumComboBox.SelectedIndex].ToString();
            }

            if (highComboBox.SelectedIndex < 2)
            {
                builder.AppendLine("ERR: Please select a Value in third operation Sequence Drop Down");
            }
            else if (highComboBox.SelectedIndex != 2)
            {
                highOperation = highComboBox.Items[highComboBox.SelectedIndex].ToString();
            }

            string operation = "";
            if (!String.IsNullOrEmpty(lowOperation))
            {
                operation += lowOperation;
            }

            if (!String.IsNullOrEmpty(mediumOperation))
            {
                if (String.IsNullOrEmpty(operation))
                    operation += mediumOperation;
                else
                    operation += "," + mediumOperation;
            }

            if (!String.IsNullOrEmpty(highOperation))
            {
                if (String.IsNullOrEmpty(operation))
                    operation += highOperation;
                else
                    operation += "," + highOperation;
            }

            if (String.IsNullOrEmpty(operation))
            {
                builder.AppendLine("ERR: Please select valid Operation Set");
            }
            else
            {
                values[Constants.OPERATION_SEQUENCE] = operation;
            }
            #endregion

            #region Page Count
            int pageCount = 800;
            success = Int32.TryParse(minPageCntTextBox.Text, out pageCount);
            if (!success)
            {
                if (String.IsNullOrEmpty(minPageCntTextBox.Text))
                {
                    builder.AppendLine("WARN: Page Count Level Set to default, 800");
                    minPageCntTextBox.Text = "800";
                }
                else
                {
                    builder.AppendLine("ERR: Please enter a numeric value for Page Count.");
                }
            }
            else if (pageCount <= 0)
            {
                builder.AppendLine("ERR: Minimum Page Count Value should be positive and greater than 0.");
            }
            else
            {
                values[Constants.MINIMUM_PAGE_COUNT] = pageCount.ToString();
            }
            #endregion

            #region Fill Factor
            int fillFactor = 90; // 90%
            success = Int32.TryParse(fillFactorTextBox.Text, out fillFactor);
            if (!success)
            {
                if (String.IsNullOrEmpty(fillFactorTextBox.Text))
                {
                    builder.AppendLine("WARN: Fill Factor value is empty, setting to default, 90.");
                    fillFactorTextBox.Text = "90";
                }
            }
            else if (fillFactor > 100 || fillFactor < 0)
            {
                builder.AppendLine("ERR: Fill Factor Percentage should have range from 0 - 100");
            }
            else
            {
                values[Constants.FILL_FACTOR] = fillFactor.ToString();
            }
            #endregion

            #region Update Statistics
            if (updateStatsComboBox.SelectedIndex < 0)
            {
                builder.AppendLine("ERR: Please select a value for Update Statistics Type. ");
            }
            else
            {
                string text = updateStatsComboBox.Items[updateStatsComboBox.SelectedIndex].ToString();
                values[Constants.UPDATE_STATISTICS] = GetMappedCommand(text);
            }
            #endregion

            values[Constants.EXECUTION_TIMEOUT] = GetTimeOutValue(timeoutComboBox).ToString();

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

        private void goButton_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            int timeout = GetTimeOutValue(timeoutComboBox);

            if (goButton.Text == "Save Scheduling &Settings")
            {
                // save the scheduling configurations
                IndexConfig config = IndexConfig.GetInstance();
                string operationName = "Index Optimize";

                bool success = SaveConfigurations(config) && ScheduleOperation(operationName, config, @"-c IndexConfig");
                if (success) // All Validation passed.
                {
                    MessageBox.Show("Configuration Saved Successfully. " + operationName + " successfully " +
                        GetDisplaySchedule(config.RunInterval, config.AdditionalInfo), "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    scheduleLabel.Text = GetDisplaySchedule(config.RunInterval, config.AdditionalInfo)
                        + ". Next Execution @ " + config.NextExecution;
                }
                else
                {
                    MessageBox.Show("Some issue in saving the configurations.", "Operation Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                bool success = SubmitForm(ref builder, "[IndexOptimize]", timeout);
                if (success)
                {
                    MessageBox.Show("Command Executed Successfully. Please check the log file for more details.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                logDirectoryLabel.Text = folderBrowserDialog1.SelectedPath;
                LogDirectory = logDirectoryLabel.Text;
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