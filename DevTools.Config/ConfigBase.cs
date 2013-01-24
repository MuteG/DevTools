using System;
using System.Windows.Forms;
using DevTools.Config.USL;

namespace DevTools.Config
{
    /// <summary>
    /// 配置文件对象基类
    /// </summary>
    public abstract class ConfigBase
    {
        /// <summary>
        /// 获取模块自提供的配置面板
        /// <para>必须继承于AbstractConfigPanel</para>
        /// <para>如果模块并未提供配置面板，则此属性应返回null</para>
        /// </summary>
        public abstract BaseConfigPanel ConfigPanel { get; }
        
        public ConfigBase()
        {
        }
    }
}
