using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _017_线程_通过Thread发起线程 {
    class Program {
        static void DownloadFile(object filename)
        {
            Console.WriteLine("开始下载:"  +Thread.CurrentThread.ManagedThreadId +filename);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");

        }
        static void Main(string[] args) {
            //Thread t = new Thread(DownloadFile);//创建出来Thread对象，这个线程并没有启动
            //t.Start();//开始，开始去执行线程
            //Console.WriteLine("Main");

            //Thread t = new Thread(() =>
            //{
            //    Console.WriteLine("开始下载:" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(2000);
            //    Console.WriteLine("下载完成");
            //});
            //t.Start();


            //Thread t = new Thread(DownloadFile);//创建出来Thread对象，这个线程并没有启动
            //t.Start("xxx.种子");//开始，开始去执行线程
            //Console.WriteLine("Main");

            //MyThread my = new MyThread("xxx.bt","http://www.xxx.bbs");
            //Thread t = new Thread(my.DownFile);//我们构造一个thread对象的时候，可以传递一个静态方法，也可以传递一个对象的普通方法
            //t.Start();

            //Thread t = new Thread(DownloadFile);//这个是前台线程
            Thread t = new Thread(DownloadFile);//这个是前台线程
            //t.IsBackground = true;//设置为后台线程 
            t.Start("xx");
            //t.Abort();//终止这个线程的执行
            t.Join();//当当前线程睡眠，等待t线程执行完，然后继续运行下面的代码
            //
        }
    }
}
