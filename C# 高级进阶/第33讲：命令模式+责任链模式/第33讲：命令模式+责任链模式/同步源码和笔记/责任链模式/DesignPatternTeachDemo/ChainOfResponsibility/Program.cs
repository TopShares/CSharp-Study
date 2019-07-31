using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //有若干任务处理者
            AbstractHandler hander1 = new ConcreteHandler1();
            AbstractHandler hander2 = new ConcreteHandler2();
            AbstractHandler hander3 = new ConcreteHandler3();


            //根据需要，将任务处理者，动态的组成一个链表（可以在其他地方进一步封装）
            hander1.SettHandler(hander2);
            hander2.SettHandler(hander3);

            //  hander3.SettHandler(hander8);//实际中，可以增加很多的任务处理者，而且可以动态组合链表
            hander1.RequstAction(11);

            //客户端使用
            hander1.RequstAction(2);
            hander1.RequstAction(6);
            hander1.RequstAction(7);

            Console.Read();

        }
    }
}
