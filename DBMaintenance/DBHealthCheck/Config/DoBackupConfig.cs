using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBManager.Utils;
using DBHealthCheck.Utils;
using System.Data.SqlClient;

namespace DBHealthCheck.Config
{
    public class DoBackupConfig : ScheduleConfig
    {
        private static IDictionary<string, DoBackupConfig> _configs;

        #region Variable Declaration
        private string _databaseName;
        private string _databaseDirectory;
        private string _verifyBackup;
        private string _checksumCheck;
        private string _backupType;
        #endregion

        #region Propeties Definition 
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

        public string DatabaseDirectory
        {
            get
            {
                return _databaseDirectory;
            }
            set
            {
                ModifyEntry("DATABASE_DIRECTORY", value, DOMAIN_NAME);
                _databaseDirectory = value;
            }
        }

        public string VerifyBackup
        {
            get
            {
                return _verifyBackup;
            }
            set
            {
                ModifyEntry("VERIFY_BACKUP", value, DOMAIN_NAME);
                _verifyBackup = value;
            }
        }

        public string ChecksumCheck
        {
            get
            {
                return _checksumCheck;
            }
            set
            {
                ModifyEntry("CHECKSUM_CHECK", value, DOMAIN_NAME);
                _checksumCheck = value;
            }
        }

        public string BackupType
        {
            get
            {
                return _backupType;
            }
            private set
            {
                ModifyEntry("BACKUP_TYPE", value, DOMAIN_NAME);
                _backupType = value;
            }
        }
        #endregion

        private DoBackupConfig(string backupType)
        {
            DOMAIN_NAME = backupType + "_BackupDatabase";

            BackupType = backupType.ToUpper();
            Initialize();
        }

        protected override void Initialize()
        {
            _databaseName = Convert.ToString(GetEntry("DATABASE_NAME", DOMAIN_NAME));
            _databaseDirectory = Convert.ToString(GetEntry("DATABASE_DIRECTORY", DOMAIN_NAME));
            _verifyBackup = Convert.ToString(GetEntry("VERIFY_BACKUP", DOMAIN_NAME));
            _checksumCheck = Convert.ToString(GetEntry("CHECKSUM_CHECK", DOMAIN_NAME));
            _backupType = Convert.ToString(GetEntry("BACKUP_TYPE", DOMAIN_NAME));
            base.Initialize();
        }

        public override bool SaveConfigurations(IDictionary<string, string> values)
        {
            bool success = false;
            try
            {
                DatabaseName = values[Constants.DATABASE_NAME];
                DatabaseDirectory = values[Constants.BACKUP_DIRECTORY];
                VerifyBackup = values[Constants.VERIFY_ONLY];
                ChecksumCheck = values[Constants.CHECKSUM];
                return base.SaveConfigurations(values);
            }
            catch (Exception e)
            {
                LogUtil.Log(e.Message + Environment.NewLine + e.StackTrace);
            }
            return success;
        }

        public static DoBackupConfig GetInstance(string backupType)
        {
            if (_configs == null)
                _configs = new Dictionary<string, DoBackupConfig>();

            DoBackupConfig temp; 
            bool success = _configs.TryGetValue(backupType, out temp); 

            if (!success)
                _configs[backupType] = new DoBackupConfig(backupType);

            return _configs[backupType];
        }

        public override string GetCommandOperation()
        {
            return "[DatabaseBackup]";
        }

        public override SqlParameter[] GetCommandParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Databases", DatabaseName));
            parameters.Add(new SqlParameter("@Directory", DatabaseDirectory));
            parameters.Add(new SqlParameter("@BackupType", BackupType));
            parameters.Add(new SqlParameter("@Verify", VerifyBackup));
            parameters.Add(new SqlParameter("@Checksum", ChecksumCheck));
            parameters.Add(new SqlParameter("@LogToTable", "Y"));

            return parameters.ToArray();
        }
    }
}
