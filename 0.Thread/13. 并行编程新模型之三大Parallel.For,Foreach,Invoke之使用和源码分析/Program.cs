using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            //ConcurrentStack<int> stack = new ConcurrentStack<int>();

            ////并行计算
            //Parallel.For(0, 100, new ParallelOptions()
            //{
            //    MaxDegreeOfParallelism = Environment.ProcessorCount - 1, //保证当前还有一个线程不会参与
            //}, (item, loop) =>
            //{
            //    System.Threading.Thread.Sleep(10000000);
            //    stack.Push(item);
            //});

            //Console.WriteLine(string.Join(",", stack));

            //var totalNums = 0;

            //Parallel.For<int>(1, 100, () => { return 0; }, (current, loop, total) =>
            //{
            //    total += (int)current;

            //    return total;
            //}, (total) =>
            //{
            //    Interlocked.Add(ref totalNums, total);
            //});

            //Console.WriteLine(totalNums);

            //int[] nums = new int[10];

            //Parallel.For(0, nums.Length, (item) =>
            //{
            //    //do logic
            //    var temp = nums[item];
            //});

            //Dictionary<int, int> dic = new Dictionary<int, int>()
            //{
            //    {1,100},
            //    {2,200 },
            //    {3,300 }
            //};

            //Parallel.ForEach(dic, (item) =>
            //{
            //    Console.WriteLine(item.Key);
            //});

            //Parallel.Invoke(() =>
            //{
            //    Console.WriteLine("我是并行计算1 " + Thread.CurrentThread.ManagedThreadId);
            //}, () =>
            //{
            //    Console.WriteLine("我是并行计算2 " + Thread.CurrentThread.ManagedThreadId);
            //});
        }
    }
}


