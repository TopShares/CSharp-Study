using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_委托 {
    class Program
    {
        private delegate string GetAString();//定义了一个委托类型，这个委托类型的名字叫做GetAString
        static void Main(string[] args)
        {
            //int x = 40;
            ////string s = x.ToString();//tostring 方法用来把数据转换成字符串
            ////Console.WriteLine(s);
            ////使用委托类型 创建实例
            ////GetAString a = new GetAString(x.ToString);//a指向了x中的tostring方法
            //GetAString a = x.ToString;

            ////string s = a();//通过委托实例去调用 x中的tostring方法
            //string s = a.Invoke();//通过invoke方法调用a所引用的方法
            //Console.WriteLine(s);//通过委托类型是调用一个方法，跟直接调用这个方法 作用是一样的


            //实例2 使用委托类型作为方法的参数
            PrintString method = Method1;
            PrintStr(method);
            method = Method2;
            PrintStr(method);
            Console.ReadKey();
        }

        private delegate void PrintString();

        static void PrintStr( PrintString print )
        {
            print();
        }

        static void Method1() {
            Console.WriteLine("method1");
        }
        static void Method2() {
            Console.WriteLine("method2");
        }
    }
}
