using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_Action委托 {
    class Program {
        static void PrintString()
        {
            Console.WriteLine("hello world.");
        }

        static void PrintInt(int i)
        {
            Console.WriteLine(i);
        }

        static void PrintString(string str)
        {
            Console.WriteLine(str);
        }

        static void PrintDoubleInt(int i1, int i2)
        {
            Console.WriteLine(i1+i2);
        }
        static void Main(string[] args)
        {
            //Action a = PrintString;//action是系统内置（预定义）的一个委托类型，它可以指向一个没有返回值，没有参数的方法
            //Action<int> a=PrintInt;//定义了一个委托类型，这个类型可以指向一个没有返回值，有一个int参数的方法
            //Action<string> a = PrintString;//定义了一个委托类型，这个类型可以指向一个没有返回值，有一个string参数的方法 在这里系统会自动寻找匹配的方法
            Action<int, int> a = PrintDoubleInt;
            a(34, 23);
            Console.ReadKey();
            //action可以后面通过泛型去指定action指向的方法的多个参数的类型 ，参数的类型跟action后面声明的委托类型是对应着的
           
        }
    }
}
