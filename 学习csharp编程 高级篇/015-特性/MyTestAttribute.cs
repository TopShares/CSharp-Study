using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _015_特性 {
    //1, 特性类的后缀以Attribute结尾 
    //2, 需要继承自System.Attribute
    //3, 一般情况下声明为 sealed
    //4, 一般情况下 特性类用来表示目标结构的一些状态(定义一些字段或者属性， 一般不定义方法)
    [AttributeUsage(AttributeTargets.Class)]//表示该特性类可以应用到的程序结构有哪些
    sealed class MyTestAttribute : System.Attribute {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public int ID { get; set; }

        public MyTestAttribute(string des)
        {
            this.Description = des;
        }
    }
}
