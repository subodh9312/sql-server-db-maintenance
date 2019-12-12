using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using DBManager;
using DBManager.Library;
using DBManager.Utils;
using System.Text;


namespace UserConfig
{
    /// <summary>
    /// 
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : ConnectionStringInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
