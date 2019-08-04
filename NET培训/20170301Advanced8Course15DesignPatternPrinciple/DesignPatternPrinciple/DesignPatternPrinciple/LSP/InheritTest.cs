using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    /// <summary>
    /// 张三    2年前写的
    /// </summary>
    public class Parent
    {
        public int Id { get; set; }
        public virtual void PlusShow(int x, int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }
        public void MinusShow(int x, int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }
    }

    /// <summary>
    /// 李四来了  升级子类
    /// </summary>
    public class Child : Parent
    {
        public string Name { get; set; }
        public override void PlusShow(int x, int y)
        {
            Console.WriteLine("计算");
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        /// <summary>
        /// 隐藏语法上是可以的
        /// 程序设计上是不推荐的
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public new void MinusShow(int x, int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x * 2 - y);
        }

        public void MinusShow(string x, string y)
        { }

        public void New()
        { }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Grand : Child
    { }
}
