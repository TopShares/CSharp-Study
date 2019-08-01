using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    /// 发布者
    /// 一只猫，miao一声
    /// 导致一系列的触发动作
    /// 
    /// 发布者
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang();
            new Mouse().Run();
           
            new Baby().Cry();
            new Mother().Wispher();
            //new Brother().Turn();
            new Father().Roar();
            new Neighbor().Awake();
            new Stealer().Hide();

        }




        public Action MiaoAction;
        public void MiaoDelegate()
        {
            Console.WriteLine("{0} MiaoDelegate", this.GetType().Name);
            if (MiaoAction != null)
                MiaoAction.Invoke();
            //MiaoAction = null;
        }


        //声明一个委托的实例，加上event关键字
        //委托是一种类型，而事件是委托的一个实例，然后加了个event关键字
        //控制了实例的使用权限，更加安全
        public event Action MiaoActionEvent;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoActionEvent", this.GetType().Name);
            if (MiaoActionEvent != null)
                MiaoActionEvent.Invoke();
            //MiaoActionEvent = null;
        }

    }
}
