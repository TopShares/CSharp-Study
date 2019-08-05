using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread04
{
    class Program
    {
        #region 比较Release和Debug的性能
        static void Main(string[] args)
        {
            //获取数据列表的路径
            string dataPath = Environment.CurrentDirectory + "//MyDataList.txt";
            //获取全部数据到集合
            List<long> dataList = File.ReadAllLines(dataPath).Select(i => Convert.ToInt64(i)).ToList();
            //循环排序10次比较性能         
            for (int i = 1; i <= 10; i++)
            {
                Stopwatch watch = Stopwatch.StartNew();//初始化实例，并将运行时间设置为0        
                List<long> newDataList = BubbleSort(dataList);//调用冒泡排序算法实现排序
                watch.Stop();
                Console.WriteLine($"第{i}次:\t{watch.ElapsedMilliseconds}");//展示运行毫秒数
            }
            Console.Read();
        }

        ////冒泡排序的实现
        static List<long> BubbleSort(List<long> dataList)
        {
            long tempData;//临时数据          
            for (int a = 0; a < dataList.Count - 1; a++)
            {
                for (int b = dataList.Count - 1; b > a; b--)
                {
                    if (dataList[b - 1] > dataList[b])   //如果前面一个数大于后面一个数则交换
                    {
                        tempData = dataList[b - 1];
                        dataList[b - 1] = dataList[b];
                        dataList[b] = tempData;
                    }
                }
            }
            return dataList;
        }

        #endregion

        #region Release中bug的解决

        //static void Main(string[] args)
        //{
        //    bool stop = false;//主线程定义一个变量（如果是用Release，会将stop变量放到CPU的Cache中）

        //    Thread thread = new Thread(() =>
        //    {
        //        int a = 0;
        //        while (!stop)     //子线程访问主线程的变量
        //        {
        //            a++;
        //            // Console.WriteLine(a++);      如果输出了，则不会出现主程序无法输出的问题。         
        //        }
        //    });
        //    thread.Start();
        //    thread.IsBackground = false;

        //    Thread.Sleep(1000);

        //    stop = true;//主线程也在使用stop变量

        //    thread.Join();//等待子线程结束

        //    Console.WriteLine("主线程执行结束！");
        //    Console.ReadLine();
        //}

        ////【解决方法1：使用 Thread.MemoryBarrier()】
        //static void Main(string[] args)
        //{         
        //    bool stop = false;  

        //    Thread thread = new Thread(() =>
        //    {
        //        int a = 0;
        //        while (!stop)  
        //        {
        //            //在此方法之前的内存写入都要及时从cpu cache中更新到 memory。
        //            //在此方法之后的内存读取都要从memory中读取，而不是cpu cache。
        //            Thread.MemoryBarrier();
        //            a++;                        
        //        }
        //    });
        //    thread.Start();
        //    thread.IsBackground = false;

        //    Thread.Sleep(1000);
        //    stop = true;
        //    thread.Join();
        //    Console.WriteLine("主线程执行结束！");
        //    Console.ReadLine();
        //}

        //【解决方法2：使用 Thread.VolatileRead()】
        //static void Main(string[] args)
        //{
        //    int stop = 0;

        //    Thread thread = new Thread(() =>
        //    {
        //        int a = 0;
        //        while (stop == 0)
        //        {
        //            Thread.VolatileRead(ref stop);//写入的最新值，就是memory中的最新值
        //            a++;
        //        }
        //    });
        //    thread.Start();
        //    thread.IsBackground = false;

        //    Thread.Sleep(1000);
        //    stop = 1;
        //    thread.Join();
        //    Console.WriteLine("主线程执行结束！");
        //    Console.ReadLine();
        //}

        #endregion

    }
}







