using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    /// <summary>
    /// 辅导员泛型类：1个泛型参数
    /// </summary>
    public class Instructor1<T1>
    {
        public void SayHello(T1 t1)
        {
            Console.WriteLine($"GenericInstructor1<T1 >： public void SayHello(T1 t1) 方法被调用！");
            Console.WriteLine($"T1的类型={t1.GetType().Name}");
        }
    }
    /// <summary>
    /// 辅导员泛型类：2个泛型参数
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Instructor2<T1, T2>
    {
        public void SayHello(T1 t1, T2 t2)
        {
            Console.WriteLine($"GenericInstructor2<T1, T2>： public void SayHello(T1 t1,T2 t2) 方法被调用！");
            Console.WriteLine($"T1的类型={t1.GetType().Name}  T2的类型={t2.GetType().Name} ");
            Console.WriteLine($"大家好！我是{t1}{t2}");
        }
    }
    /// <summary>
    /// 辅导员泛型类：3个泛型参数
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class Instructor3<T1, T2, T3>
    {
        public void SayHello(T1 t1, T2 t2, T3 t3)
        {
            Console.WriteLine($"GenericInstructor3<T1, T2, T3>： public void SayHello(T1 t1,T2 t2,T3 t3) 方法被调用！");
            Console.WriteLine($"T1的类型={t1.GetType().Name}  T2的类型={t2.GetType().Name}  T3的类型={t3.GetType().Name}");
        }
    }
}
