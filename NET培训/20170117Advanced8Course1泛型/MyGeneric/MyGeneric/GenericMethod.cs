using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericMethod
    {
        /// <summary>
        /// 延迟声明：把参数类型的声明推迟到调用
        /// 不是语法糖，而是由框架升级提供的功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
        }


        /// <summary>
        /// 打印个object值
        /// 1 任何父类出现的地方，都可以使用子类来替换
        /// 2 object是一切类型的父类
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), oParameter.GetType().Name, oParameter);
        }
    }
}
