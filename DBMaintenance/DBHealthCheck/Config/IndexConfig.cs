using System;
using DBHealthCheck.Utils;
using DBManager;
using System.Collections.Generic;
using DBManager.Utils;
using System.Data.SqlClient;

namespace DBHealthCheck.Config
{
    public class IndexConfig : ScheduleConfig 
        // as this is a 1 of case 
    {
        #region Variable Declaration
        private int _fragmentationLevel1;
        private int _fragmentationLevel2;
        private string _operationSequence;
        private int _minimumPageCountLevel;
        
        private int _fillFactor;
        private string _databaseName;
        private string _updateStatistics;
        #endregion

        #region Properties Definition
        public int FragmentationLevel1 
        {
            get
            {
                return _fragmentationLevel1;
            }
            set
            {
                ModifyEntry("FRAGMENTATION_LEVEL_1", value.ToString(), DOMAIN_NAME);
                _fragmentationLevel1 = value;
            }
        }

        public int FragmentationLevel2 
        {
            get
            {
                return _fragmentationLevel2;
            }
            set
            {
                ModifyEntry("FRAGMENTATION_LEVEL_2", value.ToString(), DOMAIN_NAME);
                _fragmentationLevel2 = value;
            }
        }
        
        public string OperationSequence 
        {
            get
            {
                return _operationSequence;
            }
            set
            {
                ModifyEntry("OPERATION_SEQUENCE", value.ToString(), DOMAIN_NAME);
                _operationSequence = value;
            }
        }
        
        public int MinimumPageCountLevel 
        {
            get
            {
                return _minimumPageCountLevel;
            }
            set
            {
                ModifyEntry("MINIMUM_PAGE_COUNT_LEVEL", value.ToString(), DOMAIN_NAME);
                _minimumPageCountLevel = value;
            }
        }

        public int FillFactor 
        {
            get
            {
                return _fillFactor;
            }
            set
            {
                ModifyEntry("FILL_FACTOR", value.ToString(), DOMAIN_NAME);
                _fillFactor = value;
            }
        }

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

        public string UpdateStatistics
        {
            get
            {
                return _updateStatistics;
            }
            set
            {
                ModifyEntry("UPDATE_STATISTICS", value, DOMAIN_NAME);
                _updateStatistics = value;
            }
        }
        #endregion

        private static IndexConfig _config = null;

        private IndexConfig()
            : base()
        {
            // initialize the DOMAIN_NAME variable
            DOMAIN_NAME = "IndexOptimize";

            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();
            _databaseName = Convert.ToString(GetEntry("DATABASE_NAME", DOMAIN_NAME));
            _fillFactor = Convert.ToInt32(GetEntry("FILL_FACTOR", DOMAIN_NAME));
            _fragmentationLevel1 = Convert.ToInt32(GetEntry("FRAGMENTATION_LEVEL_1", DOMAIN_NAME));
            _fragmentationLevel2 = Convert.ToInt32(GetEntry("FRAGMENTATION_LEVEL_2", DOMAIN_NAME));
            _minimumPageCountLevel = Convert.ToInt32(GetEntry("MINIMUM_PAGE_COUNT_LEVEL", DOMAIN_NAME));
            _operationSequence = Convert.ToString(GetEntry("OPERATION_SEQUENCE", DOMAIN_NAME));
            _updateStatistics = Convert.ToString(GetEntry("UPDATE_STATISTICS", DOMAIN_NAME));
        }

        public static IndexConfig GetInstance()
        {
            if (_config == null)
                _config = new IndexConfig();
         
            return _config;
        }

        public override bool SaveConfigurations(IDictionary<string, string> values)
        {
            bool success = false;
            try
            {
                DatabaseName = values[Constants.DATABASE_NAME];
                FragmentationLevel1 = Convert.ToInt32(values[Constants.FRAGMENTATION_LEVEL_1]);
                FragmentationLevel2 = Convert.ToInt32(values[Constants.FRAGMENTATION_LEVEL_2]);
                OperationSequence = values[Constants.OPERATION_SEQUENCE];
                FillFactor = Convert.ToInt32(values[Constants.FILL_FACTOR]);
                MinimumPageCountLevel = Convert.ToInt32(values[Constants.MINIMUM_PAGE_COUNT]);
                UpdateStatistics = values[Constants.UPDATE_STATISTICS];
                return base.SaveConfigurations(values);
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
            }
            return success;
        }

        public override string GetCommandOperation()
        {
            return "[IndexOptimize]";
        }

        public override SqlParameter[] GetCommandParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Databases", DatabaseName));
            parameters.Add(new SqlParameter("@FragmentationLevel1", FragmentationLevel1));
            parameters.Add(new SqlParameter("@FragmentationLevel2", FragmentationLevel2));
            parameters.Add(new SqlParameter("@FragmentationLow", DBNull.Value));
            parameters.Add(new SqlParameter("@FragmentationMedium", OperationSequence));
            parameters.Add(new SqlParameter("@FragmentationHigh", OperationSequence));
            parameters.Add(new SqlParameter("@PageCountLevel", MinimumPageCountLevel));
            parameters.Add(new SqlParameter("@FillFactor", FillFactor));
            parameters.Add(new SqlParameter("@UpdateStatistics", UpdateStatistics));
            parameters.Add(new SqlParameter("@OnlyModifiedStatistics", "Y"));
            parameters.Add(new SqlParameter("@LogToTable", "Y"));
            // parameters.Add(new SqlParameter("@WaitAtLowPriorityAbortAfterWait", "BLOCKERS"));
            // parameters.Add(new SqlParameter("@WaitAtLowPriorityMaxDuration", (int)((QueryExecutionTimeout / 60) - 1)));
            // parameters.Add(new SqlParameter("@LockTimeout", (int)(QueryExecutionTimeout - 5)));

            return parameters.ToArray();
        }
    }
}
