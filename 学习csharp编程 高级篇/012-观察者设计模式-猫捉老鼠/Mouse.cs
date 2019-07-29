using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _012_观察者设计模式_猫捉老鼠 {
    /// <summary>
    /// 观察者类：老鼠
    /// </summary>
    class Mouse
    {
        private string name;
        private string color;

        public Mouse(string name, string color,Cat cat)
        {
            this.name = name;
            this.color = color;
            cat.catCome += this.RunAway;//把自身的逃跑方法 注册进 猫里面  订阅消息
        }
        /// <summary>
        /// 逃跑功能
        /// </summary>
        public void RunAway()
        {
            Console.WriteLine(color+"的老鼠"+name+"说： 老猫来， 赶紧跑， 我跑， 我使劲跑，我加速使劲跑 ...");
        }
    }
}
