using System;
using System.Collections.Generic;
using System.Data.Common;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Data;
using DevTools.Plugin.DBTool.Core.Entity;
using Oracle.ManagedDataAccess.Client;

namespace DevTools.Plugin.DBTool.Oracle
{
    public class OracleDBBrowser : AbstractDBBrowser<OracleDataReader>
    {
        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.Oracle; }
        }

        public override List<string> GetDatabaseNames()
        {
            List<string> names = new List<string>();
            string sql = Properties.Resources.SQL_GetDatabaseName;
            using (OracleDataReader reader = base.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    names.Add(reader.GetString(0));
                }
                reader.Close();
            }
            return names;
        }

        public override List<string> GetTableNames(string dbName)
        {
            List<string> names = new List<string>();
            string sql = Properties.Resources.SQL_GetTableName;
            using (OracleDataReader reader = base.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    names.Add(reader.GetString(0));
                }
                reader.Close();
            }
            return names;
        }

        public override List<Column> GetColumns(string tableName)
        {
            List<Column> columns = new List<Column>();
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("TABLE_NAME", OracleDbType.Varchar2, 128) { Value = tableName}
            };
            string sql = Properties.Resources.SQL_GetTableColumns;
            using (OracleDataReader reader = base.ExecuteReader(sql, parameters))
            {
                while (reader.Read())
                {
                    Column column = new Column();
                    column.Name = reader["Name"] as string;
                    column.Type = reader["SystemType"] as string;
                    column.Length = Convert.ToInt32(reader["Length"]);
                    columns.Add(column);
                }
                reader.Close();
            }
            return columns;
        }

        public override List<Index> GetIndexes(string tableName)
        {
            List<Index> indexes = new List<Index>();
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("TABLE_NAME", OracleDbType.Varchar2, 128) { Value = tableName}
            };
            string sql = Properties.Resources.SQL_GetTableIndex;
            using (OracleDataReader reader = base.ExecuteReader(sql, parameters))
            {
                Index index = new Index();
                while (reader.Read())
                {
                    string name = reader["Name"] as string;
                    if (string.Compare(name, index.Name) != 0)
                    {
                        index = new Index();
                        index.Name = name;
                        index.Enable = "FALSE".Equals(reader["Disabled"]);
                        index.IsPrimaryKey = "PK".Equals(reader["PrimaryKey"]);
                        index.Columns = new List<IndexColumn>();
                        indexes.Add(index);
                    }
                    IndexColumn column = new IndexColumn();
                    column.Name = reader["ColumnName"] as string;
                    column.Sort = reader["Sort"] as string;
                    index.Columns.Add(column);
                }
                reader.Close();
            }
            return indexes;
        }

        protected override DbConnection CreateConnection(DBToolConnection conn)
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
            builder.DataSource = conn.DataSource;
            builder.UserID = conn.Username;
            builder.Password = conn.Password;
            return new OracleConnection(builder.ConnectionString);
        }
    }
}
