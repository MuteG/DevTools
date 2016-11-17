using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevTools.Config.USL;

namespace DevTools.USL
{
    public partial class DevToolsConfigPanel : ConfigPanelBase
    {
        public DevToolsConfigPanel()
        {
            InitializeComponent();
        }

        protected override void ShowConfig(Config.ConfigBase config)
        {
            base.ShowConfig(config);
        }

        protected override void SaveConfig(Config.ConfigBase config)
        {
            base.SaveConfig(config);
        }
    }
}
