using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DBHealthCheck.Config;
using DBHealthCheck.Utils;
using DBHealthCheckExecAction.Utils;
using DBManager;
using DBManager.Utils;

namespace DBHealthCheck
{
    public class Program
    {
        private string LogFilePath = "";

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Process(args);
        }

        private void Process(string[] args)
        {
            try
            {
                ScheduleConfig config = GetConfigFromFileName(args);

                string logFileName = config.GetCommandOperation();
                logFileName = logFileName.Replace("[", "");
                logFileName = logFileName.Replace("]", "");
                logFileName += "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".log";

                LogFilePath = logFileName;

                StringBuilder commandPrintOutput = new StringBuilder();

                if (config is IndexConfig)
                {
                    // get the before screenshot
                    Log("*****************************************************");
                    Log("Before Snapshot for the fragmenation levels");
                    Log("*****************************************************");
                    LogDBFragLevel(config as IndexConfig);
                }

                DatabaseManager manager = new DatabaseManager();
                manager.ExecuteQuery(config.GetCommandOperation(),
                    QueryMode.Update,
                    config.GetCommandParameters(),
                    commandPrintOutput,
                    config.QueryExecutionTimeout);

                Log("Execution Completed Successfully...");

                if (!String.IsNullOrEmpty(commandPrintOutput.ToString()))
                {
                    Log("*************************************************************");
                    Log(config.GetCommandOperation() + " started @ " + DateTime.Now.ToShortDateString()
                        + " " + DateTime.Now.ToShortTimeString());
                    Log("*************************************************************");
                    Log(commandPrintOutput.ToString());

                    Log("*************************************************************");
                    Log("Execution successful @ " + DateTime.Now.ToShortDateString()
                        + " " + DateTime.Now.ToShortTimeString());
                    Log("*************************************************************");
                }

                if (config is IndexConfig)
                {
                    // get the post screenshot
                    Log("*****************************************************");
                    Log("After Snapshot for the fragmenation levels");
                    Log("*****************************************************");
                    LogDBFragLevel(config as IndexConfig);
                }

                // Mail Reports
                SystemConfig systemConfig = SystemConfig.GetInstance();

                if (systemConfig.CompressBackup && config is DoBackupConfig)
                {
                    // compression logic here
                    string compressedPath = Utility.CompressLastBackup();
                    Log("Backup File Successfully Compressed @ " + compressedPath);
                    compressedPath = null;
                }

                if (systemConfig.MailAlerts)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<p>Hi,</p>");
                    builder.Append("<p>Scheduled [IndexOptimize] on database completed Successfully @ ");
                    builder.Append(DateTime.Now.ToString());
                    builder.Append("<br />The complete log of execution is attached. For any issues concerns please write");
                    builder.Append(" to us @ <a href=\"mailTo:footstepsinfotech@gmail.com\" title=\"Write to Us\">");
                    builder.Append("footstepsinfotech@gmail.com</a> or visit ");
                    builder.Append("<a href=\"http://www.footstepsinfotech.com/\" title=\"Footsteps Infotech Inc.\">");
                    builder.Append("www.footstepsinfotech.com</a></p><p>");
                    builder.Append("You can check the full execution log @ IndexOptimize_05052015020336.log</p>");
                    builder.Append("~<br />Thanks,<br />DB Health Check<br />© Footsteps Infotech Inc.");
                    MailUtility mailUtils = new MailUtility(systemConfig);
                    mailUtils.SendMail(builder.ToString(), "DB Health Check : "
                        + config.GetCommandOperation() + " execution completed successfully", LogFilePath, false);

                    builder.Clear();
                    builder = null;
                    mailUtils = null;
                }
            }
            catch (Exception e)
            {
                if (args.Length < 2)
                {
                    Log("Please pass the configuration name for execution");
                    Log("Execute the program as Program -c <configName>");
                    throw new ArgumentException("Please pass the configuration name for execution");
                }
                Log("Program invoked successfully... " + args);
                Log(e);
            }
        }

        private void LogDBFragLevel(IndexConfig config)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("USE ");
            builder.Append(config.DatabaseName);
            builder.Append("\r\n");

            builder.Append("SELECT DB_NAME(DPS.DATABASE_ID) AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.DATABASE_NAME);
            builder.Append(",OBJECT_NAME(DPS.OBJECT_ID) AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.TABLE_NAME);
            builder.Append(",SI.NAME AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.INDEX_NAME);
            builder.Append(",DPS.INDEX_TYPE_DESC AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.INDEX_TYPE);
            builder.Append(",DPS.AVG_FRAGMENTATION_IN_PERCENT AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.AVG_PAGE_FRAGMENTATION);
            builder.Append(",DPS.PAGE_COUNT AS ");
            builder.Append(DBHealthCheckExecAction.Utils.Constants.PAGE_COUNTS);
            builder.Append(" FROM sys.dm_db_index_physical_stats");
            builder.Append(" (DB_ID(), NULL, NULL , NULL, NULL) DPS INNER JOIN sysindexes SI ");
            builder.Append("ON DPS.OBJECT_ID = SI.ID AND DPS.INDEX_ID = SI.INDID "); 
            // WHERE DPS.AVG_FRAGMENTATION_IN_PERCENT > 1 ");
            builder.Append("ORDER BY DPS.avg_fragmentation_in_percent DESC ");

            DatabaseManager manager = new DatabaseManager();
            List<object> items = manager.ExecuteQuery(builder.ToString(),
                QueryMode.Reader, null, new FragmentationMeasurer()) as List<object>;

            // logging
            string line = FormatedSpace("DatabaseName", 30) + "\t" + FormatedSpace("TableName", 30) + "\t"
                + FormatedSpace("IndexType", 30) + "\t" + FormatedSpace("IndexName", 80) + "\t"
                + FormatedSpace("AvgPageFragmentation", 30) + "\t" + FormatedSpace("PageCounts", 15);
            Log(line);
            line = FormatedSpace("*", 30, '*') + "\t" + FormatedSpace("*", 30, '*') + "\t" + FormatedSpace("*", 30, '*') + "\t"
                + FormatedSpace("*", 80, '*') + "\t" + FormatedSpace("*", 30, '*') + "\t" + FormatedSpace("*", 15, '*');
            Log(line);
            foreach (object obj in items)
            {
                FragmentationMeasurer measurer = obj as FragmentationMeasurer;
                line = FormatedSpace(measurer.DatabaseName, 30) + "\t" + FormatedSpace(measurer.TableName, 30) + "\t"
                    + FormatedSpace(measurer.IndexType, 30) + "\t" + FormatedSpace(measurer.IndexName, 80) + "\t"
                    + FormatedSpace(measurer.AvgPageFragmentation.ToString(), 30) + "\t"
                    + FormatedSpace(measurer.PageCounts.ToString(), 15);

                Log(line);
            }
        }

        private ScheduleConfig GetConfigFromFileName(string[] args)
        {
            string _config = args[1];
            ConfigType configType = (ConfigType)Enum.Parse(typeof(ConfigType), _config);
            switch (configType)
            {
                case ConfigType.DoBackupConfig:
                    string type = args[3];
                    return DoBackupConfig.GetInstance(type.ToUpper());
                case ConfigType.IndexConfig:
                    return IndexConfig.GetInstance();
                case ConfigType.IntegrityCheckConfig:
                    return IntegrityCheckConfig.GetInstance();
            }
            return null;
        }

        private void Log(string message)
        {
            if (String.IsNullOrEmpty(LogFilePath))
                LogFilePath = DateTime.Now.ToString("ddMMyyyy") + ".log";

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\" + LogFilePath;

            // if (!File.Exists(path))
               // File.Create(path);

            File.AppendAllText(path, message + Environment.NewLine);
        }

        private void Log(Exception e)
        {
            Log(e.Message);
            Log(Environment.NewLine);
            Log(e.StackTrace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">value to be shown</param>
        /// <param name="fixedLen">Maximum length of that field</param>
        /// <param name="appendChar"></param>
        /// <returns>Formatted Text</returns>
        public static string FormatedSpace(string val, int fixedLen, char appendChar = ' ')
        {
            // Say, fixedLen = 20 [datatype in DB.table.Col = Varchar(20)]
            // & say, val = "Ruaha" Then there we are addaing 20-5=15 spaces after ruaha
            // Making it "ruaha               "
            // So that presentation in the table format in corr. Text file remains nice.       
            int len = 0;
            string retVal = string.Empty;
            try
            {
                len = val.Length;
                retVal = val;
                for (int cnt = 0; cnt < fixedLen - len - 1; cnt++)
                    retVal += appendChar;
            }
            catch (Exception)
            {
                throw;
            }
            return retVal;
        }
    }
}
