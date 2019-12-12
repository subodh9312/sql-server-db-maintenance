using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DBHealthCheck.Config;
using DBManager;
using DBManager.Utils;
using UserConfig.Utils;

namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Main : BaseForm
    {
        private SystemConfig _config;
 
        /// <summary>
        /// 
        /// </summary>
        public Main()
            : base()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = { "UserConfig.InstallConfig.sql", 
                                                 "UserConfig.InstallDBMaintenance.sql" };

            DBUtils.SetupDatabase(assembly, resourceNames);
            _config = SystemConfig.GetInstance();

            ToolStripItem[] items = menuStrip.Items.Find("enableMailAlertsToolStripMenuItem", true);
            foreach (ToolStripItem item in items)
                ToogleMenuItem(item, _config.MailAlerts, "mailSetupParametersToolStripMenuItem");

            items = menuStrip.Items.Find("schedulingToolStripMenuItem", true);
            foreach (ToolStripItem item in items)
                ToogleMenuItem(item, _config.AutomaticScheduling);

            items = menuStrip.Items.Find("compressBackupToolStripMenuItem", true);
            foreach (ToolStripItem item in items)
                ToogleMenuItem(item, _config.CompressBackup);

        }

        private void runScheduleParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new RunConfig());
        }

        private void databaseIntegrityCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new IntegrityConfig());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            aboutBox.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.CloseAllForms();
        }

        private void connectionParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new ConnectConfig());
        }

        private void enableMailAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _config.MailAlerts = !_config.MailAlerts;
            ToogleMenuItem(sender as ToolStripItem, _config.MailAlerts, "mailSetupParametersToolStripMenuItem");
            string message = "Mailing successfully ";
            message += _config.MailAlerts ? "Enabled" : "Disabled";
            MessageBox.Show(message, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void ToogleMenuItem(ToolStripItem item, bool value, string id = null)
        {
            string temp = item.Text;
            if (item.Text.IndexOf("(") != -1)
                temp = temp.Substring(0, temp.IndexOf("("));
            if (value)
            {
                // already enabled
                string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"image.png");
                item.Image = Image.FromFile(path);
                item.Text = temp + " (Click to Disable)";
            }
            else
            {
                // already diabled
                item.Image = null;
                item.Text = temp + " (Click to Enable)";
            }
            if (!String.IsNullOrEmpty(id))
            {
                ToolStripItem[] items = menuStrip.Items.Find(id, true);
                foreach (ToolStripItem i in items)
                    i.Enabled = value;
            }
        }

        private void mailSetupParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new MailConfig());
        }

        private void fullBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new BackupConfig("FULL"));
        }

        private void differentialBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new BackupConfig("DIFF"));
        }

        private void logBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowChildForm(new BackupConfig("LOG"));
        }

        private void schedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _config.AutomaticScheduling = !_config.AutomaticScheduling;
            ToogleMenuItem(sender as ToolStripItem, _config.AutomaticScheduling, "schedulingToolStripMenuItem");
            string message = "Scheduling Successfully ";
            message += _config.AutomaticScheduling ? "Enabled" : "Disabled";
            MessageBox.Show(message, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void compressBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _config.CompressBackup = !_config.CompressBackup;
            ToogleMenuItem(sender as ToolStripItem, _config.CompressBackup, "compressBackupToolStripMenuItem");
            string message = "Database Backup Compression Successfully ";
            message += _config.CompressBackup ? "Enabled" : "Disabled";
            MessageBox.Show(message, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
