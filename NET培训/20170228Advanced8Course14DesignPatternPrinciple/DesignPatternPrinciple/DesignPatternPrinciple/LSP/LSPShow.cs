using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    /// <summary>
    /// 继承、多态
    /// 任何使用基类的地方，都可以透明的使用其子类
    /// </summary>
    public class LSPShow
    {
        public static void Show()
        {
            Console.WriteLine("***************************");
            Poly.Test();

            {
                Chinese people = new Chinese();
                people.Traditional();
                Do(people);
            }
            {
                Hubei people = new Hubei();
                people.Traditional();
                Do(people);
            }
            {
                //People people = new People();
                //Do(people);
            }
            {
                Parent parent = new Parent();
                parent.PlusShow(3, 4);
                parent.MinusShow(4, 3);
            }
            {
                Parent parent = new Child();
                parent.PlusShow(3, 4);
                parent.MinusShow(4, 3);
            }
            {
                Child child = new Child();
                child.PlusShow(3, 4);
                child.MinusShow(4, 3);
            }
        }

        private static void Do(Chinese chinese)
        {

        }

    }
}
