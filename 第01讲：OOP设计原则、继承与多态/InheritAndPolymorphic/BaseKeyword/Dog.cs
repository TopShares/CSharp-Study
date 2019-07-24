using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseKeyword
{
    class Dog : Animal
    {     
        public Dog(string name, string color, string kind, string favorite)
            : base(name, color, kind)
        {
            this.Favorite = favorite;
        }      
        //赛跑
        public void Race()
        {
            base.Introduce();
            Console.WriteLine("下面我给大家表演《狗狗精彩百米跨栏》，请大家鼓掌啊：>");
        }       
    }
}
