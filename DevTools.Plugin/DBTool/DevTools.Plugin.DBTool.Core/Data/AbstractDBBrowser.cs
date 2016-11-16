using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Entity;

namespace DevTools.Plugin.DBTool.Core.Data
{
    public abstract class AbstractDBBrowser<TReader> : IDBBrowsable
        where TReader : DbDataReader
    {
        private DbConnection conn = null;

        private DBToolConnection dbToolConn = null;

        public DBToolConnection Connection
        {
            get
            {
                return dbToolConn;
            }
            set
            {
                dbToolConn = value;
                CreateConnection(dbToolConn);
            }
        }

        public abstract DatabaseType DatabaseType { get; }

        public bool TestConnection()
        {
            try
            {
                OpenConnection();
                CloseConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public abstract List<string> GetDatabaseNames();

        public abstract List<string> GetTableNames(string dbName);

        public abstract List<Column> GetColumns(string tableName);

        public abstract List<Index> GetIndexes(string tableName);

        protected abstract DbConnection CreateConnection(DBToolConnection conn);

        protected TReader ExecuteReader(string sql, params DbParameter[] parmeters)
        {
            OpenConnection();
            using (DbCommand cmd = this.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                return cmd.ExecuteReader() as TReader;
            }
        }

        private void OpenConnection()
        {
            if (conn != null &&
                conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void CloseConnection()
        {
            if (conn != null &&
                conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
    }
}
