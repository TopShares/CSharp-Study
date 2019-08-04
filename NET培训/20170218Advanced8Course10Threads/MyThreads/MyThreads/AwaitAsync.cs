using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThreads
{
    /// <summary>
    /// C# 5.0
    /// .net framework4.5
    /// CLR4.0
    /// 引入了async 和 await。这两个关键字可以让你更方便的写出异步代码。
    /// async/await是依附于Task的异步，
    /// 只有async方法认为是同步的，只是返回结果类型是
    /// await一定存在于async方法里面   只有async没有await的话是同步方法  
    /// 返回的结果是Task<T>，其中T为最终结果
    /// await关键字只能放在Task前面
    /// </summary>
    public class AwaitAsync
    {
        public static void TestAwait()
        {
            Test();
        }


        private async static Task Test()
        {
            Console.WriteLine("当前主线程id={0}", Thread.CurrentThread.ManagedThreadId);
            {
                //NoReturnNoAwait();
            }
            //{
            //NoReturn();
            //}
            {
                //Task t = NoReturnTask();
                //Console.WriteLine("Main Thread Task ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
                ////t.Wait();//主线程等待Task的完成
                //await t;//await后的代码会由子线程执行
            }
            //{
            //Task<long> t = SumAsync();
            //Console.WriteLine("Main Thread Task ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            //long lResult = t.Result;//访问result   主线程等待Task的完成
            //t.Wait();//等价于上一行
            //}
            //{
            Task<int> t = SumFactory();
            Console.WriteLine("Main Thread ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            long lResult = t.Result;//没有await和async 普通的task
            t.Wait();
            //}
            //Console.WriteLine("Test Sleep Start {0}", Thread.CurrentThread.ManagedThreadId);
            //Thread.Sleep(10000);
            //Console.WriteLine("Test Sleep End {0}", Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Main Thread ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }


        /// <summary>
        /// 只有async没有await，会有个warn
        /// 跟普通方法没有区别
        /// </summary>
        private static async void NoReturnNoAwait()
        {
            //主线程执行
            Console.WriteLine("NoReturnNoAwait Sleep before Task,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            Task task = Task.Run(() =>//启动新线程完成任务
            {
                Console.WriteLine("NoReturnNoAwait Sleep before,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("NoReturnNoAwait Sleep after,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            });

            //主线程执行
            Console.WriteLine("NoReturnNoAwait Sleep after Task,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
        }


        /// <summary>
        /// async/await 
        /// await 要放在task前面
        /// 不推荐void返回值，使用Task来代替
        /// Task和Task<T>能够使用await, Task.WhenAny, Task.WhenAll等方式组合使用。Async Void 不行
        /// </summary>
        private static async void NoReturn()
        {
            //主线程执行
            Console.WriteLine("NoReturn Sleep before await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(() =>
            {
                Console.WriteLine("NoReturn Sleep before,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("NoReturn Sleep after,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            });
            await task;
            //子线程执行   其实是封装成委托，在task之后成为回调（编译器功能  状态机实现）
            Console.WriteLine("NoReturn Sleep after await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// 无返回值  async Task == async void
        /// Task和Task<T>能够使用await, Task.WhenAny, Task.WhenAll等方式组合使用。Async Void 不行
        /// </summary>
        /// <returns></returns>
        private static async Task NoReturnTask()
        {
            //这里还是主线程的id
            Console.WriteLine("NoReturnTask Sleep before await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);

            Task task = Task.Run(() =>
            {
                Console.WriteLine("NoReturnTask Sleep before,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                Console.WriteLine("NoReturnTask Sleep after,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            });
            await task;
            Console.WriteLine("NoReturnTask Sleep after await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);

            //return new TaskFactory().StartNew(() => { });  不能return
        }

        /// <summary>
        /// 带返回值的Task  
        /// 要使用返回值就一定要等子线程计算完毕
        /// </summary>
        /// <returns>async 就只返回long</returns>
        private static async Task<long> SumAsync()
        {
            Console.WriteLine("SumAsync {1} start ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, 111);
            long result = 0;

            await Task.Run(() =>
            {
                for (int k = 0; k < 10; k++)
                {
                    Console.WriteLine("SumAsync {1} await Task.Run ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, k);
                    System.Threading.Thread.Sleep(1000);
                }

                for (long i = 0; i < 999999999; i++)
                {
                    result += i;
                }
            });
            Console.WriteLine("SumAsync {1} end ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, 111);
            return result;
        }

        /// <summary>
        /// 带返回值的Task  
        /// 要使用返回值就一定要等子线程计算完毕
        /// </summary>
        /// <returns>没有async Task</returns>
        private static Task<int> SumFactory()
        {
            Console.WriteLine("SumFactory {1} start ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, 111);
            TaskFactory taskFactory = new TaskFactory();
            Task<int> iResult = taskFactory.StartNew<int>(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("SumFactory {1} Task.Run ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, 123);
                return 123;
            });
            //Console.WriteLine("This is {0}", iResult.Result);
            Console.WriteLine("SumFactory {1} end ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId, 111);
            return iResult;
        }
    }
}
