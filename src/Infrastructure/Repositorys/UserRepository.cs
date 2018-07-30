using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using BenDan.ORM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public async Task DeleteUser(int Id)
        {
            string deleteSql = "DELETE FROM [dbo].[Users] WHERE Id=@Id";
            await Delete(Id, deleteSql);
        }

        public  string ExecExecQueryParamSP(string spName, string name, int Id)
        {
            using (IDbConnection conn = SqlDBConfig.GetSqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", name, DbType.String, ParameterDirection.Output, 100);
                parameters.Add("@Id", Id, DbType.String, ParameterDirection.Input);
                conn.Execute(spName, parameters, null, null, CommandType.StoredProcedure);
                string strUserName = parameters.Get<string>("@UserName");
                return strUserName;
            }
        }

        public async Task<Users> GetUserDetail(int Id)
        {
            string detailSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users] WHERE Id=@Id";
            return await Detail(Id, detailSql);
        }

        public async Task<List<Users>> GetUsers()
        {
            string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users]";
            return await Select(selectSql);
        }

        public bool IfHasName(string username)
        {
            string selectsql = @"select count from USERS";
            var result = 0;
            using (IDbConnection conn = SqlDBConfig.GetSqlConnection())
            {
                result =  int.Parse(conn.QueryFirstOrDefaultAsync<Users>(selectsql, new { username }).ToString());
            }
            if (result > 0) { return true; }
            return false;
        }

        public async Task PostUser(Users entity)
        {
            string insertSql = @"INSERT INTO [dbo].[Users](Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete) VALUES(@Id, @UserName, @Password, @Gender, @Birthday, @CreateDate, @IsDelete)";
            await Insert(entity, insertSql);
        }

        public async Task PutUser(Users entity)
        {
            string updateSql = "UPDATE [dbo].[Users] SET UserName=@UserName, Password=@Password, Gender=@Gender, Birthday=@Birthday, CreateDate=@CreateDate, IsDelete=@IsDelete WHERE Id=@Id";
            await Update(entity, updateSql);
        }
    }
}
