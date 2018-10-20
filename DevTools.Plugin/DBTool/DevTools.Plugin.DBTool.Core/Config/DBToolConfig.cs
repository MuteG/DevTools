using System.Collections.Generic;
using System.Xml.Serialization;
using DevTools.Config;

namespace DevTools.Plugin.DBTool.Core.Config
{
    public class DBToolConfig : ConfigBase
    {
        /// <summary>
        /// 数据库连接对象集合
        /// </summary>
        [XmlArray("Connections"), XmlArrayItem("Connection")]
        public List<DBToolConnection> Connections { get; set; }

        public DBToolConfig()
        {
            Connections = new List<DBToolConnection>();
        }

        public int IndexOf(DBToolConnection info)
        {
            int result = -1;
            for (int i = 0; i < this.Connections.Count; i++)
            {
                if (info.DataSource.Equals(this.Connections[i].DataSource))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
