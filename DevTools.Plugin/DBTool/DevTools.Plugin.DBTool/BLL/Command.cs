using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevTools.Plugin.DBTool.Data;
using DevTools.Plugin.DBTool.Data.Operator;
using DevTools.Plugin.DBTool.Config;
using DevTools.Plugin.DBTool.Common.Generator;
using DevTools.Common.Log;
using DevTools.Plugin.DBTool.Properties;

namespace DevTools.Plugin.DBTool.Common
{
    internal class Command
    {
        public static DBToolConfig config;
        private static List<string> paramsList = new List<string>();
        private static int maxParamLength = 0;
        private static Stopwatch watch = Stopwatch.StartNew();
        /// <summary>
        /// 构造函数
        /// </summary>
        private Command() { }

        #region  属性
        private static RichTextBox _ListLog;

        /// <summary>
        /// 属性 读取或者设置日志显示列表组件
        /// </summary>
        public static RichTextBox ListLog
        {
            set
            {
                _ListLog = value;
            }
            get
            {
                return _ListLog;
            }
        }
        #endregion

        #region 设置数据库连接字符串

        public static void SetDatabaseConnection(DatabaseConnectionInfo info, string databaseName)
        {
            DBOperator.Connection = string.Format(Constant.DATABASE_CONNECTION_TEMPLATE,
                                        info.Address, info.Username, info.Password, databaseName);
        }

        #endregion

        #region 下拉框组件赋值
        /// <summary>
        /// 为数据表下拉框赋值
        /// </summary>
        /// <param name="cbx">下拉框组件</param>
        public static void SetComboBoxTables(ComboBox cbx)
        {
            watch.Reset();
            watch.Start();
            SetComboBoxWithTable(cbx, DBOperator.GetTables(), "TABLE_NAME");
            watch.Stop();
        }

        /// <summary>
        /// 根据DataTable对象内的数据设置ComboBox
        /// </summary>
        /// <param name="cbx">下拉框组件</param>
        /// <param name="table">DataTable组件</param>
        /// <param name="colName">要填充到下拉框中的列名</param>
        public static void SetComboBoxWithTable(ComboBox cbx, DataTable table, string colName)
        {
            DataRowCollection rows = table.Rows;
            cbx.Items.Clear();
            for (int i = 0; i < rows.Count; i++)
            {
                cbx.Items.Add(rows[i][colName].ToString());
            }
            cbx.SelectedIndex = 0;
        }

        #endregion

