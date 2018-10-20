using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevTools.Config.USL
{
    /// <summary>
    /// 智能配置面板
    /// </summary>
    public partial class SmartConfigPanel : ConfigPanelBase
    {
        public SmartConfigPanel()
        {
            InitializeComponent();
        }
        
        protected override void ShowConfig(ConfigBase config)
        {
            //TODO : 根据config自动生成配置界面
        }

        protected override void SaveConfig(ConfigBase config)
        {
            throw new NotImplementedException();
        }
    }
}
