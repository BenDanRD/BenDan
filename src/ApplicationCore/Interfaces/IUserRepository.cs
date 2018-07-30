using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
        #region 扩展的dapper操作

        //加一个带参数的存储过程
        string ExecExecQueryParamSP(string spName, string name, int Id);
        bool IfHasName(string username);

        Task<List<Users>> GetUsers();

        Task PostUser(Users entity);

        Task PutUser(Users entity);

        Task DeleteUser(int Id);

        Task<Users> GetUserDetail(int Id);

        #endregion
    }
}
