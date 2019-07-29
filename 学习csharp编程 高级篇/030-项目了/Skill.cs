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
namespace _030_项目了 {
    /// <summary>
    /// 技能类
    /// </summary>
    class Skill {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public int Damage { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Lang: {2}, Damage: {3}", Id, Name, Lang, Damage);
        }
    }
}
