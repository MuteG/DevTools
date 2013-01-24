using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using DevTools.Config;
using DevTools.Config.USL;

namespace DevTools.USL
{
    /// <summary>
    /// 配置面板
    /// </summary>
    public partial class ConfigPanel : BaseConfigPanel
    {
        public ConfigPanel()
        {
            InitializeComponent();
        }
        
        public override ConfigBase Config
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
