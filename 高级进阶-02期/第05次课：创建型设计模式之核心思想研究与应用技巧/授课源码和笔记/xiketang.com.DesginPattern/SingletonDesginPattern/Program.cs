using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesginPattern
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
    //    /// <summary>
    //    /// 构造方法
    //    /// </summary>
    //    public TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(2000);
    //    }

    //    public void TestMethod()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
    //    }
    //}

    #endregion

    #region 使用单利模式（单线程情况）

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TestClass test1 = TestClass.GetInstance();
    //        test1.TestMethod();

    //        TestClass test2 = TestClass.GetInstance();
    //        test2.TestMethod();

    //        Console.Read();
    //    }
    //}
    //public class TestClass
    //{
    //    //【1】创建一个私有的静态成员变量，用来保存当前的实例
    //    private static TestClass instance;

    //    /// <summary>
    //    /// 【2】私有化构造方法：避免外界直接new这个类的实例
    //    /// </summary>
    //    private  TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(2000);
    //    }

    //    //【3】创建一个让外界能够获取到的实例方法
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

    #region 使用单利模式（多线程方案解决1）

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Task.Factory.StartNew(() =>
    //        {
    //            var test1 = TestClass.GetInstance();
    //            test1.TestMethod();
    //        });

    //        Task.Factory.StartNew(() =>
    //        {
    //            var test2 = TestClass.GetInstance();
    //            test2.TestMethod();
    //        });

    //        Console.Read();
    //    }
    //}
    //public class TestClass
    //{
    //    //【1】创建一个私有的静态成员变量，用来保存当前的实例
    //    private static TestClass instance;

    //    /// <summary>
    //    /// 【2】私有化构造方法：避免外界直接new这个类的实例
    //    /// </summary>
    //    private TestClass()
    //    {
    //        Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
    //        //需要访问其他资源。。。会耗费时间。。。
    //        System.Threading.Thread.Sleep(2000);
    //    }

    //    //【4】创建一个静态只读的辅助对象（就是为了lock使用）
    //    private static readonly object helperObject = new object();

    //    //【3】创建一个让外界能够获取到的实例方法
    //    public static TestClass GetInstance()
    //    {
    //        if (instance == null)
    //        {
    //            lock (helperObject)
    //            {
    //                if (instance == null)
    //                {
    //                    instance = new TestClass();
    //                }                  
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

    #region 使用单利模式（多线程方案解决2）：以后大家开发都用这种方式！

    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                var test1 = TestClass.GetInstance();
                test1.TestMethod();
            });

            Task.Factory.StartNew(() =>
            {
                var test2 = TestClass.GetInstance();
                test2.TestMethod();
            });

            Console.Read();
        }
    }
    public class TestClass
    {
        //【1】创建一个私有的静态成员变量，用来保存当前的实例，在第一次引用成员变量的时候就创建
        //其实我们就是把对象的创建交给CLR，这种方式本身就是线程安全
        private static TestClass instance = new TestClass();

        /// <summary>
        /// 【2】私有化构造方法：避免外界直接new这个类的实例
        /// </summary>
        private TestClass()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
            //需要访问其他资源。。。会耗费时间。。。
            System.Threading.Thread.Sleep(2000);
        }

        //【3】创建一个让外界能够获取到的实例方法
        public static TestClass GetInstance()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   GetInstance()方法执行时间");
            return instance;
        }

        public void TestMethod()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
        }
    }


    #endregion
}
