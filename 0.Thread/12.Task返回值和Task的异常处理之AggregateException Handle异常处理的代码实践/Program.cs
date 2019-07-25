using System;
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
            var task = Task.Factory.StartNew(() =>
            {
                var childTask1 = Task.Factory.StartNew(() =>
                {
                    throw new Exception("我是 childTask1 异常");
                }, TaskCreationOptions.AttachedToParent);

                var childTask2 = Task.Factory.StartNew(() =>
                {
                    throw new Exception("我是 childTask2 异常");
                }, TaskCreationOptions.AttachedToParent);
            });

            try
            {
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    ex.Handle(x =>
                    {
                        if (x.InnerException.Message == "我是 childTask1 异常")
                        {
                            return true;
                        }

                        return false;
                    });
                }
            }
            catch (Exception ex)
            {
            }

            try
            {

            }
            catch (InvalidCastException ex)
            {
                throw;
            }

            Console.Read();
        }
    }
}


