using BenDan.ORM.SqlLite;
using Dapper;
using System;
using System.Data;

namespace CTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            using (IDbConnection conn = SQLiteDBConfig.GetSqlConnection())
            {
                string querySql = @"SELECT * FROM BD_USER ";
                var aaa =   conn.Query<DB_USER>(querySql);
            }
        }
    }
}
