using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevTools.Config;
using DevTools.Plugin.DBTool.Core.Config;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();

            dbToolConfigPanel1.Config = ConfigManager.GetConfig(new DBToolConfig().Key);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dbToolConfigPanel1.Save();
            ConfigManager.Save(dbToolConfigPanel1.Config);
            MessageBox.Show("Configuration has been saved.");
        }
    }
}
