using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using System.Threading;
using System.Diagnostics;

namespace Thread04
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //获取数据列表的路径
        //    string dataPath = Environment.CurrentDirectory + "//MyDataList.txt";
        //    List<long> dataList = File.ReadAllLines(dataPath).Select(i => Convert.ToInt64(i)).ToList();

        //    //循环若干次比较性能
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        Stopwatch watch = Stopwatch.StartNew();
        //        List<long> newDataList = BubbleSort(dataList);
        //        watch.Stop();
        //        Console.WriteLine($"第{i}次：\t{watch.ElapsedMilliseconds}");
        //    }
        //    Console.Read();

        //}
        //static List<long> BubbleSort(List<long> dataList)
        //{
        //    long tempData;//临时数据          
        //    for (int a = 0; a < dataList.Count - 1; a++)
        //    {
        //        for (int b = dataList.Count - 1; b > a; b--)
        //        {
        //            if (dataList[b - 1] > dataList[b])   //如果前面一个数大于后面一个数则交换
        //            {
        //                tempData = dataList[b - 1];
        //                dataList[b - 1] = dataList[b];
        //                dataList[b] = tempData;
        //            }
        //        }
        //    }
        //    return dataList;
        //}

        //static void Main(string[] args)
        //{
        //    bool stop = false;//主线程定义的一个变量（如果是用Release,会将stop变量放到CPU的Cache中

        //    Thread thread = new Thread(() =>
        //     {
        //         int a = 0;
        //         while (!stop)  //在子线程中访问主线程的变量
        //         {
        //             a++;
        //             //  Console.WriteLine(a);
        //         }
        //     });

        //    thread.Start();
        //    thread.IsBackground = false;

        //    Thread.Sleep(2000);
        //    stop = true;//在主线程中使用top变量

        //    thread.Join();//等待子线程结束

        //    Console.WriteLine("主线程开始执行.....");

        //    Console.Read();
        //}

        //static void Main(string[] args)
        //{
        //    bool stop = false;//主线程定义的一个变量（如果是用Release,会将stop变量放到CPU的Cache中

        //    Thread thread = new Thread(() =>
        //    {
        //        int a = 0;
        //        while (!stop)  //在子线程中访问主线程的变量
        //        {
        //            //在这个方法之前的内存写入都要及时从cpu cache中更新到memory
        //            //在这个方法之后的内存读取都要从memory中读取，而不是cpu cache
        //            Thread.MemoryBarrier();
        //            a++;                
        //        }
        //    });

        //    thread.Start();
        //    thread.IsBackground = false;

        //    Thread.Sleep(2000);
        //    stop = true;//在主线程中使用top变量

        //    thread.Join();//等待子线程结束

        //    Console.WriteLine("主线程开始执行.....");

        //    Console.Read();
        //}

        static void Main(string[] args)
        {
            int stop = 0;

            Thread thread = new Thread(() =>
            {
                int a = 0;
                while (stop==0)  //在子线程中访问主线程的变量
                {
                    Thread.VolatileRead(ref stop);//写入的最新值，也就是memory中的最新值
                    a++;
                }
            });

            thread.Start();
            thread.IsBackground = false;

            Thread.Sleep(2000);
            stop = 1;//在主线程中使用top变量

            thread.Join();//等待子线程结束

            Console.WriteLine("主线程开始执行.....");

            Console.Read();
        }

    }
}
