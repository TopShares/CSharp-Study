using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class GroupDataModel
    {
        public int retcode { get; set; }
        public GroupResultModel result { get; set; }
    }

    public class GroupResultModel
    {
        public GroupInfoModel group { get; set; }
        public string[] redwords { get; set; }
        public int endflag { get; set; }
    }

    public class GroupInfoModel
    {
        public List<GroupModel> group_list { get; set; }
        public string[] redwords { get; set; }
        public int endflag { get; set; }
    }

    public class GroupModel
    {
        /// <summary>
        /// 最大数
        /// </summary>
        public int max_member_num { get; set; }
        /// <summary>
        /// 当前用户数
        /// </summary>
        public int member_num { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// 群名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 群号码
        /// </summary>
        public int code { get; set; }

    }
}
