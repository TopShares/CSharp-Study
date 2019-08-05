using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_principle
{
    /// <summary>
    /// 父类
    /// </summary>
    public abstract class Printer
    {
        public string Brand { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// 必须重写
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// 可以直接使用
        /// </summary>
        public void Copy()
        {
            Console.WriteLine("正在调用父类的【复印】方法...");
        }

        //还可以增加其他的实例方法....

        /// <summary>
        /// 可以重写
        /// </summary>
        public virtual void Scan()
        {
            Console.WriteLine("正在调用父类的【扫描】方法...");
        }
    }
}
