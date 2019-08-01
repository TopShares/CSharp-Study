using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLambda.Extend
{
    /// <summary>
    /// 扩展方法:静态类 静态方法  第一个参数类型前面加上this
    /// ExtendShow.ToInt(ivalue);换成 ivalue.ToInt()
    /// 
    /// 
    /// </summary>
    public static class ExtendShow
    {
        public static int ToInt(this int? iParameter)
        {
            return iParameter ?? 0;
        }

        public static void NoShow(this LambdaShow show)
        {
            Console.WriteLine("这里是扩展的 NoShow");
        }

        public static void Show(this LambdaShow show)
        {
            Console.WriteLine("这里是扩展的 NoShow");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object @object, int a)
        {
            return DateTime.Now;
        }

        public static DateTime Execute(this Action act)
        {
            act();
            return DateTime.Now;
        }

        public static IEnumerable<TSource> ElevenWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            List<TSource> studentList = new List<TSource>();
            foreach (TSource item in source)
            {
                bool bResult=func.Invoke(item);
                if (bResult)
                {
                    studentList.Add(item);
                }
            }
            return studentList;
        }


    }
}
