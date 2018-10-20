using System.Collections.Generic;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Data;

namespace DevTools.Plugin.DBTool.Core.Entity
{
    public class Database
    {
        public string Name { get; set; }

        private List<Table> tables = null;

        public List<Table> Tables
        {
            get
            {
                if (tables == null)
                {
                    tables = new List<Table>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn);
                    foreach (string tableName in browser.GetTableNames(Name))
                    {
                        tables.Add(new Table(conn) { Name = tableName });
                    }
                }
                return tables;
            }
        }

        private DBToolConnection conn;

        public Database(DBToolConnection conn)
        {
            this.conn = conn;
        }
    }
}
