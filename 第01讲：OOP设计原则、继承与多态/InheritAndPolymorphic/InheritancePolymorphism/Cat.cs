﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritancePolymorphism
{
    class Cat : Animal
    {
        #region
        public Cat(string name, string color, string kind, string favorite)
            : base(name, color, kind)
        {
            this.Favorite = favorite;
        }
        //跳舞
        public void Dancing()
        {
            base.Introduce();
            Console.WriteLine("下面我给大家表演《小猫迪斯科》，请大家鼓掌啊：>");
        }
        #endregion
        //吃饭
        public override void Have()
        {
            Console.WriteLine("我们要吃香喷喷的烤鱼啦！");
        }
    }
}
