using System.Collections.Generic;
using System.Xml.Serialization;
using DevTools.Config;

namespace DevTools.Plugin.DBTool.Config
{
    public class DBToolConfig : ConfigBase
    {
        /// <summary>
        /// 数据库连接对象集合
        /// </summary>
        [XmlArray("Connections"), XmlArrayItem("Connection")]
        public List<DBConnection> Connections { get; set; }

        public int IndexOf(DBConnection info)
        {
            int result = -1;
            for (int i = 0; i < this.Connections.Count; i++)
            {
                if (info.Address.Equals(this.Connections[i].Address))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
