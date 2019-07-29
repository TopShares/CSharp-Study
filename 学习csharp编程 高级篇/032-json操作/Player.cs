using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _032_json操作 {
    class Player
    {
    //    public string name;//字段或者属性名 要跟json里面的对应
    //    public int level;
        public string Name { get; set; }
        public int Level { get; set; }
        public int Age { get; set; }
        public List<Skill> SkillList { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Level: {1}, Age: {2}, SkillList: {3}", Name, Level, Age, SkillList);
        }
    }
}
