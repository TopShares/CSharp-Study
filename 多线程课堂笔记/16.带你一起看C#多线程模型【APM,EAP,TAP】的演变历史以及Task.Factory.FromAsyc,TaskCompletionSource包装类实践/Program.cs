using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //FileStream fs = new FileStream(Environment.CurrentDirectory + "//1.txt", FileMode.Open);

            //var bytes = new byte[fs.Length];

            //var task = Task.Factory.FromAsync(fs.BeginRead, fs.EndRead, bytes, 0, bytes.Length, string.Empty);

            //var nums = task.Result;

            //Console.WriteLine(nums);

            //FileStream fs = new FileStream(Environment.CurrentDirectory + "//1.txt", FileMode.Open);

            //var bytes = new byte[fs.Length];

            //fs.BeginRead(bytes, 0, bytes.Length, (aysc) =>
            //{
            //    var nums = fs.EndRead(aysc);

            //    Console.WriteLine(nums);

            //}, string.Empty);

            //Console.Read();

            //Action action = () =>
            //{
            //    System.Threading.Thread.Sleep(100000);
            //    Console.WriteLine("hello world!");
            //};

            //var task = Task.Factory.FromAsync(action.BeginInvoke, action.EndInvoke, string.Empty);

            ////task.Start();

            //Console.Read();

            var task = GetTaskAsyc("http://cnblogs.com");

            var nums = task.Result;

            Console.WriteLine(nums.Length);
        }

        public static Task<byte[]> GetTaskAsyc(string url)
        {
            TaskCompletionSource<byte[]> source = new TaskCompletionSource<byte[]>();

            WebClient client = new WebClient();

            client.DownloadDataCompleted += (sender, e) =>
            {
                try
                {
                    //如果下载完成了，将当前的byte[]个数给task包装器
                    source.TrySetResult(e.Result);
                }
                catch (Exception ex)
                {
                    source.TrySetException(ex);
                }
            };

            client.DownloadDataAsync(new Uri(url));

            return source.Task;
        }
    }
}


