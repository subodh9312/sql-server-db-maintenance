using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DBHealthCheck.Config;
using DBHealthCheck.Utils;
using DBManager;
using DBManager.Utils;
using Microsoft.Win32.TaskScheduler;

namespace UserConfig.Utils
{
    /// <summary>
    /// Base class for all the forms of the application. Useful place for adding common code 
    /// which would be used throught out the application
    /// </summary>
    public partial class BaseForm : Form
    {
        private Form form;
        /// <summary>
        /// 
        /// </summary>
        public string LogDirectory { get; set; }
        
        /// <summary>
        /// Hides all the forms which are opened in the Parent MDI Container i.e. the Main Form
        /// </summary>
        protected void HideAllMdiChildren()
        {
            foreach (Form mdiChild in MdiChildren)
                mdiChild.Hide();
        }

        /// <summary>
        /// Hides all the already opened in the main form and open the formToShow form in the Main form
        /// </summary>
        /// <param name="formToShow">Form to Show in the Main form</param>
        protected void ShowChildForm(BaseForm formToShow)
        {
            HideAllMdiChildren();

            form = formToShow;
            form.Size = new Size(this.Width, this.Height);
            form.MdiParent = this;

            form.Show();
        }

        /// <summary>
        /// Closes all the forms open in the Mdi Main form.
        /// </summary>
        protected void CloseAllForms()
        {
            foreach (Form child in MdiChildren)
                child.Close();

            this.Close();
        }

        /// <summary>
        /// Initializes the comboBox with the list of databases present on the database server as 
        /// connected by the connection string.
        /// </summary>
        /// <param name="databaseComboBox">Database ComboBox to Initialize</param>
        protected void InitializeDatabaseComboBox(ComboBox databaseComboBox)
        {
            DatabaseManager manager = new DatabaseManager();
            List<object> databases = manager.ExecuteQuery("sp_databases", QueryMode.Reader, null, new Databases()) as List<object>;
            foreach (object database in databases)
                databaseComboBox.Items.Add(database);
        }

