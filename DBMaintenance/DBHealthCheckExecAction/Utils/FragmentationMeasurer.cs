using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBManager;
using System.Data.SqlClient;

namespace DBHealthCheckExecAction.Utils
{
    public class FragmentationMeasurer : IDBValue
    {
        public string DatabaseName { get; private set; }
        public string TableName { get; private set; }
        public string IndexName { get; private set; }
        public string IndexType { get; private set; }
        public double AvgPageFragmentation { get; private set; }
        public int PageCounts { get; private set; }

        public object RestoreObject(SqlDataReader reader)
        {
            FragmentationMeasurer measurer = new FragmentationMeasurer();
            measurer.DatabaseName = reader[Constants.DATABASE_NAME] as string;
            measurer.TableName = reader[Constants.TABLE_NAME] as string;
            measurer.IndexName = reader[Constants.INDEX_NAME] as string;
            measurer.PageCounts = Convert.ToInt32(reader[Constants.PAGE_COUNTS]);
            measurer.AvgPageFragmentation = Convert.ToDouble(reader[Constants.AVG_PAGE_FRAGMENTATION]);
            measurer.IndexType = reader[Constants.INDEX_TYPE] as string;

            return measurer;
        }
    }
}
