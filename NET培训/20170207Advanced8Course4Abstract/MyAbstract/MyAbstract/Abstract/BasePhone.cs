using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract.Abstract
{
    /// <summary>
    /// 抽象类是一个类，里面可以包含一切类可以包含的
    /// 抽象成员 必须包含在抽象类里面，抽象类还可以包含普通成员
    /// 继承抽象类后，必须显示的override其抽象成员
    /// 抽象类不能直接实例化，声明的对象只能使用抽象类里的方法，不能用子类新增的方法
    /// 父类只有一个
    /// is a
    /// </summary>
    public abstract class BasePhone
    {
        public int Id { get; set; }
        public string Name = "123";
        public delegate void DoNothing();
        public event DoNothing DoNothingEvent;

        public void Show()
        {
            Console.WriteLine("这里是Show1");
        }
        public virtual void ShowVirtual()
        {
            Console.WriteLine("这里是Show");
        }

        /// <summary>
        /// 品牌
        /// </summary>
        /// <returns></returns>
        public abstract string Brand();

        /// <summary>
        /// 系统
        /// </summary>
        /// <returns></returns>
        public abstract string System();

        /// <summary>
        /// 打电话
        /// </summary>
        public abstract void Call();


        /// <summary>
        /// 拍照
        /// </summary>
        public abstract void Photo();

        public abstract void Do<T>();
    }
}
