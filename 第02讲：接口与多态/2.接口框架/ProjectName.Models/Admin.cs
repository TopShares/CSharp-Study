using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectName.Models
{
    [Serializable]
    public class Admin
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }
    }
}
