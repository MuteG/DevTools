using System;
using System.Drawing;
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
            LoadLanguage();
        }
        
        private void LoadConfigList()
        {
            foreach (ConfigBase config in ConfigManager.ConfigList)
            {
                string moduleName = config.GetType().Assembly.GetName().Name;
                this.listBoxConfig.Items.Add(moduleName);
            }
        }
        
        private void LoadLanguage()
        {
            LanguageManager.GetString(this);
            LanguageManager.GetString(buttonSave);
            LanguageManager.GetString(buttonClose);
        }
        
        private void ListBoxConfigSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxConfig.SelectedIndex > -1)
            {
                string moduleName = this.listBoxConfig.SelectedItem.ToString();
                ConfigBase config = ConfigManager.GetConfig(moduleName);
            }
        }
    }
}
