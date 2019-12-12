using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBHealthCheck.Utils
{
    public enum RunInterval
    {
        None = -1,
        Hourly = 0,
        Daily = 1,
        Weekly = 7,
        Fortnightly = 15,
        Monthly = 30,
        Yearly = 365
    }

    public enum ConfigType
    {
        IndexConfig = 1,
        DoBackupConfig = 2,
        IntegrityCheckConfig = 3
    }
}
