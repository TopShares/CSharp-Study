using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedEvent
{
    /// <summary>
    /// 通知者接口
    /// </summary>

    interface INotifications
    {
        string PublishedMessage { get; set; }
        void Notify();
    }

    /// <summary>
    /// 声明一个委托
    /// </summary>
    public delegate void ExecuteTask();
}
