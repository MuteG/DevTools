using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using DevTools.Language;

namespace DevTools.Config.USL
{
    /// <summary>
    /// 自定义配置面板抽象类
    /// <para>如果模块想提供自定义配置面板，必须继承于此类。</para>
    /// <para>不需要在此面板中提供保存配置的方法，由配置管理模块统一提供。</para>
    /// </summary>
    public partial class ConfigPanelBase : UserControl
    {
        private ConfigBase config;
        
        /// <summary>
        /// 获取或设置当前配置面板对应的配置文件对象
        /// </summary>
        public ConfigBase Config
        {
            get
            {
                return this.config;
            }
            set
            {
                SetConfig(config);
            }
        }
        
        public ConfigPanelBase()
        {
            InitializeComponent();
        }
        
        private void SetConfig(ConfigBase config)
        {
            this.config = config;
            ShowConfig(config);
        }
        
        protected virtual void ShowConfig(ConfigBase config)
        {
            
        }
        
        public void Save()
        {
            SaveConfig(ref this.config);
        }
        
        protected virtual void SaveConfig(ref ConfigBase config)
        {
            
        }
        
        public virtual void LoadLanguage()
        {
            LoadLanguage(this);
        }
        
        private void LoadLanguage(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                LanguageManager.GetString(subControl);
                LoadLanguage(subControl);
            }
        }
    }
}
