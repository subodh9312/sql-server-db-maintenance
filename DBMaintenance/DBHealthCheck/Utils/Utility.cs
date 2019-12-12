using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using DBHealthCheck.DAO;
using DBManager;
using DBManager.Utils;

namespace DBHealthCheck.Utils
{
    public static class Utility
    {
        public static string Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            string path = null;
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile =
                                File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);
                            // everything seems ok
                            path = fi.FullName + ".gz";
                        }
                    }
                }
            }
            return path;
        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        Decompress.CopyTo(outFile);

                        Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }

        public static string ReadFile(string fileName, bool isAbsolute = false)
        {
            string retValue = null;

            if (!isAbsolute)
                fileName = AppDomain.CurrentDomain.BaseDirectory + fileName;

            StreamReader stream = File.OpenText(fileName);
            retValue = stream.ReadToEnd();
            stream.Close();

            return retValue;
        }

        public static List<CommandLogValue> GetLastExecutionCommandLogs(string commandType)
        {
            string sql = "SELECT [ID],[DatabaseName],[SchemaName],[ObjectName],";
            sql += "[ObjectType],[IndexName],[IndexType],[StatisticsName],[PartitionNumber],";
            sql += "[ExtendedInfo],[Command],[CommandType],[StartTime],[EndTime],[ErrorNumber]";
            sql += ",[ErrorMessage] FROM CommandLog WHERE CommandType = @CommandType Order By Id Desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CommandType", commandType));
            List<CommandLogValue> values = new List<CommandLogValue>();

            DatabaseManager manager = new DatabaseManager();
            List<object> objects = manager.ExecuteQuery(sql, QueryMode.Reader, parameters.ToArray(), new CommandLogValue()) as List<object>;
            if (objects != null)
            {
                foreach (object obj in objects)
                {
                    CommandLogValue value = obj as CommandLogValue;
                    if (obj != null)
                        values.Add(value);
                }
            }
            return values;
        }

        public static string GetBackupFilePath(string executionCommand)
        {
            // BACKUP DATABASE [Temp] TO DISK = N'D:\SUBODH-PC$SQLEXPRESS\Temp\FULL\SUBODH-PC$SQLEXPRESS_Temp_FULL_20150130_104324.bak' WITH NO_CHECKSUM, NO_COMPRESSION;
            if (executionCommand.IndexOf("N'") != -1)
            {
                string temp = executionCommand.Substring(executionCommand.IndexOf("N'") + "N'".Length);
                temp = temp.Substring(0, temp.IndexOf("'"));
                return temp;
            }
            return null;
        }

        public static string CompressLastBackup()
        {
            List<CommandLogValue> values = Utility.GetLastExecutionCommandLogs("BACKUP_DATABASE");
            if (values.Count > 0)
            {
                CommandLogValue value = values[0];
                string backupFilePath = Utility.GetBackupFilePath(value.Command);
                if (!String.IsNullOrEmpty(backupFilePath))
                {
                    string compressedPath = Utility.Compress(new FileInfo(backupFilePath));
                    // compression successful
                    // delete the uncompressed file
                    if (!String.IsNullOrEmpty(compressedPath))
                        File.Delete(backupFilePath);
                    return compressedPath;
                }
            }
            return null;
        }
    }
}
