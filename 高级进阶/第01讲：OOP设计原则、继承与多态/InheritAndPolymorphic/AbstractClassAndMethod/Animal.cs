using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClassAndMethod
{
    abstract class Animal
    {
        //父类构造函数
        public Animal() { }
        public Animal(string name, string color, string kind)
        {
            this.Color = color;
            this.Name = name;
            this.Kind = kind;
        }
        #region
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
        #endregion
        //抽象方法
        public abstract void Have();
    }
}
