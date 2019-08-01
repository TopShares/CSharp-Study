using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印个int值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }

        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }

        /// <summary>
        /// 打印个DateTime值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
        }











        /// <summary>
        /// 打印个object值
        /// 1 任何父类出现的地方，都可以使用子类来替换
        /// 2 object是一切类型的父类
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            //((People)tParameter).Id
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }
    }
}
