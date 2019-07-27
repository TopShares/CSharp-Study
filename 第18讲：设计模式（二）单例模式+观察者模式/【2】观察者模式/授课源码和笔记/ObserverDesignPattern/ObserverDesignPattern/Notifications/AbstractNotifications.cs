using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    /// <summary>
    /// 抽象通知者
    /// 具体作用：管理所有的观察者，一个通知者，可以面对多个观察者（聚合观察者）
    /// 
    /// </summary>
    abstract class AbstractNotifications
    {
        //聚集多个观察者
        private List<AbstractObserver> observerList = new List<AbstractObserver>();

        /// <summary>
        /// 增加观察者（增加一个关注人）
        /// </summary>
        /// <param name="observer"></param>
        public void Add(AbstractObserver observer)
        {
            observerList.Add(observer);
        }
        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer"></param>
        public void Delete(AbstractObserver observer)
        {
            observerList.Remove(observer);
        }

        /// <summary>
        /// 群发通知
        /// </summary>
        public void Notify()
        {
            foreach (var item in observerList)
            {
                item.Update();
            }
        }
    }
}
