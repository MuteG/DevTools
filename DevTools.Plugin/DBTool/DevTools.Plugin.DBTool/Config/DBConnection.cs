using System.Xml.Serialization;

namespace DevTools.Plugin.DBTool.Config
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        [XmlAttribute("address")]
        public string Address { get; set; }

        [XmlAttribute("host")]
        public string Host { get; set; }


        /// <summary>
        /// 数据库登录用户
        /// </summary>
        [XmlAttribute("user")]
        public string Username { get; set; }

        /// <summary>
        /// 数据库登录口令
        /// </summary>
        [XmlAttribute("password")]
        public string Password { get; set; }
    }
}
