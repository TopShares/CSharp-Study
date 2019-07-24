using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TestMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 100000000; i++)
            {
                CommonMethod(i);
            }
            for (int a = 0; a < 100000000; a++)
            {
                CommonMethod((double)a);
            }
            sw1.Stop();
            Console.WriteLine("调用特定类型方法耗费的时间：");
            Console.WriteLine(sw1.ElapsedMilliseconds.ToString());

            //===========================================
            Stopwatch sw2= new Stopwatch();
            sw2.Start();
            for (int i = 0; i < 100000000; i++)
            {
                ObjectMethod(i);
            }
            for (int a = 0; a < 100000000; a++)
            {
                ObjectMethod((double)a);
            }
            sw2.Stop();
            Console.WriteLine("调用object类型方法耗费的时间：");
            Console.WriteLine(sw2.ElapsedMilliseconds.ToString());

            //===========================================
            Stopwatch sw3 = new Stopwatch();
            sw3.Start();
            for (int i = 0; i < 100000000; i++)
            {
                GenericMethod(i);
            }
            for (int a = 0; a < 100000000; a++)
            {
                GenericMethod((double)a);
            }
            sw3.Stop();
            Console.WriteLine("调用泛型类型方法耗费的时间：");
            Console.WriteLine(sw3.ElapsedMilliseconds.ToString());

            Console.Read();
        }

        static void CommonMethod(int a)
        {
            //数据处理...
        }
        static void CommonMethod(double a)
        {
            //数据处理...
        }

        static void ObjectMethod(object a)
        {
            //数据处理...
            //if (a is int)
            //{

            //}
            //else if (a is double)
            //{

            //}
        }

        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        static void GenericMethod<T>(T a)
        {

        }
    }
}
