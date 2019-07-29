#define IsTest //定义一个宏

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _015_特性 {
    //通过制定属性的名字，给属性赋值，这种事命名参数
    [MyTest("简单的特性类",ID = 100)]//当我们使用特性的时候，后面的Attribute不需要写
    class Program {
        [Obsolete("这个方法过时了，使用NewMethod代替")] //obsolete特性用来表示一个方法被弃用了
        static void OldMethod()
        {
            Console.WriteLine("Oldmethod");
        }

        static void NewMethod()
        {
            
        }
        [Conditional("IsTest")]
        static void Test1() {
            Console.WriteLine("test1");
        }
        static void Test2() {
            Console.WriteLine("test2");
        }

        [DebuggerStepThrough]//可以跳过debugger 的单步调试 不让进入该方法（当我们确定这个方法没有任何错误的时候，可以使用这个）
        static void PrintOut(string str,[CallerFilePath] string fileName="",[CallerLineNumber] int lineNumber=0,[CallerMemberName] string methodName ="")
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(lineNumber);
            Console.WriteLine(methodName);
        }
        static void Main(string[] args) {
            //NewMethod();
            //OldMethod();
            //Console.ReadKey();

            //Test1();
            //Test2();
            //Test1();

            //PrintOut("123");
            //
            Type type = typeof (Program);//通过typeof+类名也可以获取type对象
            object[] array = type.GetCustomAttributes(false);
            MyTestAttribute mytest = array[0] as MyTestAttribute;
            Console.WriteLine(mytest.Description);
            Console.WriteLine(mytest.ID);
            Console.ReadKey();
        }
    }
}
