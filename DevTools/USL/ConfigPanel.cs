using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using DevTools.Config;
using DevTools.Config.USL;
using DevTools.Language;

namespace DevTools.USL
{
    /// <summary>
    /// 配置面板
    /// </summary>
    public partial class ConfigPanel : ConfigPanelBase
    {
        public ConfigPanel()
        {
            InitializeComponent();
        }
        
        protected override void ShowConfig(ConfigBase config)
        {
            SetConfig();
        }
        
        protected override void SaveConfig(ref ConfigBase config)
        {
            base.SaveConfig(ref config);
        }
        
        private void SetConfig()
        {
            SetFont();
            SetLanguageComboBox();
        }
        
        private void SetFont()
        {
            DevToolsConfig config = base.Config as DevToolsConfig;
            if (!string.IsNullOrEmpty(config.FontName) &&
                0 != config.FontSize)
            {
                this.Font = new Font(config.FontName, config.FontSize);
                SetFontTextBox();
            }
        }
        
        private void ButtonFontClick(object sender, EventArgs e)
        {
            DevToolsConfig config = this.Config as DevToolsConfig;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                config.FontName = fontDialog.Font.FontFamily.Name;
                config.FontSize = fontDialog.Font.Size;
                SetFontTextBox();
            }
        }
        
        private void SetFontTextBox()
        {
            DevToolsConfig config = this.Config as DevToolsConfig;
            textBoxFont.Text =
                string.Format("{0}, {1}",
                              config.FontName, config.FontSize);
        }
        
        private void SetLanguageComboBox()
        {
            DevToolsConfig config = this.Config as DevToolsConfig;
            string currentLanguage = config.Language;
            
            comboBoxLanguage.DisplayMember = "Display";
            comboBoxLanguage.ValueMember = "Name";
            comboBoxLanguage.DataSource = LanguageManager.LanguageList;
                
            if (!string.IsNullOrEmpty(currentLanguage))
            {
                comboBoxLanguage.SelectedItem =
                    LanguageManager.LanguageList
                    .Find(lang => lang.Name.Equals(currentLanguage));
            }
        }
        
        private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            DevToolsConfig config = this.Config as DevToolsConfig;
            if (comboBoxLanguage.SelectedIndex > -1)
            {
                config.Language =
                    comboBoxLanguage.SelectedValue.ToString();
                LanguageManager.Code = config.Language;
            }
        }
    }
}
