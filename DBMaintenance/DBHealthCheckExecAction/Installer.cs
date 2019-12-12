using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using DBManager;

namespace DBHealthCheckExecAction
{
    [RunInstaller(true)]
    public partial class Installer : ConnectionStringInstaller
    {
        public Installer()
        {
            InitializeComponent();
        }
    }
}
