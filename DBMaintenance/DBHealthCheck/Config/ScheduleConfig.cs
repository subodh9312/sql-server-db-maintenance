using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBHealthCheck.Utils;
using DBManager;
using DBManager.Utils;
using System.Globalization;
using System.Data.SqlClient;

namespace DBHealthCheck.Config
{
    public abstract class ScheduleConfig : ConfigValue
    {
        #region Variable declarations
        private RunInterval _runInterval = RunInterval.None;
        private string _additionalInfo;
        private Nullable<DateTime> _previousExecution;
        private Nullable<DateTime> _nextExecution;
        private int _queryExecutionTimeout;
        #endregion

        protected string DOMAIN_NAME;

        #region Properties Definitions
        public RunInterval RunInterval
        {
            get
            {
                return _runInterval;
            }
            set
            {
                ModifyEntry("RUN_INTERVAL", value.ToString(), DOMAIN_NAME);
                _runInterval = value;
            }
        }
        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }
            set
            {
                ModifyEntry("ADDITIONAL_INFO", value, DOMAIN_NAME);
                _additionalInfo = value;
            }
        }

        public Nullable<DateTime> PreviousExecution
        {
            get
            {
                return _previousExecution;
            }
            set
            {
                if (value != null)
                    ModifyEntry("PREVIOUS_EXECUTION", value.ToString(), DOMAIN_NAME);
                _previousExecution = value;
            }
        }

        public Nullable<DateTime> NextExecution
        {
            get
            {
                _nextExecution = GetNextExecutionDate(_runInterval, _additionalInfo);
                return _nextExecution;
            }   
            set
            {
                if (value != null)
                    ModifyEntry("NEXT_EXECUTION", value.ToString(), DOMAIN_NAME);
                _nextExecution = value;
            }
        }
        
        public int QueryExecutionTimeout
        {
            get
            {
                return _queryExecutionTimeout;
            }
            set
            {
                ModifyEntry("QUERY_EXECUTION_TIMEOUT", value.ToString(), DOMAIN_NAME);
                _queryExecutionTimeout = value;
            }
        }
        #endregion

        public ScheduleConfig()
            : base()
        {
        }

        protected virtual void Initialize()
        {
            bool success = Enum.TryParse(Convert.ToString(GetEntry("RUN_INTERVAL", DOMAIN_NAME)), out _runInterval);
            if (!success)
            {
                // first entry
                RunInterval = RunInterval.None;
            }
            success = false;
            DateTime temp;
            success = DateTime.TryParse(Convert.ToString(GetEntry("PREVIOUS_EXECUTION", DOMAIN_NAME)), out temp);
            if (!success)
                _previousExecution = null;
            else
                _previousExecution = temp;
            temp = DateTime.MinValue;
            success = false;
            success = DateTime.TryParse(Convert.ToString(GetEntry("NEXT_EXECUTION", DOMAIN_NAME)), out temp);
            if (!success)
                _nextExecution = null;
            else
                _nextExecution = temp;

            _additionalInfo = Convert.ToString(GetEntry("ADDITIONAL_INFO", DOMAIN_NAME));
            if (!String.IsNullOrEmpty(_additionalInfo))
                _additionalInfo = _additionalInfo.Trim();

            _queryExecutionTimeout = Convert.ToInt32(GetEntry("QUERY_EXECUTION_TIMEOUT", DOMAIN_NAME));
        }

        protected Nullable<DateTime> GetNextExecutionDate(RunInterval interval, string additionalInfo)
        {
            Nullable<DateTime> retValue = null;
            switch (interval)
            {
                case RunInterval.None:
                    retValue = null;
                    break;
                case RunInterval.Hourly:
                    retValue = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " 
                        + DateTime.Now.Hour + ":" + additionalInfo);
                    if (retValue.Value.CompareTo(DateTime.Now) < 0) // execution time is passed.
                        retValue = retValue.Value.AddHours(1);
                    break;
                case RunInterval.Daily:
                    retValue = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + additionalInfo + ":00");
                    if (retValue.Value.CompareTo(DateTime.Now) < 0)
                        retValue = retValue.Value.AddDays(1);
                    break;
                case RunInterval.Weekly:
                case RunInterval.Fortnightly:
                    string temp = additionalInfo.Substring(additionalInfo.IndexOf(" at ") + " at ".Length);
                    temp = temp.Trim();
                    retValue = Convert.ToDateTime(GetNextWeekDay(additionalInfo).ToShortDateString() + " " + temp + ":00");
                    if (interval == RunInterval.Fortnightly)
                    {
                        // add week time in Weekly schedule.
                        int count = Enum.GetValues(typeof(DayOfWeek)).Length;
                        retValue = retValue.Value.AddDays(count);
                    }
                    break;
                case RunInterval.Monthly:
                    string day = additionalInfo.Substring(additionalInfo.IndexOf("On ") + "On ".Length, 
                        additionalInfo.IndexOf(" @ ") - " @ ".Length);
                    DateTime today = DateTime.Today;
                    if (today.Month == 12) // December
                    {
                        retValue = new DateTime(today.Year + 1, 1, Convert.ToInt32(day.Trim()));
                    }
                    else
                    {
                        // month is less than December
                        retValue = new DateTime(today.Year, today.Month + 1, Convert.ToInt32(day.Trim()));
                    }

                    string time = additionalInfo.Substring(additionalInfo.IndexOf(" @ ") + " @ ".Length);
                    retValue = Convert.ToDateTime(retValue.Value.ToShortDateString() + " " + time);
                    break;
                case RunInterval.Yearly:
                    // 28-Feb @ 02:01
                    retValue = DateTime.ParseExact(additionalInfo, "dd-MMM @ hh:mm", CultureInfo.InvariantCulture);
                    // retValue = DateTime.Parse(additionalInfo.Trim());
                    retValue = retValue.Value.AddYears(1);
                    break;
                default:
                    throw new ArgumentException("Invalid interval Value Passed");
            }
            return retValue;
        }

        private DateTime GetNextWeekDay(string additionalInfo)
        {
            string temp = additionalInfo.Substring(0, additionalInfo.IndexOf(" at "));
            temp = temp.Trim();
            DateTime tomorrow = DateTime.Today.AddDays(1);
            additionalInfo = additionalInfo.Trim();
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), temp);
            int count = Enum.GetValues(typeof(DayOfWeek)).Length;
            int daysToAdd = ((int)dayOfWeek - (int)tomorrow.DayOfWeek + count) % count;
            DateTime retValue = tomorrow.AddDays(daysToAdd);
            return retValue;
        }

        public virtual bool SaveConfigurations(IDictionary<string, string> values)
        {
            bool success = false;
            try
            {
                // scheduling configuration
                RunInterval = (RunInterval)Enum.Parse(typeof(RunInterval), values[Constants.RUN_INTERVAL]);
                AdditionalInfo = values[Constants.ADDITIONAL_INFO];
                PreviousExecution = null; // reset Previous execution value
                NextExecution = GetNextExecutionDate(RunInterval, AdditionalInfo);
                QueryExecutionTimeout = Convert.ToInt32(values[Constants.EXECUTION_TIMEOUT]);
                success = true;
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
            }
            return success;
        }

        public bool UpdateNextExecutionTime()
        {
            bool success = false;

            NextExecution = GetNextExecutionDate(RunInterval, AdditionalInfo);
            success = true;
            return success;
        }

        public abstract string GetCommandOperation();

        public abstract SqlParameter[] GetCommandParameters();
    }
}
