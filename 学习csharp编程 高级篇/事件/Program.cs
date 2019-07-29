using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件 {//Event
    class Program
    {
        public delegate void MyDelegate();

        //public MyDelegate mydelgate;//声明了一个委托类型的变量，作为类的成员
        public event MyDelegate mydelgate;//声明了一个委托类型的变量，作为类的成员
        static void Main(string[] args)
        {
        
            Program p = new Program();
            p.mydelgate = Test1;
            p.mydelgate();
            Console.ReadKey();
        }

        static void Test1()
        {
            Console.WriteLine("test1");
        }
    }
}
