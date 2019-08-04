using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class GroupDataModel
    {
        public int code { get; set; }
        public GroupInfoModel data { get; set; }
    }

    public class GroupInfoModel
    {
        public List<UserInfo> item { get; set; }
        public string finger_memo { get; set; }
        public string group_memo { get; set; }
        public string group_name { get; set; }
    }

    public class UserInfo
    {
        /// <summary>
        /// 是否创建人  0不是
        /// </summary>
        public int iscreator { get; set; }
        /// <summary>
        /// 是否管理员 0不是
        /// </summary>
        public int ismanager { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long uin { get; set; }

    }
}
