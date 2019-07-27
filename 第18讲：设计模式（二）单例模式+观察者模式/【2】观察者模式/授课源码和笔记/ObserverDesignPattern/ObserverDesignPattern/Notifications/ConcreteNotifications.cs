using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    /// <summary>
    /// 具体通知者
    /// 主要作用：保存相关信息，在通知发生的时候，给所有的观察者发出通知
    /// 实现方法：继承抽象通知者
    /// </summary>
    class ConcreteNotifications : AbstractNotifications
    {
        /// <summary>
        /// 具体通知内容
        /// </summary>
        public string PulishedMessage { get; set; }
    }
}
