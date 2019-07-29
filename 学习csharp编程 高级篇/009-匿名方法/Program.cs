using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_匿名方法 {
    class Program {
        static int Test1(int arg1, int arg2)
        {
            return arg1 + arg2;
        }
        static void Main(string[] args)
        {
            //Func<int, int, int> plus = Test1;
            //修改成匿名方法的形式
            Func<int, int, int> plus = delegate(int arg1, int arg2)
            {
                return arg1 + arg2;
            };
            //匿名方法 本质上是一个方法，只是没有名字，任何使用委托变量的地方都可以使用匿名方法赋值


            Console.ReadKey();
        }
    }
}
