using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static Person personLockMe = new Person();
        static void Main(string[] args)
        {
            //比如开启5个task
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Run();
                });
            }

            Console.Read();
        }

        static int nums = 0;

        static void Run()
        {
            Person person = new Person();

            for (int i = 0; i < 100; i++)
            {
                lock (person)
                {
                    Console.WriteLine(nums++);
                }

                //var b = false;
                //try
                //{

                //    //SpinLock
                //    Monitor.Enter(lockMe, ref b);
                //    Console.WriteLine(nums++);
                //    //seLock.Release();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    if (b) Monitor.Exit(lockMe);
                //}
            }
        }
    }

    class Person
    {

    }
}
