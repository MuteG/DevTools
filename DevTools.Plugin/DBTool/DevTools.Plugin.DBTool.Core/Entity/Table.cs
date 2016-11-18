using System.Collections.Generic;
using System.Linq;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Data;

namespace DevTools.Plugin.DBTool.Core.Entity
{
    public class Table
    {
        public string Name { get; set; }

        private List<Column> columns = null;

        public List<Column> Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new List<Column>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn);
                    columns = browser.GetColumns(Name);
                }
                return columns;
            }
        }

        private List<Index> indexes = null;

        public List<Index> Indexes
        {
            get
            {
                if (indexes == null)
                {
                    indexes = new List<Index>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn);
                    indexes = browser.GetIndexes(Name);
                }
                return indexes;
            }
        }

        private List<IndexColumn> primaryKey = null;

        public List<IndexColumn> PrimaryKey
        {
            get
            {
                if (primaryKey == null)
                {
                    var pk = from idx in Indexes
                             where idx.IsPrimaryKey
                             select idx.Columns;
                    primaryKey = pk.FirstOrDefault();
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
