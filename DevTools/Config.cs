using System;
using System.Drawing;

using DevTools.Config;

namespace DevTools
{
    /// <summary>
    /// 配置文件对象
    /// </summary>
    public class AppConfig : ConfigBase
    {
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font { get; set; }
        
        /// <summary>
        /// 语言代号
        /// </summary>
        public string Language { get; set; }
        
        public AppConfig()
        {
        }
    }
}
