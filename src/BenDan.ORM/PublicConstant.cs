using System;
using System.Collections.Generic;
using System.Text;

namespace BenDan.ORM
{
    public class PublicConstant
    {

        /// <summary>
        /// 获取 SQL Server 连接字符串
        /// </summary>
        public static string SQLConString
        {
            get
            {
                string _connectionString = @"Data Source = 127.0.0.1; Initial Catalog = bendan; User ID = sa; Password = 123456; ";
                return _connectionString;
            }
        }

        /// <summary>
        /// SQLLite 链接字符串
        /// </summary>
        public static string SQLiteConString
        {
            get
            {
                string _connectionString = @"Data Source=bendan.db";
                return _connectionString;
            }
        }

    }
}
