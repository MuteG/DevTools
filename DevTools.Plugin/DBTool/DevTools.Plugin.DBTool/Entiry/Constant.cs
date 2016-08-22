namespace DevTools.Plugin.DBTool.Data
{
    public static class Constant
    {
        public const string DATABASE_CONNECTION_TEMPLATE = "server={0};uid={1};pwd={2};Trusted_Connection=no;database={3};";
        public const string TAB = "    ";
        public const int MAX_STRING_LENGTH = 100;

        public const string PROCEDURE_SET_PARAMS = "/// <summary>\r\n/// 根据参数值，给存储过程参数赋值（应对空值情况）\r\n" +
            "/// </summary>\r\n/// <param name=\"param\">存储过程参数</param>\r\n/// <param name=\"value\">要提供给存储过程的值</param>" +
            "\r\nprivate static void SetParams(SqlParameter param, object value)\r\n{\r\n    if (null == value)\r\n    {\r\n" +
            "        param.SqlValue = DBNull.Value;\r\n    }\r\n    else\r\n    {\r\n        param.Value = value;\r\n    }\r\n}";
        public const string STORE_PROCEDURE_EXEC = "SqlHelper.ExecuteNonQuery([DBConnection], \"UnPack_GetTimeScheduleData\", params);";
    }

    public enum SqlOperateType
    {
        Select = 0,
        Update = 1,
        Delete = 2,
        Insert = 3
    }

    public struct DatabaseConnectionInfo
    {
        public string Address;
        public string Username;
        public string Password;
    }
}
