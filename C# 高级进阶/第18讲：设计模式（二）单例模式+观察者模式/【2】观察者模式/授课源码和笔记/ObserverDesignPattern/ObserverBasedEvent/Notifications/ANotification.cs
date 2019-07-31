using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverBasedEvent
{
    /// <summary>
    /// 具体通知者
    /// </summary>
    class ANotification : INotifications
    {
        private string message;
        public string PublishedMessage
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public event ExecuteTask Update;//声明一个事件

        public void Notify()
        {
            Update();//在访问通知的时候，调用事件
        }
    }
}
