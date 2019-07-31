using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task04
{
    //C#5.0中引入了async和await。这两个关键字可以让我们更加轻松的完成异步代码的编写。
    //这个两个关键字一定要成对出现。方法前面添加async，方法里面可以有一个或多个await关键字。
    //实际开发中，我们只要用异步，就可以使用。更多的情况，在IO操作中，更加收人喜欢。
    //在.NET框架中，网络IO，文件IO操作，都有异步方法，比如MemoryStream，FileStream...
    class Program
    {
        //static void Main(string[] args)
        //{
        //    string txt = GetText().Result;
        //    Console.WriteLine(txt);

        //    Console.Read();
        //}

        //async表示这个方法内部异步调用。不见得这个方法就是异步方法。
        async static Task<string> GetText()
        {
            FileStream fs = new FileStream("myfile.txt", FileMode.Open);
            var fileBytes = new byte[fs.Length];

            //异步读取：await定义的其实是一个异步任务，以Task或者Task<TResult>作为返回值。
            await fs.ReadAsync(fileBytes, 0, fileBytes.Length);

            //以下内容都是回调内容
            string content = Encoding.Default.GetString(fileBytes);            
            return content;
        }
        //总结优点：程序编写简单，我们想实现一个异步任务，除了关键字之外，和同步方法没有什么区别，开发效率提升。
        //总结不足：对于返回值的情况，我们还不能完全用同步方法去理解。


        static void Main(string[] args)
        {
            TestAsyncAndAwait test = new Task04.TestAsyncAndAwait();
            test.ShowScore();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine(i);
            }

            test.AlikeMethod();

            Console.Read();
        }
    }

    public class TestAsyncAndAwait
    {

        private Random random = new Random();

        //定义一个同步方法
        private Task<int> QueryScore()
        {
            var task = Task.Run(() =>
              {
                  //模拟一个耗时的操作
                  Thread.Sleep(1000);
                  return random.Next(10, 100);
              });
            return task;
        }

        //让用户调用异步任务
        public async void ShowScore()
        {
            int result1 = await QueryScore();

            int result2 = await QueryScore();

            //下面再写代码就相当于回调，在QueryScore（）方法完成后自动调用
            string info = $"您的两次考试成绩是：{result1}  {result2}";
            Console.WriteLine(info);
        }

        //我们可以效仿一下异步任务
        public void AlikeMethod()
        {
            System.Runtime.CompilerServices.TaskAwaiter<int> awaiter = QueryScore().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                string info = $"您的考试成绩是：{result}";
                Console.WriteLine(info);
            });
        }

    }
}
