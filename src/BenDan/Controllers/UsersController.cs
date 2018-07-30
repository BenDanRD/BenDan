using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BenDan.Controllers
{
        /// <summary>
        /// 用户信息
        /// </summary>
        [Route("api/[controller]/[action]")]
        public class UsersController : Controller
        {
            private readonly IUserRepository userRepository;
            public UsersController(IUserRepository _userRepository)
            {
                userRepository = _userRepository;
            }

            /// <summary>
            /// 获取所有用户
            /// </summary>
            /// <returns></returns>
            /// 
            [HttpGet]
            public async Task<JsonResult> GetUsers()
            {
                List<Users> list = await userRepository.GetUsers();
                return Json(list);
            }

            /// <summary>
            /// 新增用户
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task PostUser(Users entity)
            {
                await userRepository.PostUser(entity);
            }

            /// <summary>
            /// 修改用户信息
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task PutUser(Users entity)
            {
                try
                {
                    await userRepository.PutUser(entity);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            /// <summary>
            /// 删除用户
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            [HttpDelete]
            public async Task DeleteUser(int Id)
            {
                try
                {
                    await userRepository.DeleteUser(Id);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    
}