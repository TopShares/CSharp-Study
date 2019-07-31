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
            Task task = new Task(() =>
            {
                //System.Threading.Thread.Sleep(1000000);
                Console.WriteLine("hello world!");
            });

            task.Start(new PerThreadTaskScheduler());

            Console.Read();
        }
    }

    public class PerThreadTaskScheduler : TaskScheduler
    {
        /// <summary>
        /// 给debug用的。
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }

        /// <summary>
        /// 执行task
        /// </summary>
        /// <param name="task"></param>
        protected override void QueueTask(Task task)
        {
            var thread = new Thread(() =>
            {
                TryExecuteTask(task);
            });

            thread.Start();
        }

        /// <summary>
        /// 同步执行
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskWasPreviouslyQueued"></param>
        /// <returns></returns>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return true;
        }
    }
}


