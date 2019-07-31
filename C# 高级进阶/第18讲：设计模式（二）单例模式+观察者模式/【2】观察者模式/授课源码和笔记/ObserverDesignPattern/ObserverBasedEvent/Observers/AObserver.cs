using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedEvent
{
    /// <summary>
    /// 观察者A
    /// </summary>
    class AObserver
    {
        //这里都是观察者A的其他成员...



        //观察者名字
        private string observerName;
        //具体通知者（接口类型）
        private INotifications notifications;

        public AObserver(INotifications notifications, string name)
        {
            this.notifications = notifications;
            this.observerName = name;
        }

        //响应的具体动作
        public void AMethod()
        {
            Console.WriteLine($"{observerName}   响应动作：AMethod()");
            //实际开发中，在这里编写具体执行的行为。。。


        }
    }
}
