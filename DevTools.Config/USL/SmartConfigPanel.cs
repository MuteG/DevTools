using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevTools.Config.USL
{
    /// <summary>
    /// 智能配置面板
    /// </summary>
    public partial class SmartConfigPanel : BaseConfigPanel
    {
        private ConfigBase config;
        
        public override ConfigBase Config
        {
            get
            {
                return this.config;
            }
            set
            {
                this.config = value;
                SetConfig(value);
            }
        }
        
        public SmartConfigPanel()
        {
            InitializeComponent();
        }
        
        private void SetConfig(ConfigBase config)
        {
            
        }
    }
}
