using FactoryPattern.War3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.War3.Service
{
    /// <summary>
    /// War3种族之一
    /// </summary>
    public class Undead : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "GoStop");
        }
    }

    public class UndeadArmy : IArmy
    {
        public void BuildArmy()
        {
            Console.WriteLine("{0} is {1}", this.GetType().Name, "goal 蜘蛛 冰龙");
        }
    }
}
