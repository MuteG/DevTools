using System;
using System.Drawing;
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
        
        private void LoadConfigList()
        {
            foreach (ConfigBase config in ConfigManager.ConfigList)
            {
                string moduleName = config.GetType().Assembly.GetName().Name;
                int index = this.listBoxConfig.Items.Add(moduleName);
                ConfigPanelBase configPanel = ConfigManager.GetConfigPanel(config);
                configPanel.Config = config;
                this.panelConfig.Controls.Add(configPanel);
            }
        }
        
        private void LoadLanguage()
        {
            LanguageManager.GetString(this);
            LanguageManager.GetString(buttonSave);
            LanguageManager.GetString(buttonClose);
            
            foreach (var item in listBoxConfig.Items)
            {
                ConfigBase config = ConfigManager.GetConfig(item.ToString());
                ConfigPanelBase configPanel = ConfigManager.GetConfigPanel(config);
                configPanel.LoadLanguage();
            }
        }
        
        private void ListBoxConfigSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxConfig.SelectedIndex > -1)
            {
                string moduleName = this.listBoxConfig.SelectedItem.ToString();
                ConfigBase config = ConfigManager.GetConfig(moduleName);
                ConfigPanelBase configPanel = ConfigManager.GetConfigPanel(config);
                configPanel.Show();
                configPanel.BringToFront();
            }
        }
        
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            ConfigManager.Save();
            LoadLanguage();
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
