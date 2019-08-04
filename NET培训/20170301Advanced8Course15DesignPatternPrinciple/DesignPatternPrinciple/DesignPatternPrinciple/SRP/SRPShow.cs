using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    /// <summary>
    /// 封装
    /// </summary>
    public class SRPShow
    {
        public static void Show()
        {
            {
                Animal animal = new Animal("鸡");
                animal.Breath();
            }
            {
                Animal animal = new Animal("鱼");//呼吸水
                animal.Breath();
            }

            {
                Fish fish = new Fish("鱼");//呼吸水
                fish.Breath();
            }
        }
    }
}
