using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevTools.Plugin.DBTool.Properties;
using DevTools.Plugin.DBTool.Common;
using DevTools.Plugin.DBTool.Common.Generator;
using DevTools.Common.Log;

namespace DevTools.Plugin.DBTool.Data.Operator
{
    public static class DBOperator
    {
        private static string m_Connection = string.Empty;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string Connection
        {
            get { return DBOperator.m_Connection; }
            set { DBOperator.m_Connection = value; }
        }

        private static Dictionary<string, DataTable> m_DictTables = new Dictionary<string, DataTable>();

        public static DataTable GetDatabase()
        {
            DataTable result = new DataTable();
            result = ExecuteDataTable("DATABASES", Resources.SQL_GetDatabaseName);
            return result;
        }

        private static DataTable ExecuteDataTable(string keyWord, string sqlScript)
        {
            DataTable result = new DataTable();
            string key = m_Connection + keyWord;
            if (m_DictTables.ContainsKey(key))
            {
                result = m_DictTables[key];
            }
            else
            {
                //result = SqlHelper.ExecuteDataset(m_Connection, CommandType.Text, sqlScript).Tables[0];
                m_DictTables.Add(key, result);
            }
            return result;
        }

        public static DataTable GetTables()
        {
            DataTable result = new DataTable();
            try
            {
                result = ExecuteDataTable("TABLES", Resources.SQL_GetTableName);
            }
            catch (Exception ex)
            {
                ListLogWriter.WriteLog(LogType.LTError, "查询数据表列表错误：" + ex.Message);
            }
            return result;
        }

        public static DataTable GetStoreProcedure()
        {
            DataTable result = new DataTable();
            try
            {
                result = ExecuteDataTable("STOREPROCEDURES", Resources.SQL_GetStoreProcedureName);
            }
            catch (Exception ex)
            {
                ListLogWriter.WriteLog(LogType.LTError, "查询存储过程列表错误：" + ex.Message);
            }
            return result;
        }

        public static DataTable GetProcedureColumns(string procedureName)
        {
            DataTable result = new DataTable();
            try
            {
                string sql = string.Format("exec sp_sproc_columns @procedure_name=N'{0}'", procedureName);
                result = ExecuteDataTable("STOREPROCEDURE_COLUMNS" + procedureName, sql);
            }
            catch (Exception ex)
            {
                ListLogWriter.WriteLog(LogType.LTError, "查询存储过程参数列表错误：" + ex.Message);
            }
            return result;
        }

        public static DataTable GetTableColumns(string tableName)
        {
            DataTable result = new DataTable();
            try
            {
                string sql = string.Format(Resources.SQL_GetTableColumns, tableName);
                result = ExecuteDataTable("TABLE_COLUMNS" + tableName, sql);
            }
            catch (Exception ex)
            {
                ListLogWriter.WriteLog(LogType.LTError, "查询表列名列表错误：" + ex.Message);
            }
            return result;
        }

        public static DataTable GetTableIndexes(string tableName)
        {
            DataTable result = new DataTable();
            try
            {
                string sql = string.Format(Resources.SQL_GetTableIndex, tableName);
                result = ExecuteDataTable("TABLE_INDEXES" + tableName, sql);
            }
            catch (Exception ex)
            {
                ListLogWriter.WriteLog(LogType.LTError, "查询表索引列表错误：" + ex.Message);
            }
            return result;
        }
    }
}
