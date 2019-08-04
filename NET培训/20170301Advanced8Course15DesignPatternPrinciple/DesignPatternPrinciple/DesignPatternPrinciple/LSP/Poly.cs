using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    /// <summary>
    /// 普通方法是由编译时决定的
    ///   虚方法是由运行时决定的
    /// </summary>
    public class Poly
    {
        public static void Test()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            ParentClass instance = new ChildClass();
            Console.WriteLine("下面是instance.CommonMethod()");
            instance.CommonMethod();
            Console.WriteLine("下面是instance.VirtualMethod()");
            instance.VirtualMethod();
            Console.WriteLine("下面是instance.AbstractMethod()");
            instance.AbstractMethod();


            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
        }
    }

    #region abstract
    public abstract class ParentClass
    {
        /// <summary>
        /// CommonMethod
        /// </summary>
        public void CommonMethod()
        {
            Console.WriteLine("ParentClass CommonMethod");
        }

        /// <summary>
        /// virtual  虚方法  必须包含实现 但是可以被重载
        /// </summary>
        public virtual void VirtualMethod()
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        public virtual void VirtualMethod(string name)
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        public abstract void AbstractMethod();
    }

    public class ChildClass : ParentClass
    {
        /// <summary>
        /// new 隐藏
        /// </summary>
        public new void CommonMethod()
        {
            Console.WriteLine("ChildClass CommonMethod");
        }

        public void CommonMethod(string name)
        {
            Console.WriteLine("ChildClass CommonMethod");
        }
        //public void CommonMethod(int id)
        //{
        //    Console.WriteLine("ChildClass CommonMethod");
        //}
        //public void CommonMethod(int id, string name)
        //{
        //    Console.WriteLine("ChildClass CommonMethod");
        //}
        public void CommonMethod(int id, string name = "", string des = "", int size = 0)
        {
            Console.WriteLine("ChildClass CommonMethod");
        }
        public void CommonMethod(string name, int id)
        {
            Console.WriteLine("ChildClass CommonMethod");
        }

        /// <summary>
        /// virtual 可以被覆写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override void VirtualMethod()
        {
            Console.WriteLine("ChildClass VirtualMethod");
            base.VirtualMethod();
        }

        public sealed override void AbstractMethod()
        {
            Console.WriteLine("ChildClass AbstractMethod");
        }
    }

    public class GrandClass : ChildClass
    {

        //public override void AbstractMethod()
        //{
        //    base.AbstractMethod();
        //}

        public override void VirtualMethod()
        {
            base.VirtualMethod();
        }
    }
    #endregion abstract

}
