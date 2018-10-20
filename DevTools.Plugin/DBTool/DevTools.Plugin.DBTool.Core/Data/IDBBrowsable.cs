using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Entity;

namespace DevTools.Plugin.DBTool.Core.Data
{
    [InheritedExport]
    public interface IDBBrowsable : IDisposable
    {
        DBToolConnection Connection { get; set; }

        DatabaseType DatabaseType { get; }

        bool TestConnection();

        List<string> GetDatabaseNames();

        List<string> GetTableNames(string dbName);

        List<Column> GetColumns(string tableName);

        List<Index> GetIndexes(string tableName);
    }
}
