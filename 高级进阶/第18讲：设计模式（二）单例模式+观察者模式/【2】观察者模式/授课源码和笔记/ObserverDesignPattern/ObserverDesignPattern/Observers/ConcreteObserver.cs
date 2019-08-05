using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    /// <summary>
    /// 具体观察者
    /// 主要作用：实现抽象观察者所要求的接口
    /// 实现方法：实现抽象类，并保存观察者
    /// </summary>
    class ConcreteObserver : AbstractObserver
    {
        private string observerName;//观察者名字
        private string receivedMessage;//观察者接受到的消息

        private ConcreteNotifications cNotifications;//具体通知者

        public ConcreteObserver(ConcreteNotifications notification, string name)
        {
            this.cNotifications = notification;
            this.observerName = name;
        }

        /// <summary>
        /// 就是根据通知，做出反应
        /// </summary>
        public override void Update()
        {
            this.receivedMessage = cNotifications.PulishedMessage;
            Console.WriteLine($"观察者：{observerName} 收到的通知内容：{receivedMessage}");
        }
    }
}