        /// <summary>
        /// Submits a Form after validation. 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="command"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected bool SubmitForm(ref StringBuilder builder, string command = null, int timeout = 0)
        {
            IDictionary<string, string> values = ValidateInput(ref builder);

            if (!String.IsNullOrEmpty(builder.ToString()))
            {
                if (builder.ToString().IndexOf("ERR:", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    MessageBox.Show(builder.ToString(), "Validation Errors",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else
                {
                    MessageBox.Show(builder.ToString(), "Validation Warnings",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            if (String.IsNullOrEmpty(command))
                return true;
            
            List<SqlParameter> parameters = GetSqlParameters(values);

            parameters.Add(new SqlParameter("@LogToTable", "Y"));

            DatabaseManager manager = new DatabaseManager();
            builder.Clear();
            manager.ExecuteQuery(command, QueryMode.Update, parameters.ToArray(), builder, timeout);

            if (!SaveLogFile(builder, command))
            {
                MessageBox.Show("Error Generating the Log File. Please check if the Log directory is accessible.",
                    "Logging error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); 
            }

            return true;
        }

        /// <summary>
        /// Save te configurations for the passed Config
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        protected bool SaveConfigurations(ScheduleConfig config)
        {
            StringBuilder builder = new StringBuilder();
            IDictionary<string, string> values = ValidateInput(ref builder);

            if (!String.IsNullOrEmpty(builder.ToString()))
            {
                if (builder.ToString().IndexOf("ERR:", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    MessageBox.Show(builder.ToString(), "Validation Errors",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else
                {
                    MessageBox.Show(builder.ToString(), "Validation Warnings",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            config.SaveConfigurations(values);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected virtual IDictionary<string, string> ValidateInput(ref StringBuilder builder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        protected virtual List<SqlParameter> GetSqlParameters(IDictionary<string, string> values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkBox"></param>
        protected virtual void GetCheckBoxText(CheckBox checkBox)
        {
            if (checkBox != null)
            {
                if (checkBox.Checked)
                    checkBox.Text = "Yes";
                else
                    checkBox.Text = "No";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeoutComboBox"></param>
        /// <returns></returns>
        protected virtual int GetTimeOutValue(ComboBox timeoutComboBox)
        {
            string text = timeoutComboBox.Items[timeoutComboBox.SelectedIndex].ToString();
            if (text.IndexOf("Minute") != -1)
            {
                text = text.Substring(0, text.IndexOf("Minute") - 1);
                int timeout = Convert.ToInt32(text.Trim());

                timeout *= 60; // convert to seconds
                return timeout;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeoutComboBox"></param>
        protected virtual void InitializeTimeoutComboBox(ComboBox timeoutComboBox)
        {

            timeoutComboBox.Items.Clear();

            timeoutComboBox.Items.Add("1 Minute");
            timeoutComboBox.Items.Add("2 Minutes");
            timeoutComboBox.Items.Add("3 Minutes");
            timeoutComboBox.Items.Add("5 Minutes");
            timeoutComboBox.Items.Add("10 Minutes");
            timeoutComboBox.Items.Add("15 Minutes");
            timeoutComboBox.Items.Add("20 Minutes");
            timeoutComboBox.Items.Add("25 Minutes");
            timeoutComboBox.Items.Add("30 Minutes");
            timeoutComboBox.Items.Add("60 Minutes");
            timeoutComboBox.Items.Add("90 Minutes");
            timeoutComboBox.Items.Add("120 Minutes");
            timeoutComboBox.Items.Add("150 Minutes");

            int defaultValue = timeoutComboBox.FindString("5 Minutes");
            timeoutComboBox.SelectedIndex = defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual string GetMappedCommand(string command)
        {
            if (String.IsNullOrEmpty(command))
                return command;
            switch (command.Trim())
            {
                // Database integrity check cases
                case "Check allocation and structural integrity":
                    command = "CHECKFILEGROUP";
                    break;
                case "Check for catalog consistency":
                    command = "CHECKCATALOG";
                    break;
                case "Check consistency of disk space allocation":
                    command = "CHECKALLOC";
                    break;
                case "Check logical and physical integrity":
                    command = "CHECKDB";
                    break;
                // Update Statistics Cases
                case "All (Complete Statistics)":
                    command = "ALL";
                    break;
                case "Only Column Statistics":
                    command = "COLUMNS";
                    break;
                case "Only Index Statistics":
                    command = "INDEX";
                    break;
                case "Full Backup":
                    command = "FULL";
                    break;
                case "Differential Backup":
                    command = "DIFF";
                    break;
                case "Log Backup":
                    command = "LOG";
                    break;
                #region Reverse Mapping
                case "CHECKFILEGROUP":
                    command = "Check allocation and structural integrity";
                    break;
                case "CHECKCATALOG":
                    command = "Check for catalog consistency";
                    break;
                case "CHECKALLOC":
                    command = "Check consistency of disk space allocation";
                    break;
                case "CHECKDB":
                    command = "Check logical and physical integrity";
                    break;
                // Update Statistics Cases
                case "ALL":
                    command = "All (Complete Statistics)";
                    break;
                case "COLUMNS":
                    command = "Only Column Statistics";
                    break;
                case "INDEX":
                    command = "Only Index Statistics";
                    break;
                case "FULL":
                    command = "Full Backup";
                    break;
                case "DIFF":
                    command = "Differential Backup";
                    break;
                case "LOG":
                    command = "Log Backup";
                    break;
                #endregion
                default:
                    throw new ArgumentException("Invalid argument 'command' = " + command
                        + " is unknown");
            }
            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="command"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected virtual bool SaveLogFile(StringBuilder builder, string command, string filePath = null)
        {
            try
            {
                if (String.IsNullOrEmpty(filePath))
                    filePath = LogDirectory + @"\" + command + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".log";

                File.AppendAllText(filePath, builder.ToString(), Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="additionalInfo"></param>
        /// <returns></returns>
        protected string GetDisplaySchedule(RunInterval interval, string additionalInfo)
        {
            string text = "";
            switch (interval)
            {
                case RunInterval.Hourly:
                    DateTime t = DateTime.ParseExact(additionalInfo, "mm:ss", CultureInfo.InvariantCulture);
                    text = "Scheduled to run every hour at " + t.Minute + " mins " + t.Second + " secs.";
                    break;
                case RunInterval.Daily:
                    t = DateTime.ParseExact(additionalInfo, "HH:mm", CultureInfo.InvariantCulture);
                    text = "Scheduled to run every Day at " + t.Hour + " hrs " + t.Minute + " mins.";
                    break;
                case RunInterval.Weekly:
                    text = "Scheduled to run every week on " + additionalInfo;
                    break;
                case RunInterval.Fortnightly:
                    text = "Scheduled to run every alternate week on " + additionalInfo;
                    break;
                case RunInterval.Monthly:
                    string temp = additionalInfo.Substring(additionalInfo.IndexOf(" @ "));
                    string day = additionalInfo.Substring(0, additionalInfo.IndexOf(temp));
                    temp = temp.Trim();
                    text = "Scheduled to run every " + day + " day of the month " + temp;
                    break;
                case RunInterval.Yearly:
                    text = "Scheduled to run every year on " + additionalInfo;
                    break;
                case RunInterval.None:
                default:
                    // do nothing.
                    break;
            }
            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool IsValidEmail(string emailAddress)
        {
            bool invalid = false;
            try
            {
                if (String.IsNullOrEmpty(emailAddress))
                    return false;

                // Use IdnMapping class to convert Unicode domain names.
                emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", this.DomainMapper);
                if (invalid)
                    return false;

                // Return true if emailAddress is in valid e-mail format.
                return Regex.IsMatch(emailAddress,
                       @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                       RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
                throw e;
            }
            return match.Groups[1].Value + domainName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="config"></param>
        /// <param name="arguments"></param>
        /// <param name="author"></param>
        /// <param name="documentationUrl"></param>
        /// <returns></returns>
        protected bool ScheduleOperation(string operationName, ScheduleConfig config, 
            string arguments,
            string author = "Footsteps Infotech Inc.",
            string documentationUrl = "http://www.footstepsinfotech.com")
        {
            bool success = false;
            try
            {
                using (TaskService service = new TaskService())
                {
                    try
                    {
                        // De-Register the task in the root folder  if it already exists
                        // service.RootFolder.DeleteTask(@"DBHealthCheck" + operationName.Replace(" ", ""));
                        Task task = service.GetTask(service.RootFolder.Path + @"DBHealthCheck" + operationName.Replace(" ", ""));
                        if (task != null)
                            service.RootFolder.DeleteTask(task.Name);
                    }
                    catch
                    {
                        // ignore
                    }

                    TaskDefinition definition = service.NewTask();

                    definition.RegistrationInfo.Description = "DB Health Check " + operationName + " Scheduler Service";
                    definition.RegistrationInfo.Author = author;
                    definition.RegistrationInfo.Date = DateTime.Today;
                    definition.RegistrationInfo.Documentation = documentationUrl;
                    definition.Principal.RunLevel = TaskRunLevel.Highest;
                    definition.Principal.LogonType = TaskLogonType.ServiceAccount;

                    Trigger trigger = GetTrigger(operationName, config);

                    // Trigger must then be added to the task's trigger collection
                    definition.Triggers.Add(trigger);

                    // Create an action that will launch Notepad whenever the trigger fires
                    string path = Path.GetDirectoryName(Application.ExecutablePath);
                    // string path = @"D:\Subodh\Views\Websites\DBMaintenance\DBHealthCheckExecAction\bin\Debug";
                    definition.Actions.Add(new ExecAction(Path.Combine(path, @"DBHealthCheckExecAction.exe"), 
                        arguments, path));

                    // Register the task in the root folder
                    service.RootFolder.RegisterTaskDefinition(@"DBHealthCheck" + operationName.Replace(" ", ""), definition,
                        TaskCreation.CreateOrUpdate, "SYSTEM", null, TaskLogonType.ServiceAccount);
                }
                success = true;
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
                success = false;
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private Trigger GetTrigger(string operationName, ScheduleConfig config)
        {
            Trigger trigger = null;
            string temp = null;
            string time = null;
            DaysOfTheWeek daysOfWeek;
            switch (config.RunInterval)
            {
                case RunInterval.Hourly:
                    trigger = new TimeTrigger();
                    // Set the time in between each repetition of the task after it starts to 30 minutes.
                    trigger.Repetition.Interval = TimeSpan.FromMinutes(60);

                    time = DateTime.Now.Hour + ":" + config.AdditionalInfo;
                    // Set the start time for today as we want to start it immediately.
                    trigger.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + time);
                    break;
                case RunInterval.Daily:
                    trigger = new DailyTrigger { DaysInterval = 1 };

                    // Set the time the task will repeat to 1 day.
                    time = config.AdditionalInfo + ":00";
                    // Set the start time for today as we want to start it immediately.
                    trigger.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + time);
                    break;
                case RunInterval.Weekly:
                    // Sunday at 02:00
                    temp = config.AdditionalInfo.Substring(0, config.AdditionalInfo.IndexOf("at"));
                    temp = temp.Trim();
                    daysOfWeek = (DaysOfTheWeek)Enum.Parse(typeof(DaysOfTheWeek), temp);
                    time = config.AdditionalInfo.Substring(config.AdditionalInfo.IndexOf(temp + " at ") + (temp + " at ").Length);
                    time = time + ":00";
                    trigger = new WeeklyTrigger { WeeksInterval = 1, DaysOfWeek = daysOfWeek, StartBoundary = Convert.ToDateTime(config.NextExecution) };
                    break;
                case RunInterval.Fortnightly:
                    // Sunday at 02:00
                    temp = config.AdditionalInfo.Substring(0, config.AdditionalInfo.IndexOf("at"));
                    temp = temp.Trim();
                    daysOfWeek = (DaysOfTheWeek)Enum.Parse(typeof(DaysOfTheWeek), temp);
                    time = config.AdditionalInfo.Substring(config.AdditionalInfo.IndexOf(temp + " at ") + (temp + " at ").Length);
                    time = time + ":00";
                    trigger = new WeeklyTrigger { WeeksInterval = 2, DaysOfWeek = daysOfWeek, StartBoundary = Convert.ToDateTime(config.NextExecution) };
                    break;
                case RunInterval.Monthly:
                    string day = config.AdditionalInfo.Substring(config.AdditionalInfo.IndexOf("On ") + "On ".Length,
                        config.AdditionalInfo.IndexOf(" @ ") - "On ".Length);
                    trigger = new MonthlyTrigger { DaysOfMonth = new int[] { Convert.ToInt32(day) }, 
                        MonthsOfYear = MonthsOfTheYear.AllMonths };
                    if (config.NextExecution == null)
                        config.UpdateNextExecutionTime();

                    trigger.StartBoundary = DateTime.Now;
                    break;
                case RunInterval.Yearly:
                    trigger = new TimeTrigger();

                    trigger.Repetition.Interval = TimeSpan.FromDays(365);

                    // 28-Feb @ 02:01
                    temp = config.AdditionalInfo.Substring(0, config.AdditionalInfo.IndexOf(" @ "));
                    temp = temp.Trim();
                    DateTime t = DateTime.ParseExact(config.AdditionalInfo, "dd-MMM", CultureInfo.InvariantCulture);

                    trigger.StartBoundary = new DateTime(DateTime.Now.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second);
                    break;
            }

            // Disable the trigger from firing the task
            trigger.Enabled = true; // Default is true

            // Set the task to end even if running when the duration is over
            // trigger.Repetition.StopAtDurationEnd = true; // Default is false

            // Set an identifier to be used when logging
            trigger.Id = "DBHeathCheck" + operationName.Replace(" ", "");

            // Set the maximum time this task can run once triggered to one hour.
            trigger.ExecutionTimeLimit = TimeSpan.FromHours(1);
            return trigger;
        }
    }
}
