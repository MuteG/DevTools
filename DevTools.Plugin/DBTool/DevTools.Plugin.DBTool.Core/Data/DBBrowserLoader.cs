using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using DevTools.Plugin.DBTool.Core.Config;

namespace DevTools.Plugin.DBTool.Core.Data
{
    public class DBBrowserLoader
    {
        private string folder;

        public DBBrowserLoader()
        {
            Assembly entryAssembly = Assembly.GetExecutingAssembly();
            this.folder = Path.GetDirectoryName(entryAssembly.Location);
        }

        [ImportMany(typeof(IDBBrowsable))]
        public List<IDBBrowsable> Browsers { get; set; }

        private void Load()
        {
            if (Browsers == null ||
                Browsers.Count == 0)
            {
                var catalog = new DirectoryCatalog(this.folder);
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
        }

        public IDBBrowsable GetBrowser(DatabaseType type)
        {
            Load();
            return Browsers.FirstOrDefault(b => b.DatabaseType == type);
        }

        public IDBBrowsable GetBrowser(DBToolConnection conn)
        {
            Load();
            IDBBrowsable browser = Browsers.FirstOrDefault(b => b.DatabaseType == conn.Type);
            if (browser != null)
            {
                browser.Connection = conn;
            }
            return browser;
        }

        public void Dispose()
        {
            foreach (IDisposable browser in this.Browsers)
            {
                browser.Dispose();
            }
            this.Browsers.Clear();
        }
    }
}
