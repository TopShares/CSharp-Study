using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

//1. 同步编程模式（SPM）
//2. 异步编程模型（APM）   ****Begin（）  ****End（）这两个方法通过配对实现，委托给线程去执行
//3. 基于事件的编程模型（EAP）
//    [WebClient]
//4. 基于Task的编程模型（TAP）

namespace Task03
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    FileStream fs = new FileStream("myfile.txt", FileMode.Open);
        //    var fileBytes = new byte[fs.Length];

        //    //参数：BeginRead：用于启动异步操作的委托。EndMethod：用于结束异步操作的委托
        //    var task = Task.Factory.FromAsync(fs.BeginRead, fs.EndRead, fileBytes, 0, fileBytes.Length, string.Empty);

        //    var nums = task.Result;
        //    Console.WriteLine(nums);
        //    Console.Read();
        //    //优点：实现简单。
        //}

        //static void Main(string[] args)
        //{
        //    FileStream fs = new FileStream("myfile.txt", FileMode.Open);
        //    var fileBytes = new byte[fs.Length];

        //    fs.BeginRead(fileBytes, 0, fileBytes.Length, (aysc) =>
        //       {
        //           var nums = fs.EndRead(aysc);
        //           Console.WriteLine(nums);
        //       },"");       


        //    Console.Read();
        //    //优点：实现简单。
        //}

        //static void Main(string[] args)
        //{
        //    Action myAction = () =>
        //      {
        //          System.Threading.Thread.Sleep(10000);
        //          Console.WriteLine("C#多线程中的Task深入学习！");
        //      };

        //    var task = Task.Factory.FromAsync(myAction.BeginInvoke, myAction.EndInvoke, string.Empty);
        //    Console.Read();
        //}

        static void Main(string[] args)
        {
            var task = GetTaskAysnc("http://www.xiketang.com");
            var nums = task.Result;

            Console.WriteLine(nums.Length);
            Console.Read();
        }

        public static Task<byte[]> GetTaskAysnc(string url)
        {
            //定义一个任务包装器
            TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
            System.Net.WebClient client = new System.Net.WebClient();

            //  client.DownloadDataCompleted += Client_DownloadDataCompleted;
            client.DownloadDataCompleted += (sender, e) =>
              {
                  try
                  {
                      tcs.TrySetResult(e.Result);//如果下载完成，则将当前的Byte[]格式给Task包装器
                  }
                  catch (Exception ex)
                  {
                      tcs.TrySetException(ex);
                  }
              };

            //从指定的URI中将资源作为Byte数组下载，封装异步操作
            client.DownloadDataAsync(new Uri(url));

            return tcs.Task;
        }

        //private static void Client_DownloadDataCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
