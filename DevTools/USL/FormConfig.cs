using System;
using System.Drawing;
using System.Windows.Forms;

using DevTools.Config;
using DevTools.Language;

namespace DevTools.USL
{
    /// <summary>
    /// 设定窗体
    /// </summary>
    public partial class FormConfig : Form
    {
        private ConfigBase config;
        
        public DevToolsConfig Config
        {
            get
            {
                return this.config as DevToolsConfig;
            }
        }
        
        public FormConfig()
        {
            InitializeComponent();
        }
        
        private void FormConfigLoad(object sender, EventArgs e)
        {
            LoadLanguage();
            
            config = new DevToolsConfig();
            ConfigManager.GetConfig(ref config);
            
            SetConfig();
        }
        
        private void LoadLanguage()
        {
            LanguageManager.GetString(labelFont);
            LanguageManager.GetString(buttonFont);
            LanguageManager.GetString(labelLanguage);
            LanguageManager.GetString(buttonSave);
        }
        
        private void SetConfig()
        {
            SetFont();
            SetLanguageComboBox();
        }
        
        private void SetFont()
        {
            if (!string.IsNullOrEmpty(this.Config.FontName) &&
                0 != this.Config.FontSize)
            {
                this.Font = new Font(this.Config.FontName, this.Config.FontSize);
                SetFontTextBox();
            }
        }
        
        private void SetLanguageComboBox()
        {
            string currentLanguage = this.Config.Language;
            
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

        private void SetFontTextBox()
        {
            textBoxFont.Text =
                string.Format("{0}, {1}",
                              this.Config.FontName, this.Config.FontSize);
        }
        
        private void ButtonFontClick(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Config.FontName = fontDialog.Font.FontFamily.Name;
                this.Config.FontSize = fontDialog.Font.Size;
                SetFontTextBox();
            }
        }
        
        private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.SelectedIndex > -1)
            {
                this.Config.Language =
                    comboBoxLanguage.SelectedValue.ToString();
            }
        }
        
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            ConfigManager.Save();
            LoadLanguage();
        }
    }
}
