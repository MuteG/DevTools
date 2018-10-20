using System.Xml.Serialization;

namespace DevTools.Plugin.DBTool.Core.Config
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class DBToolConnection
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        [XmlAttribute("type")]
        public DatabaseType Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 数据库连接地址
        /// </summary>
        [XmlElement("address")]
        public string DataSource { get; set; }

        /// <summary>
        /// 数据库登录用户
        /// </summary>
        [XmlElement("user")]
        public string Username { get; set; }

        /// <summary>
        /// 数据库登录口令
        /// </summary>
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
