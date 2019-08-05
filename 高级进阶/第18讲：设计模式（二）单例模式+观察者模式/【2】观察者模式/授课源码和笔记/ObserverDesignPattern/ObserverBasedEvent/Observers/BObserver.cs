using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedEvent
{
    class BObserver
    {
        //这里都是观察者B的其他成员...



        //观察者名字
        private string observerName;
        //具体通知者（接口类型）
        private INotifications notifications;

        public BObserver(INotifications notifications, string name)
        {
            this.notifications = notifications;
            this.observerName = name;
        }

        //响应的具体动作
        public void BMethod()
        {
            Console.WriteLine($"{observerName}   响应动作：BMethod()");
            //实际开发中，在这里编写具体执行的行为。。。


        }
    }
}
