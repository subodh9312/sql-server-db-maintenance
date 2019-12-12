using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBHealthCheck.Utils
{
    public static class Constants
    {
        public const string FRAGMENTATION_LEVEL_1 = "FRAGMENTATION_LEVEL_1";
        public const string FRAGMENTATION_LEVEL_2 = "FRAGMENTATION_LEVEL_2";
        public const string OPERATION_SEQUENCE = "OPERATION_SEQUENCE";
        public const string MINIMUM_PAGE_COUNT = "MINIMUM_PAGE_COUNT";
        public const string EXECUTION_TIMEOUT = "EXECUTION_TIMEOUT";
        public const string FILL_FACTOR = "FILL_FACTOR";
        public const string DATABASE_NAME = "DATABASE_NAME";
        public const string DATABASE_SIZE = "DATABASE_SIZE";
        public const string UPDATE_STATISTICS = "UPDATE_STATISTICS";

        public const string RUN_INTERVAL = "RUN_INTERVAL";
        public const string ADDITIONAL_INFO = "ADDITIONAL_INFORMATION";

        public const string CHECK_COMMAND = "CHECK_COMMAND";
        public const string PHYSICAL_ONLY = "PHYSICAL_ONLY";
        public const string EXTENDED_LOGICAL_CHECKS = "EXTENDED_CHECKS";
        public const string EXCLUDE_INDEXES = "NO_INDEXES";

        public const string BACKUP_DIRECTORY = "BACKUP_DIRECTORY";
        public const string VERIFY_ONLY = "VERIFY_ONLY";
        public const string BACKUP_TYPE = "BACKUP_TYPE";
        public const string CHECKSUM = "CHECKSUM";
    }
}
