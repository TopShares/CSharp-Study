using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDeisgnPattern
{
    #region 没有使用单例模式的情况

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TestClass test1 = new TestClass();
    //        test1.TestMethod();

    //        TestClass test2 = new TestClass();
    //        test2.TestMethod();

    //        Console.Read();
    //    }
    //}

    //public class TestClass
    //{
    //    public TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(3000);
    //    }

    //    public void TestMethod()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
    //    }
    //}

    #endregion

    #region 使用单例模式

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TestClass test1 = TestClass.GetInstance();
    //        test1.TestMethod();

    //        TestClass test2 = TestClass.GetInstance();
    //        test2.TestMethod();

    //        //判断两个对象是否相等
    //        Console.WriteLine("两个对象是否相等？"+(test1==test2));

    //        Console.Read();
    //    }
    //}

    //public class TestClass
    //{
    //    //【1】创建一个私有的静态成员变量，用来保存当前类的实例
    //    private static TestClass instance;

    //    //【2】私有化构造方法：避免外界直接new这个类的实例
    //    private TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(3000);
    //    }

    //    //【3】创建一个让外界能获取到实例的静态方法
    //    public static TestClass GetInstance()
    //    {
    //        if (instance == null)
    //        {
    //            instance = new TestClass();
    //        }
    //        return instance;
    //    }

    //    public void TestMethod()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
    //    }
    //}

    #endregion

    #region 多线程情况下单例模式的解决1

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Task.Factory.StartNew(() =>
    //        {
    //            var test = TestClass.GetInstance();
    //            test.TestMethod();
    //        });
    //        Task.Factory.StartNew(() =>
    //        {
    //            var test = TestClass.GetInstance();
    //            test.TestMethod();
    //        });

    //        Console.Read();
    //    }
    //}

    //public class TestClass
    //{
    //    //【1】创建一个私有的静态成员变量，用来保存当前类的实例
    //    private static TestClass instance;

    //    //【2】私有化构造方法：避免外界直接new这个类的实例
    //    private TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(3000);
    //    }
    //    //【4】创建一个静态只读的辅助对象(为了lock使用的)
    //    private static readonly object helperObject = new object();

    //    //【3】创建一个让外界能获取到实例的静态方法
    //    public static TestClass GetInstance()
    //    {
    //        if (instance == null)//先判断实例是否存在，不存在则执行锁
    //        {
    //            lock (helperObject)
    //            {
    //                //这个判断是防止在实例为null的情况下，可能有多个线程都会排队等待进入
    //                //如果没有这判断，则第一个判断进来后所有的线程都会执行实例化
    //                //如果有了这个判断，那么第一个线程实例化以后，后面排队进来的线程就不会再实例化了。
    //                if (instance == null)
    //                {
    //                    instance = new TestClass();
    //                }
    //                //   instance = new TestClass();
    //            }
    //        }
    //        return instance;
    //    }

    //    public void TestMethod()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
    //    }
    //}

    #endregion

    #region 多线程情况下单例模式的解决2

    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                var test = TestClass.GetInstance();
                test.TestMethod();
            });
            Task.Factory.StartNew(() =>
            {
                var test = TestClass.GetInstance();
                test.TestMethod();
            });

            Console.Read();
        }
    }

    //使用密封类
    public sealed class TestClass
    {
        //【1】创建一个只读私有的成员变量，用来保存当前实例，并且在第一次引用成员的时候就创建。
        //其实我们就是把对象的创建交给CLR，这种方式本身就是线程安全
        private static readonly TestClass instance = new TestClass();

        //【2】私有化构造方法：避免外界直接new这个类的实例
        private TestClass()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
            //需要访问其他资源。。。会耗费时间。。。
            System.Threading.Thread.Sleep(3000);
        }

        //【3】创建一个外接能获取到实例的静态方法
        public static TestClass GetInstance()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   GetInstance()方法执行的时间");
            return instance;
        }

        public void TestMethod()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
        }
    }

    #endregion
}
