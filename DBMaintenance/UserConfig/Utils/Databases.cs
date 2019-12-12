using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBManager;
using System.Data.SqlClient;
using DBHealthCheck.Utils;

namespace UserConfig.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class Databases : IDBValue
    {
        private string databaseName;
        private int databaseSize;

        /// <summary>
        /// 
        /// </summary>
        public Databases() : this (null, 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbSize"></param>
        public Databases(string dbName, int dbSize)
        {
            databaseName = dbName;
            databaseSize = dbSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public object RestoreObject(SqlDataReader reader)
        {
            string dbName = reader[Constants.DATABASE_NAME].ToString();
            string dbSize = reader[Constants.DATABASE_SIZE].ToString();
            string[] dbNamesToIgnore = { "master", "tempdb", "msdb", "model" };

            if (dbNamesToIgnore.Contains(dbName)) 
            {
                // we ignore these databases as these are System defined
                return null;
            }
            else
            {
                return new Databases(dbName, Convert.ToInt32(dbSize));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return databaseName;
        }
    }
}
