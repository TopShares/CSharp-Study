using MyDelegateEvent.Delegate;
using MyDelegateEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 1 委托的声明、实例化和调用
    /// 2 泛型委托--Func Action
    /// 3 委托的意义：解耦
    /// 4 委托的意义：异步多线程
    /// 5 委托的意义：多播委托
    /// 6 事件 观察者模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班VIP课程，今天是Eleven老师为大家带来的委托事件的学习");
                //MyDelegate myDelegate = new MyDelegate();
                //myDelegate.Show();

                //CarFactory carFactory = new CarFactory();
                ////carFactory.BuildCar(EngineType.NaturalInspiration);
                ////carFactory.BuildCar(EngineType.Turbo);
                ////carFactory.BuildCar(EngineType.Electric);

                //CarFactory.BuildEngineDelegate method = new CarFactory.BuildEngineDelegate
                //(carFactory.BuildEngineNaturalInspiration);

                //carFactory.BuildCar(method);

                //CarFactory.SafeInvoke(() =>
                //    {
                //        carFactory.BuildCar(method);
                //    });

                {
                    Console.WriteLine("************cat.Miao();***********");
                    Cat cat = new Cat();
                    cat.Miao();

                    Console.WriteLine("************cat.MiaoDelegate();***********");
                    cat.MiaoAction += new Dog().Wang;
                    cat.MiaoAction += new Mouse().Run;
                    cat.MiaoAction += new Baby().Cry;
                    cat.MiaoAction += new Mother().Wispher;
                    cat.MiaoAction += new Brother().Turn;
                    cat.MiaoAction += new Father().Roar;
                    cat.MiaoAction += new Neighbor().Awake;
                    cat.MiaoAction += new Stealer().Hide;

                    cat.MiaoAction.Invoke();
                    cat.MiaoAction = null;


                    cat.MiaoAction -= new Stealer().Hide;
                    cat.MiaoDelegate();


                    Console.WriteLine("************cat.MiaoEvent();***********");
                    cat.MiaoActionEvent += new Dog().Wang;//订阅
                    cat.MiaoActionEvent += new Mouse().Run;
                    cat.MiaoActionEvent += new Baby().Cry;
                    cat.MiaoActionEvent += new Mother().Wispher;
                    cat.MiaoActionEvent += new Brother().Turn;
                    cat.MiaoActionEvent += new Father().Roar;
                    cat.MiaoActionEvent += new Neighbor().Awake;

                    //cat.MiaoActionEvent.Invoke();
                    //cat.MiaoActionEvent = null;

                    cat.MiaoAction -= new Stealer().Hide;//取消订阅
                    cat.MiaoActionEvent += new Stealer().Hide;

                    cat.MiaoEvent();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
