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
    class Skill
    {
        public int id;
        public int damage;
        public string name;

        public override string ToString()
        {
            return string.Format("Id: {0}, Damage: {1}, Name: {2}", id, damage, name);
        }
    }
}
