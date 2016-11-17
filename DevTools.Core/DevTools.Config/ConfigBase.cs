using System.Xml.Serialization;

namespace DevTools.Config
{
    /// <summary>
    /// 配置文件对象基类
    /// </summary>
    public class ConfigBase
    {
        public ConfigBase()
        {
        }

        [XmlIgnore]
        public string Key
        {
            get
            {
                return GetType().Assembly.GetName().Name;
            }
        }
    }
}
