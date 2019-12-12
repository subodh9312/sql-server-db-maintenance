using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DBManager;
using DBManager.Utils;
using UserConfig.Utils;
using System.Reflection;

namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConnectConfig : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public ConnectConfig()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            string connectionString = DBUtils.GetConnectionString(assembly.Location);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

            string dataSource = builder.DataSource;

            if (dataSource.IndexOf(@"\") != -1)
            {
                string[] parts = dataSource.Split('\\');
                serverIPTextBox.Text = parts[0];
                instanceTextBox.Text = parts[1];
            }
            else
            {
                serverIPTextBox.Text = dataSource;
                instanceTextBox.Text = "";
            }

            databaseTextBox.Text = builder.InitialCatalog;
            userTextBox.Text = builder.UserID;
            passwordTextBox.Text = builder.Password;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            IDictionary<string, string> values = ValidateInput(ref builder);

            builder = new StringBuilder(DBConstants.CONNECTION_STRING_TEMPLATE);

            builder = builder.Replace("<ServerName>", values["serverIP"] 
                + @"\" + values["instanceName"]);
            builder = builder.Replace("<DatabaseName>", values["databaseName"]);
            builder = builder.Replace("<UserId>", values["userId"]);
            builder.Replace("<Password>", values["password"]);

            string connectionString = builder.ToString();

            string exePath = String.Format("{0}UserConfig.exe", AppDomain.CurrentDomain.BaseDirectory);

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(exePath);

            ConnectionStringSettings settings = new ConnectionStringSettings();
            settings.Name = DBConstants.CONNECTION_STRING_NAME;
            settings.ConnectionString = connectionString;

            configuration.ConnectionStrings.ConnectionStrings.Clear();
            configuration.ConnectionStrings.ConnectionStrings.Add(settings);
            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");

            MessageBox.Show("Connection Parameters Modified Successfully", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override IDictionary<string, string> ValidateInput(ref StringBuilder builder)
        {
            IDictionary<string, string> values = new Dictionary<string, string>();

            #region Server IP Validations
            if (String.IsNullOrEmpty(serverIPTextBox.Text))
            {
                builder.Append("ERR: Server IP Address is mandatory.");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values["serverIP"] = serverIPTextBox.Text.Trim();
            }
            #endregion

            #region Instance Name Validations
            if (String.IsNullOrEmpty(instanceTextBox.Text))
            {
                builder.Append("ERR: Instance Name is mandatory.");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values["instanceName"] = instanceTextBox.Text.Trim();
            }
            #endregion

            #region Database Name Validations
            if (String.IsNullOrEmpty(databaseTextBox.Text))
            {
                builder.Append("ERR: Database Name is mandatory.");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values["databaseName"] = databaseTextBox.Text.Trim();
            }
            #endregion

            #region User Id Validations
            if (String.IsNullOrEmpty(userTextBox.Text))
            {
                builder.Append("ERR: User ID is mandatory.");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values["userId"] = userTextBox.Text.Trim();
            }
            #endregion

            #region Password Validations
            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                builder.Append("ERR: Password is mandatory.");
                builder.Append(Environment.NewLine);
            }
            else
            {
                values["password"] = passwordTextBox.Text.Trim();
            }
            #endregion

            return values;
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            DatabaseManager manager = new DatabaseManager();
            try
            {
                object obj = manager.ExecuteQuery("SELECT 1", QueryMode.Scalar);

                if (obj != null)
                {
                    MessageBox.Show("Connection Succeeded!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed, with errors details" + Environment.NewLine + ex.Message, "Failure",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
