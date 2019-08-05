using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_principle
{
    public class HPPrinter : Printer
    {
        /// <summary>
        /// 必须重写父类中的抽象方法
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("【惠普】打印机正在打印...");
        }
        /// <summary>
        /// 可以重写的方法
        /// </summary>
        public override void Scan()
        {
            Console.WriteLine("【惠普】打印机正在扫描...");
        }
        /// <summary>
        /// 使用new覆盖方法
        /// </summary>
        public new void Copy()
        {
            Console.WriteLine("【惠普】打印机正在复印...");
        }
    }
}
