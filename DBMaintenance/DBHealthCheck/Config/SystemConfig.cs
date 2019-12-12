using System;
using DBHealthCheck.Utils;
using DBManager;

namespace DBHealthCheck.Config
{
    public class SystemConfig : ConfigValue, IMailConfig
    {
        public static readonly string DOMAIN_NAME = "system";
        // singleton class
        private static SystemConfig _config;

        #region Variable Declaration
        private bool _mailAlerts;
        private string _mailServer;
        private int _mailServerPort;
        private string _emailFrom;
        private string _displayName;
        private string _userName;
        private string _password;
        private string _mailTo;
        private string _testMailText;
        private bool _automaticScheduling;
        private bool _compressBackup;
        #endregion

        #region Properties
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                ModifyEntry("PASSWORD", value.ToString(), DOMAIN_NAME, true, true);
                _password = value;
            }
        }
        
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                ModifyEntry("USER_NAME", value.ToString(), DOMAIN_NAME);
                _userName = value;
            }
        }
        
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                ModifyEntry("DISPLAY_NAME", value.ToString(), DOMAIN_NAME);
                _displayName = value;
            }
        }
        
        public string EmailFrom
        {
            get
            {
                return _emailFrom;
            }
            set
            {
                ModifyEntry("EMAIL_FROM", value.ToString(), DOMAIN_NAME);
                _emailFrom = value;
            }
        }
        
        public bool MailAlerts
        {
            get
            {
                return _mailAlerts;
            }
            set
            {
                ModifyEntry("MAIL_ALERTS", value.ToString(), DOMAIN_NAME);
                _mailAlerts = value;
            }
        }

        public bool AutomaticScheduling
        {
            get
            {
                return _automaticScheduling;
            }
            set
            {
                ModifyEntry("AUTOMATIC_SCHEDULING", value.ToString(), DOMAIN_NAME);
                _automaticScheduling = value;
            }
        }

        public bool CompressBackup
        {
            get
            {
                return _compressBackup;
            }
            set
            {
                ModifyEntry("COMPRESS_BACKUP", value.ToString(), DOMAIN_NAME);
                _compressBackup = value;
            }
        }

        public string MailServer
        {
            get
            {
                return _mailServer;
            }
            set
            {
                ModifyEntry("MAIL_SERVER", value.ToString(), DOMAIN_NAME);
                _mailServer = value;
            }
        }

        public int MailServerPort
        {
            get
            {
                return _mailServerPort;
            }
            set
            {
                ModifyEntry("MAIL_SERVER_PORT", value.ToString(), DOMAIN_NAME);
                _mailServerPort = value;
            }
        }

        public string MailTo
        {
            get
            {
                return _mailTo;
            }
            set
            {
                ModifyEntry("MAIL_TO", value, DOMAIN_NAME);
                _mailTo = value;
            }
        }
        public string TestMailText
        {
            get
            {
                return _testMailText;
            }
            private set
            {
                ModifyEntry("TEST_MAIL_TEXT", value, DOMAIN_NAME);
                _testMailText = value;
            }
        }
        #endregion

        private SystemConfig()
        {
            _mailAlerts = Convert.ToBoolean(GetEntry("MAIL_ALERTS", DOMAIN_NAME));
            _mailServer = Convert.ToString(GetEntry("MAIL_SERVER", DOMAIN_NAME));
            _mailServerPort = Convert.ToInt32(GetEntry("MAIL_SERVER_PORT", DOMAIN_NAME));
            _emailFrom = Convert.ToString(GetEntry("EMAIL_FROM", DOMAIN_NAME));
            _displayName = Convert.ToString(GetEntry("DISPLAY_NAME", DOMAIN_NAME));
            _userName = Convert.ToString(GetEntry("USER_NAME", DOMAIN_NAME));
            _password = Convert.ToString(GetEntry("PASSWORD", DOMAIN_NAME, true));
            _mailTo = Convert.ToString(GetEntry("MAIL_TO", DOMAIN_NAME));
            _testMailText = Convert.ToString(GetEntry("TEST_MAIL_TEXT", DOMAIN_NAME));
            _automaticScheduling = Convert.ToBoolean(GetEntry("AUTOMATIC_SCHEDULING", DOMAIN_NAME));
            _compressBackup = Convert.ToBoolean(GetEntry("COMPRESS_BACKUP", DOMAIN_NAME));
        }

        public static SystemConfig GetInstance()
        {
            if (_config == null)
                _config = new SystemConfig();

            return _config;
        }
    }
}
