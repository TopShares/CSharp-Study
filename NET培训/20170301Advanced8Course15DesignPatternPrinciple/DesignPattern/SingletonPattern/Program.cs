using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {

        //public static Singleton singleton = new Singleton();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎大家来到.net高级班vip课程，今天是Eleven老师为大家带来的单例模式");

                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();


                //for (int i = 0; i < 5; i++)
                //{
                //    taskList.Add(taskFactory.StartNew(() =>
                //     {
                //         Singleton singleton = Singleton.CreateInstance(); //new Singleton();
                //         singleton.Write();
                //     }));
                //}
                //Task.WaitAll(taskList.ToArray());
                //Console.WriteLine("**********************************************************");
                //for (int i = 0; i < 5; i++)
                //{
                //    taskFactory.StartNew(() =>
                //    {
                //        Singleton singleton = Singleton.CreateInstance(); //new Singleton();
                //        singleton.Write();
                //    });
                //}
                {
                    Singleton singleton = Singleton.CreateInstance();
                }

                {
                    for (int i = 0; i < 10000; i++)
                    {
                        taskList.Add(taskFactory.StartNew(() =>
                         {
                             Singleton singleton = Singleton.CreateInstance(); //new Singleton();
                             singleton.Write();
                         }));
                    }
                    Task.WaitAll(taskList.ToArray());
                }
                {
                    Singleton singleton = Singleton.CreateInstance();
                    singleton.ShowI();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        //method1
        //method2
        //method3
        //method4
        //method5
    }
}
