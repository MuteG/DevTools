using System.Collections.Generic;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Data;

namespace DevTools.Plugin.DBTool.Core.Entity
{
    public class Instance
    {
        private List<Database> databases = null;

        public List<Database> Databases
        {
            get
            {
                if (databases == null)
                {
                    databases = new List<Database>();
                    DBBrowserLoader loader = new DBBrowserLoader();
                    IDBBrowsable browser = loader.GetBrowser(conn.Type);
                    foreach (string databaseName in browser.GetDatabaseNames())
                    {
                        databases.Add(new Database(conn) { Name = databaseName });
                    }
                }
                return databases;
            }
        }

        private DBToolConnection conn;

        public Instance(DBToolConnection conn)
        {
            this.conn = conn;
        }
    }
}
