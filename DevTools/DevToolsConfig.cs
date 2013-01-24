using System;
using System.Drawing;
using DevTools.Config;
using DevTools.Config.USL;

namespace DevTools
{
    /// <summary>
    /// 配置文件对象
    /// </summary>
    public class DevToolsConfig : ConfigBase
    {
        /// <summary>
        /// 字体
        /// </summary>
        public string FontName { get; set; }
        
        public float FontSize { get; set; }
        
        /// <summary>
        /// 语言代号
        /// </summary>
        public string Language { get; set; }
        
        public DevToolsConfig()
        {
        }
        
        public override BaseConfigPanel ConfigPanel
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
