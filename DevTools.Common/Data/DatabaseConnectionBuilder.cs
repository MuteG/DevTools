using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace DevTools.Common.Data
{
    /// <summary>
    /// 数据库连接构造器
    /// </summary>
    public class DatabaseConnectionBuilder
    {
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// 数据库登录用户
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 数据库登录口令
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DBType { get; set; }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            switch (this.DBType)
            {
                case DatabaseType.SqlServer:
                    {
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                        builder.DataSource = this.DataSource;
                        builder.UserID = this.Username;
                        builder.Password = this.Password;
                        return new SqlConnection(builder.ConnectionString);
                    }
                case DatabaseType.Oracle:
                    {
                        OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
                        builder.DataSource = this.DataSource;
                        builder.UserID = this.Username;
                        builder.Password = this.Password;
                        return new OracleConnection(builder.ConnectionString);
                    }
            }
            return null;
        }

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            DbConnection conn = this.GetConnection();
            if (null == conn)
            {
                return string.Empty;
            }
            else
            {
                return conn.ConnectionString;
            }
        }
    }
}
