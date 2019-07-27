using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;


namespace NewDemo
{
    /// <summary>
    /// static声明静态类的引用
    /// </summary>
    class StaticClassApp
    {
        //以前用法：两个数的绝对值相加
        public static int OldMethod(int a, int b)
        {
            return Math.Abs(a) + Math.Abs(b);
        }

        //现在用法：使用using static System.Math;提前引入静态类，避免每次都调用Math类
        public static int NewMethod1(int a, int b)
        {
            return Abs(a) + Abs(b);
        }
        public static int NewMethod2(int a, int b) => Abs(a) + Abs(b);
    }
}
