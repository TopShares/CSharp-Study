using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            ANotification objectNotification = new ANotification();

            //A 观察者
            AObserver a = new AObserver(objectNotification, "观察者A");
            BObserver b = new BObserver(objectNotification, "观察者B");

            //关联事件
            objectNotification.Update += new ExecuteTask(a.AMethod);
            objectNotification.Update += new ExecuteTask(b.BMethod);

            //准备消息
            objectNotification.PublishedMessage = "设备水位低于标准水位！";

            //消息发出
            objectNotification.Notify();

            Console.Read();
        }
    }
}
