using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBHealthCheck.Utils;
using DBManager.Utils;
using System.Data.SqlClient;

namespace DBHealthCheck.Config
{
    public class IntegrityCheckConfig : ScheduleConfig
    {
        private static IntegrityCheckConfig _config;

        #region Variable Names declaration
        private string _databaseName;
        private string _checkCommand;
        private string _physicalOnly;
        private string _excludeIndexes;
        private string _extendedLogicalChecks;
        #endregion

        private IntegrityCheckConfig()
            : base()
        {
            DOMAIN_NAME = "IntegrityCheck";

            Initialize();
        }

        #region Public Properties
        public string DatabaseName
        {
            get
            {
                return _databaseName;
            }
            set
            {
                ModifyEntry("DATABASE_NAME", value, DOMAIN_NAME);
                _databaseName = value;
            }
        }

        public string CheckCommand
        {
            get
            {
                return _checkCommand;
            }
            set
            {
                ModifyEntry("CHECK_COMMAND", value, DOMAIN_NAME);
                _checkCommand = value;
            }
        }

        public string PhysicalOnly
        {
            get
            {
                return _physicalOnly;
            }
            set
            {
                ModifyEntry("PHYSICAL_ONLY", value, DOMAIN_NAME);
                _physicalOnly = value;
            }
        }

        public string ExcludeIndexes
        {
            get
            {
                return _excludeIndexes;
            }
            set
            {
                ModifyEntry("EXCLUDE_INDEXES", value, DOMAIN_NAME);
                _excludeIndexes = value;
            }
        }

        public string ExtendedLogicalChecks
        {
            get
            {
                return _extendedLogicalChecks;
            }
            set
            {
                ModifyEntry("EXTENDED_LOGICAL_CHECKS", value, DOMAIN_NAME);
                _extendedLogicalChecks = value;
            }
        }
        #endregion

        protected override void Initialize()
        {
            base.Initialize();
            // do custom configuration initialization here
            _databaseName = Convert.ToString(GetEntry("DATABASE_NAME", DOMAIN_NAME));
            _checkCommand = Convert.ToString(GetEntry("CHECK_COMMAND", DOMAIN_NAME));
            _physicalOnly = Convert.ToString(GetEntry("PHYSICAL_ONLY", DOMAIN_NAME));
            _excludeIndexes = Convert.ToString(GetEntry("EXCLUDE_INDEXES", DOMAIN_NAME));
            _extendedLogicalChecks = Convert.ToString(GetEntry("EXTENDED_LOGICAL_CHECKS", DOMAIN_NAME));
        }

        public override bool SaveConfigurations(IDictionary<string, string> values)
        {
            bool success = false;
            try
            {
                DatabaseName = values[Constants.DATABASE_NAME];
                CheckCommand = values[Constants.CHECK_COMMAND];
                PhysicalOnly = values[Constants.PHYSICAL_ONLY];
                ExtendedLogicalChecks = values[Constants.EXTENDED_LOGICAL_CHECKS];
                ExcludeIndexes = values[Constants.EXCLUDE_INDEXES];
                return base.SaveConfigurations(values);
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
            }
            return success;
        }

        public static IntegrityCheckConfig GetInstance()
        {
            if (_config == null)
                _config = new IntegrityCheckConfig();

            return _config;
        }

        public override string GetCommandOperation()
        {
            return "[DatabaseIntegrityCheck]";
        }

        public override SqlParameter[] GetCommandParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Databases", DatabaseName));
            parameters.Add(new SqlParameter("@CheckCommands", CheckCommand));
            parameters.Add(new SqlParameter("@PhysicalOnly", PhysicalOnly));
            parameters.Add(new SqlParameter("@ExtendedLogicalChecks", ExtendedLogicalChecks));
            parameters.Add(new SqlParameter("@NoIndex", ExcludeIndexes));
            parameters.Add(new SqlParameter("@LogToTable", "Y"));

            return parameters.ToArray();
        }
    }
}
