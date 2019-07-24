﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseNewKeyword
{
    class Cat : Animal
    {
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
        public override bool Equals(object obj)
        {
            Cat objCat = obj as Cat;
            if (objCat.Name == this.Name &&
                objCat.Kind == this.Kind &&
                objCat.Color == this.Color &&
                objCat.Favorite == this.Favorite)
                return true;
            else return false;
        }
    }
}
