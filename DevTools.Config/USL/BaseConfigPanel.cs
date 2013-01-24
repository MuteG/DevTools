using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevTools.Config.USL
{
    /// <summary>
    /// 自定义配置面板抽象类
    /// <para>如果模块想提供自定义配置面板，必须继承于此类。</para>
    /// <para>不需要在此面板中提供保存配置的方法，由配置管理模块统一提供。</para>
    /// </summary>
    public partial class BaseConfigPanel : UserControl
    {
        public virtual ConfigBase Config { get; set; }
        
        public BaseConfigPanel()
        {
            InitializeComponent();
        }
    }
}
