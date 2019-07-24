using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoInherit
{
    class Cat
    {
        public string Name { get; set; }//名字
        public string Color { get; set; }//颜色
        public string Kind { get; set; }//种类
        public string Favorite { get; set; }//喜好
        //自我介绍
        public void Introduce()
        {
            string info = string.Format("我是漂亮的{0}，我的名字叫{1}，身穿{2}的衣服，我爱吃{3}！",
                Kind, Name, Color, Favorite);
            Console.WriteLine(info);
        }
        //跳舞
        public void Dancing()
        {
            Console.WriteLine("下面我给大家表演《小猫迪斯科》，请大家鼓掌啊：>");
        }
    }
}
