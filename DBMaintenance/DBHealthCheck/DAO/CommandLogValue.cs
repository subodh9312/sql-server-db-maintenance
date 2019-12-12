using System;
using System.Data.SqlClient;
using DBManager;

namespace DBHealthCheck.DAO
{
    public class CommandLogValue : IDBValue
    {
        public int Id { get; private set; }
        public string DatabaseName { get; private set; }
        public string SchemaName { get; private set; }
        public string ObjectName { get; private set; }
        public string ObjectType { get; private set; }
        public string IndexName { get; private set; }
        public string IndexType { get; private set; }
        public string StatisticsName { get; private set; }
        public int? PartitionNumber { get; private set; }
        public string ExtendedInfo { get; private set; }
        public string Command { get; private set; }
        public string CommandType { get; private set; }
        public Nullable<DateTime> StartTime { get; private set; }
        public Nullable<DateTime> EndTime { get; private set; }
        public int? ErrorNumber { get; private set; }
        public string ErrorMessage { get; private set; }

        public object RestoreObject(SqlDataReader reader)
        {
            CommandLogValue value = new CommandLogValue();

            value.Id = Convert.ToInt32(reader["Id"]);
            value.DatabaseName = reader["DatabaseName"] as string;
            value.SchemaName = reader["SchemaName"] as string;
            value.ObjectName = reader["ObjectName"] as string;
            value.ObjectType = reader["ObjectType"] as string;
            value.IndexName = reader["IndexName"] as string;
            value.IndexType = reader["IndexType"] as string;
            value.StatisticsName = reader["StatisticsName"] as string;
            value.PartitionNumber = reader["PartitionNumber"] as int?;
            value.ExtendedInfo = reader["ExtendedInfo"] as string;
            value.Command = reader["Command"] as string;
            value.CommandType = reader["CommandType"] as string;
            value.StartTime = reader["StartTime"] as Nullable<DateTime>;
            value.EndTime = reader["EndTime"] as Nullable<DateTime>;
            value.ErrorNumber = reader["ErrorNumber"] as int?;
            value.ErrorMessage = reader["ErrorMessage"] as string;

            return value;
        }
    }
}
