using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Users: BaseModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别（0女，1男）
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 出生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string IntroDuction { get; set; }
        /// <summary>
        /// 是否删除（0正常，1删除）
        /// </summary>
        public int IsDelete { get; set; }
    }
}
