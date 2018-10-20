using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevTools.Config;
using DevTools.Config.USL;
using DevTools.Plugin.DBTool.Core.Data;

namespace DevTools.Plugin.DBTool.Core.Config
{
    public partial class DBToolConfigPanel : ConfigPanelBase
    {
        public DBToolConfigPanel()
        {
            InitializeComponent();

            cbxDatabaseType.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(DatabaseType)))
            {
                cbxDatabaseType.Items.Add(name);
            }
            cbxDatabaseType.SelectedItem = DatabaseType.Oracle.ToString();
        }

        protected override void ShowConfig(ConfigBase config)
        {
            DBToolConfig dbToolConfig = config as DBToolConfig;
            BindingList<DBToolConnection> data = new BindingList<DBToolConnection>(dbToolConfig.Connections);
            comboBoxName.DataSource = data;
            if (comboBoxName.Items.Count > 0)
            {
                comboBoxName.SelectedIndex = 0;
            }
        }

        protected override void SaveConfig(ConfigBase config)
        {
            DBToolConfig dbToolConfig = config as DBToolConfig;
            string name = comboBoxName.Text;
            DBToolConnection conn = dbToolConfig.Connections.FirstOrDefault(c => c.Name == name);
            if (conn == null)
            {
                conn = new DBToolConnection();
                conn.Name = name;
                conn.Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), cbxDatabaseType.Text);
                conn.DataSource = textBoxDataSource.Text;
                conn.Username = textBoxUsername.Text;
                conn.Password = textBoxPassword.Text;
                dbToolConfig.Connections.Add(conn);

                (comboBoxName.DataSource as BindingList<DBToolConnection>).ResetBindings();
                comboBoxName.SelectedIndex = dbToolConfig.Connections.Count - 1;
            }
            else
            {
                conn.Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), cbxDatabaseType.Text);
                conn.DataSource = textBoxDataSource.Text;
                conn.Username = textBoxUsername.Text;
                conn.Password = textBoxPassword.Text;
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxName.SelectedItem == null)
            {
                return;
            }
            DBToolConnection conn = comboBoxName.SelectedItem as DBToolConnection;
            textBoxDataSource.Text = conn.DataSource;
            textBoxUsername.Text = conn.Username;
            textBoxPassword.Text = conn.Password;
            cbxDatabaseType.SelectedItem = conn.Type.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lblTestResult.Text = "Connecting...";
            Application.DoEvents();

            DBToolConnection conn = new DBToolConnection();
            conn.Name = comboBoxName.Text;
            conn.Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), cbxDatabaseType.Text);
            conn.DataSource = textBoxDataSource.Text;
            conn.Username = textBoxUsername.Text;
            conn.Password = textBoxPassword.Text;

            DBBrowserLoader loader = new DBBrowserLoader();
            IDBBrowsable browser = loader.GetBrowser(conn);
            bool testSuccessed = browser.TestConnection();
            if (testSuccessed)
            {
                lblTestResult.Text = "Success";
            }
            else
            {
                lblTestResult.Text = "Fail";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBToolConfig dbToolConfig = base.Config as DBToolConfig;
            string name = comboBoxName.Text;
            DBToolConnection conn = dbToolConfig.Connections.FirstOrDefault(c => c.Name == name);
            if (conn != null)
            {
                dbToolConfig.Connections.Remove(conn);
                (comboBoxName.DataSource as BindingList<DBToolConnection>).ResetBindings();
                comboBoxName.SelectedIndex = dbToolConfig.Connections.Count - 1;
            }
        }
    }
}
