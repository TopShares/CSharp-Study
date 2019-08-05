using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    /// <summary>
    /// 抽象观察者
    /// 具体作用：为具体的观察者提供一个接口，在收到通知的时候，执行动作
    /// 实现方法：可以用抽象类或接口
    /// </summary>
    abstract class AbstractObserver
    {
        public abstract void Update();//更新的接口
    }
}