        #region ListView组件赋值
        /// <summary>
        /// 为ListView填充表结构数据
        /// </summary>
        /// <param name="lst">ListView组件</param>
        /// <param name="table">表结构集合</param>
        private static void SetListViewTableColumn(ListView lst, DataTable table)
        {
            if (table.Rows.Count == 0) return;
            watch.Reset();
            watch.Start();
            lst.Items.Clear();
            ListViewItem item;
            DataRow row;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                row = table.Rows[i];
                item = lst.Items.Add("");
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["SystemType"].ToString());
                item.SubItems.Add(row["Length"].ToString());
                item.Checked = true;
            }
            watch.Stop();
        }

        private static string CheckParamLength(string name, string length)
        {
            string result = string.Empty;
            switch (name)
            {
                case "int":
                    result = "4";
                    break;
                case "smallint":
                    result = "2";
                    break;
                case "tinyint":
                    result = "1";
                    break;
                case "datetime":
                    result = "8";
                    break;
                case "nvarchar":
                    result = length;
                    break;
                case "varchar":
                case "sysname":
                    result = length;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 为ListView填充存储过程名数据
        /// </summary>
        /// <param name="lst">ListView组件</param>
        /// <param name="table">存储过程集合</param>
        public static void SetListViewStoreProc(ListView lst, DataTable table)
        {
            if (table.Rows.Count == 0) return;
            watch.Reset();
            watch.Start();
            lst.Items.Clear();
            ListViewItem item;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                item = lst.Items.Add("");
                item.SubItems.Add(table.Rows[i]["PROCEDURE_NAME"].ToString());
                item.Checked = true;
            }
            watch.Stop();
            ListLogWriter.WriteLog(LogType.LTDB,
                string.Format("填充详细列表 耗时：{0}ms", watch.ElapsedMilliseconds));
        }

        /// <summary>
        /// 为ListView填充数据
        /// </summary>
        /// <param name="lst">ListView组件</param>
        /// <param name="tableName">表名</param>
        /// <param name="type">操作对象</param>
        public static void SetListView(ListView lst, string tableName, int type)
        {
            switch (type)
            {
                case 0:
                    SetListViewTableColumn(lst, DBOperator.GetTableColumns(tableName));
                    break;
                case 1:
                    SetListViewStoreProc(lst, DBOperator.GetStoreProcedure());
                    break;
            }
        } 
        #endregion

        private static string CutPrefix(string source)
        {
            string[] sp = source.Split('_');
            return string.Join("_", sp, 1, sp.Length - 1);
        }

        #region 生成对应表结构的存储过程
        /// <summary>
        /// 做成数据库脚本，并存入剪贴板中
        /// </summary>
        /// <param name="type">操作类型（增、删、改、查）</param>
        /// <param name="hasInput">是否生成输入参数</param>
        /// <param name="hasHead">是否生成头</param>
        /// <param name="tableName">表名</param>
        /// <param name="lst">ListView组件</param>
        public static void GenerateStoreProcedureScript(SqlOperateType type, bool hasInput,
            bool hasHead, bool cutPrefix, string tableName, ListView lst)
        {
            if (0 == lst.CheckedItems.Count)
            {
                return;
            }
            string script = string.Empty;
            string inputHead = string.Empty;
            string inputParam = string.Empty;
            //生成存储过程名
            string spName = string.Empty;
            //如果是常见表头，处理掉
            string spNameTopTwo = string.Empty;
            spNameTopTwo = tableName.Substring(0, 2);
            spName = cutPrefix ? CutPrefix(tableName) : tableName;
            switch (type)
            {
                case SqlOperateType.Select:
                    spName = "Get" + spName + "Data";
                    break;
                case SqlOperateType.Update:
                    spName = "Update" + spName;
                    break;
                case SqlOperateType.Insert:
                    spName = "Add" + spName;
                    break;
                case SqlOperateType.Delete:
                    spName = "Delete" + spName;
                    break;
                default:
                    break;
            }
            //生成函数头
            GenerateTableScriptInput(lst, out inputHead, out inputParam);
            if (hasHead)
            {
                if (!hasInput || type == SqlOperateType.Delete || type == SqlOperateType.Select)
                {
                    inputHead = string.Empty;
                }
                script = GenerateTableScriptHead(spName, type, inputHead);
            }
            //生成函数主体
            script += GenerateTableScriptBody(inputParam, spName, tableName, hasInput, type);
            //存入剪贴板
            Clipboard.Clear();
            Clipboard.SetText(script);
        }

        /// <summary>
        /// 生成脚本主体
        /// </summary>
        /// <param name="inputParam">函数输入参数列</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="tableName">表名</param>
        /// <param name="hasInput">是否生成输入参数</param>
        /// <param name="type">数据库操作类型</param>
        /// <returns>脚本主体</returns>
        private static string GenerateTableScriptBody(string inputParam, string spName, string tableName, bool hasInput, SqlOperateType type)
        {
            string result = string.Empty;
            string param = string.Empty;
            string insertParam = string.Empty;

            result = "\r\nCREATE PROCEDURE " + spName;
            if (hasInput && type != SqlOperateType.Delete && type != SqlOperateType.Select)
            {
                result += "(\r\n" + inputParam + "\r\n)";
            }
            result += "\r\nAS\r\nBEGIN\r\n" + Constant.TAB + "SET NOCOUNT ON;\r\n";
            StringBuilder paramBuilder = new StringBuilder();
            StringBuilder insertParamBuilder = new StringBuilder();
            foreach (string aParam in Command.paramsList)
            {
                switch (type)
                {
                    case SqlOperateType.Select:
                        paramBuilder.AppendLine(string.Format("{0}{0}{1},", Constant.TAB, aParam));
                        break;
                    case SqlOperateType.Update:
                        paramBuilder.AppendLine(string.Format("{0}{0}{1,-" + maxParamLength + "} = @{1},", Constant.TAB, aParam));
                        break;
                    case SqlOperateType.Insert:
                        paramBuilder.AppendLine(string.Format("{0}{0}{1},", Constant.TAB, aParam));
                        insertParamBuilder.AppendLine(string.Format("{0}{0}@{1},", Constant.TAB, aParam));
                        break;
                    default:
                        break;
                }
            }
            param = paramBuilder.ToString().Trim().TrimEnd(',');
            insertParam = insertParamBuilder.ToString().Trim().TrimEnd(',');

            switch (type)
            {
                case SqlOperateType.Select:
                    result += Constant.TAB + "SELECT " + param + "\r\n" + Constant.TAB + "FROM " + tableName + "\r\n";
                    break;
                case SqlOperateType.Update:
                    result += Constant.TAB + "UPDATE " + tableName + " SET\r\n" + Constant.TAB + Constant.TAB + param + "\r\n";
                    break;
                case SqlOperateType.Insert:
                    result += Constant.TAB + "INSERT INTO " + tableName + "(\r\n" + Constant.TAB + Constant.TAB + param +
                        "\r\n" + Constant.TAB + ")VALUES(\r\n" + Constant.TAB + Constant.TAB +
                        insertParam + "\r\n" + Constant.TAB + ")\r\n";
                    break;
                case SqlOperateType.Delete:
                    result += Constant.TAB + "DELETE FROM " + tableName + "\r\n";
                    break;
                default:
                    break;
            }
            result += "END";
            return result;
        }

        /// <summary>
        /// 生成输入参数（存储过程参数、注释头参数）
        /// </summary>
        /// <param name="lst">ListView组件</param>
        /// <param name="inputHead">（输出）注释头参数</param>
        /// <param name="inputParam">（输出）存储过程参数</param>
        private static void GenerateTableScriptInput(ListView lst, out string inputHead, out string inputParam)
        {
            paramsList.Clear();
            ListView.CheckedListViewItemCollection items = lst.CheckedItems;
            StringBuilder inputHeadBuilder = new StringBuilder();
            StringBuilder inputParamBuilder = new StringBuilder();
            maxParamLength = GetMaxLengthOfParams(items);
            string paramFormat = Constant.TAB + "@{0,-" + maxParamLength + "} {1},";
            foreach (ListViewItem item in items)
            {
                string paramType = GenerateTableScriptInputType(item.SubItems[2].Text, item.SubItems[3].Text);
                if (paramType.Length > 0)
                {
                    inputHeadBuilder.AppendLine(string.Format("** @{0,-20}", item.SubItems[1].Text));
                    inputParamBuilder.AppendLine(string.Format(paramFormat,
                                                               item.SubItems[1].Text,
                                                               paramType));
                    paramsList.Add(item.SubItems[1].Text);
                }
            }
            inputHead = inputHeadBuilder.ToString().TrimEnd();
            inputParam = inputParamBuilder.ToString().TrimEnd().Trim(',');
        }

        private static int GetMaxLengthOfParams(ListView.CheckedListViewItemCollection items)
        {
            int result = 0;
            int aLength = 0;
            foreach (ListViewItem item in items)
            {
                aLength = item.SubItems[1].Text.Length;
                if (aLength > result) result = aLength;
            }
            return result;
        }

        /// <summary>
        /// 生成输入函数的类型（varchar和nvarchar类型要加上长度）
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="length">长度</param>
        /// <returns>类型（长度）</returns>
        private static string GenerateTableScriptInputType(string type, string length)
        {
            string result = string.Empty;
            if (!type.Contains(" identity"))
            {
                result = type;
                if (result.Contains("char"))
                {
                    result = string.Format("{0}({1})", type, length);
                }
            }
            return result;
        }

        /// <summary>
        /// 生成脚本头注释
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="type">数据库操作类型</param>
        /// <param name="input">头注释输入参数列</param>
        /// <returns>脚本头注释</returns>
        private static string GenerateTableScriptHead(string spName, SqlOperateType type, string input)
        {
            string result = string.Empty;
            result = string.Format(Resources.Template_StoreProcedureHeader,
                                   spName,       //存储过程名
                                   string.Empty, //说明
                                   string.Empty, //返回值
                                   input.Length > 0 ? input : "**", //输入
                                   "**",         //输出
                                   "高云鹏",     //作成者
                                   DateTime.Now.ToString("yyyy/MM/dd")
                                   );
            return result;
        }
        #endregion

        #region 生成对应存储过程的C#代码

        public static void MakeStoreProcedureCode(ListView lst)
        {
            ListView.CheckedListViewItemCollection items = lst.CheckedItems;
            DataTable table;
            StringBuilder script = new StringBuilder();
            script.AppendLine("private SqlHelper sqlHelper = new SqlHelper();");
            for (int i = 0; i < items.Count; i++)
            {
                string procedureName = items[i].SubItems[1].Text;
                table = DBOperator.GetProcedureColumns(procedureName);
                script.AppendLine(MakeStoreProcedureCode(table, procedureName));
            }
            //script.Append(Constant.PROCEDURE_SET_PARAMS);
            Clipboard.Clear();
            Clipboard.SetText(script.ToString());
        }

        private static string MakeStoreProcedureCode(DataTable table, string spName)
        {
            string result = string.Empty;
            StringBuilder parameterBuilder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString().Substring(1);
                if (columnName.Equals("RETURN_VALUE"))
                {
                    continue;
                }
                parameterBuilder.AppendLine(MakeStoreProcedureCodeSQLParam(columnName, spName));
            }
            try
            {
                result = string.Format(Resources.Template_CSharpStoreProcedure_Body,
                    spName, spName, spName, parameterBuilder.ToString().Trim().TrimEnd(','));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return result;
        }

        private static string MakeStoreProcedureCodeInputParam(string type, string name)
        {
            string result = string.Empty;
            switch (type)
            {
                default:
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "sysname":
                    result = ", string " + name;
                    break;
                case "datetime":
                    result = ", DateTime " + name;
                    break;
                case "int":
                case "smallint":
                case "tinyint":
                    result = ", int " + name;
                    break;
                case "money":
                    result = ", double " + name;
                    break;
            }
            return result;
        }

        private static string MakeStoreProcedureCodeSQLParam(string parameterName, string instanceName)
        {
            string result = string.Empty;
            result = string.Format(Resources.Template_CSharpStoreProcedure_Parameter, parameterName, instanceName);
            return result;
        }

        private static string SqlTypeToSqlDbType(string type)
        {
            string result = string.Empty;
            switch (type)
            {
                case "varchar":
                case "datetime":
                case "sysname":
                    result = "SqlDbType.VarChar";
                    break;
                case "nvarchar":
                    result = "SqlDbType.NVarChar";
                    break;
                case "int":
                case "smallint":
                case "tinyint":
                    result = "SqlDbType.Int";
                    break;
            }
            return result;
        } 

        #endregion

        #region 生成对应表结构的C#代码

        public static void GenerateTableInstanceCSharpCode(string tableName, string prefix, bool cutPrefix, ListView lst)
        {
            if (0 == lst.CheckedItems.Count)
            {
                return;
            }
            string className = cutPrefix ? CutPrefix(tableName) : tableName;
            StringBuilder propertiesBuilder = new StringBuilder();
            // 生成属性代码
            foreach (ListViewItem item in lst.CheckedItems)
            {
                propertiesBuilder.AppendLine(
                    string.Format(Resources.Template_CSharpProperty,
                    GetPropertyType(item.SubItems[2].Text.Replace(" identity", "")),
                    string.IsNullOrEmpty(prefix) ?
                        LowerFirstChar(item.SubItems[1].Text) :
                        prefix + item.SubItems[1].Text,
                    item.SubItems[1].Text));
            }
            // 生成Equals代码
            StringBuilder equalsPropertyBuilder = new StringBuilder();
            foreach (DataRow pkRow in DBOperator.GetTableIndexes(tableName).Select("PrimaryKey='PK'"))
            {
                equalsPropertyBuilder.AppendLine(
                    string.Format(Resources.Template_CSharpClassEqualsProperties,
                        pkRow["ColumnName"].ToString()));
            }
            string classEquals = string.Format(Resources.Template_CSharpClassEquals,
                className, equalsPropertyBuilder.ToString().Trim().TrimEnd(' ', '&'));
            string script = string.Format(Resources.Template_CSharpClassBody,
                className, propertiesBuilder.ToString(), classEquals);
            //存入剪贴板
            Clipboard.Clear();
            Clipboard.SetText(script);
        }

        private static string LowerFirstChar(string wholeWord)
        {
            return wholeWord.Substring(0, 1).ToLower() + wholeWord.Substring(1);
        }

        private static string GetPropertyType(string type)
        {
            string result = string.Empty;
            switch (type.ToLower())
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    result = "string";
                    break;
                case "datetime":
                case "smalldatetime":
                    result = "DateTime";
                    break;
                case "tinyint":
                case "int":
                case "smallint":
                    result = "int";
                    break;
                case "bit":
                    result = "byte";
                    break;
                case "bigint":
                    result = "long";
                    break;
                case "float":
                    result = "float";
                    break;
                case "decimal":
                    result = "decimal";
                    break;
                case "real":
                case "money":
                    result = "double";
                    break;
            }
            return result;
        }
        
        #endregion

    }
}