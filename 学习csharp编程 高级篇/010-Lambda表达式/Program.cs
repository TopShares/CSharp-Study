using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_Lambda表达式 {
    class Program {
        static void Main(string[] args) {
            //lambda表达式用来代替匿名方法，所以一个lambda表达式也是定义了一个方法
            //Func<int, int, int> plus = delegate(int arg1, int arg2) {
            //    return arg1 + arg2;
            //};
            //Func<int, int, int> plus = (arg1, arg2) =>// lambda表达式的参数是不需要声明类型的
            //{
            //    return arg1 + arg2;
            //};
            //Console.WriteLine(plus(90,60));

            Func<int, int> test2 = a => a+1;//lambda表示的参数只有一个的时候，可以不加上括号  当函数体的语句只有一句的时候，我们可以不加上大括号 也可以不加上return语句
            Func<int, int> test3 = (a) =>
            {
                return a + 1;
            };
            Console.WriteLine(test2(34));
            Console.WriteLine(test3(34));
            Console.ReadKey();
        }
    }
}
