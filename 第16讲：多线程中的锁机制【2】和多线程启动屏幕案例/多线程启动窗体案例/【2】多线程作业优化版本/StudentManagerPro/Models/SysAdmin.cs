using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    [Serializable]
    public class SysAdmin
    {
        public int LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string AdminName { get; set; }

        public int AdminStatus { get; set; }

        //实际项目中我们根据需要添加角色等内容...

        /// <summary>
        /// 上次登录时间(为了避免不通过电脑日期格式问题，我们这里用字符串)
        /// </summary>
        public string LastLoginTime { get; set; }

    }
}
