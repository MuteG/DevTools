using System.Collections.Generic;
using System.Linq;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Data;

namespace DevTools.Plugin.DBTool.Core.Entity
{
    public class Table
    {
        public string Name { get; set; }

        private List<Column> columns = new List<Column>();

        public List<Column> Columns
        {
            get
            {
                if (columns.Count == 0)
                {
                    columns = new List<Column>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn);
                    columns = browser.GetColumns(Name);
                }
                return columns;
            }
        }

        private List<Index> indexes = new List<Index>();

        public List<Index> Indexes
        {
            get
            {
                if (indexes.Count == 0)
                {
                    indexes = new List<Index>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn);
                    indexes = browser.GetIndexes(Name);
                }
                return indexes;
            }
        }

        private List<IndexColumn> primaryKey = new List<IndexColumn>();

        public List<IndexColumn> PrimaryKey
        {
            get
            {
                if (primaryKey.Count == 0)
                {
                    var pk = from idx in Indexes
                             where idx.IsPrimaryKey
                             select idx.Columns;
                    if (pk.Count() > 0)
                    {
                        primaryKey = pk.First();
                    }
                }
                return primaryKey;
            }
        }

        private DBToolConnection conn;

        public Table(DBToolConnection conn)
        {
            this.conn = conn;
        }
    }
}
