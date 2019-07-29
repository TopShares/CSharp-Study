using System;
using System.Threading;
using _020_线程争用问题;

namespace _020_线程问题_争用条件 {
    class Program {
        static void ChangeState(object o)
        {
            MyThreadObject m = o as MyThreadObject;
            while (true)
            {
                lock (m)//向系统申请可不可以 锁定m对象 如果m对象没有被锁定，那么可以 如果m对象呗锁定了，那么这个语句会暂停，知道申请到m对象
                {
                    m.ChangeState();//在同一时刻 只有一个线程在执行这个方法
                }//释放对m的锁定
                
            }
        }
        static void Main(string[] args) {
            MyThreadObject m = new MyThreadObject();
            Thread t = new Thread(ChangeState);
            t.Start(m);

            new Thread(ChangeState).Start(m);

            Console.ReadKey();
        }
    }
}
