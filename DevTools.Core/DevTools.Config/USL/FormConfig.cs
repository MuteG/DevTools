using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DevTools.Language;

namespace DevTools.Config.USL
{
    /// <summary>
    /// 配置文件设置窗体
    /// </summary>
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }
        
        private void FormConfigLoad(object sender, EventArgs e)
        {
            LoadConfigList();
            LoadLanguage();
        }

        private List<ConfigPanelBase> configPanelList = new List<ConfigPanelBase>();
        
        private void LoadConfigList()
        {
            configPanelList.Clear();
            foreach (ConfigBase config in ConfigManager.ConfigList)
            {
                string moduleName = config.GetType().Assembly.GetName().Name;
                int index = this.listBoxConfig.Items.Add(ConfigManager.GetDisplayName(config.Key));
                ConfigPanelBase configPanel = ConfigManager.GetConfigPanel(config.Key);
                configPanel.Config = config;
                configPanel.Dock = DockStyle.Fill;
                this.panelConfig.Controls.Add(configPanel);
                configPanelList.Add(configPanel);
            }
            if (ConfigManager.ConfigList.Count > 0)
            {
                this.listBoxConfig.SelectedIndex = 0;
            }
        }
        
        private void LoadLanguage()
        {
            LanguageManager.GetString(this);
            LanguageManager.GetString(buttonSave);
            LanguageManager.GetString(buttonClose);

            foreach (ConfigPanelBase configPanel in configPanelList)
            {
                configPanel.LoadLanguage();
            }
        }
        
        private void ListBoxConfigSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxConfig.SelectedIndex > -1)
            {
                ConfigPanelBase configPanel = configPanelList[this.listBoxConfig.SelectedIndex];
                configPanel.Show();
                configPanel.BringToFront();
            }
        }
        
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            foreach (ConfigPanelBase configPanel in configPanelList)
            {
                configPanel.Save();
            }
            ConfigManager.Save();
            LoadLanguage();
            MessageBox.Show("All configuration have been saved.");
        }
        
        private void FormConfigFormClosing(object sender, FormClosingEventArgs e)
        {
            this.listBoxConfig.Items.Clear();
            this.panelConfig.Controls.Clear();
        }
        
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
