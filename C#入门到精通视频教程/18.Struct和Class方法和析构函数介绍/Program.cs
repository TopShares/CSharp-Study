using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mytest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var person = new Person(10, 20);
            //var person = new Person();

            //Person.Fly();

            //Console.WriteLine("x={0}, y={1}", person.x, person.y);

            var test = new Test();

            test.Run();
        }
    }

    public class Test
    {
        public void Run()
        {
            var person = new Person();
        }
    }

    public class Person
    {
        public int x;

        public int y;

        public static void Fly()
        {
            Console.WriteLine("我是静态方法");
        }

        public void Run()
        {
            Console.WriteLine("i can fly");
        }

        public Person()
        {
            Console.WriteLine("我是实例构造函数");
        }

        ~Person()
        {
            Console.WriteLine("我是析构函数");
        }


        public Person(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        static Person()
        {
            Console.WriteLine("我是静态构造函数。");
        }
    }


    public struct Point
    {
        public int x;

        public int y;

        public void Run()
        {
            Console.WriteLine("i can fly");
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
