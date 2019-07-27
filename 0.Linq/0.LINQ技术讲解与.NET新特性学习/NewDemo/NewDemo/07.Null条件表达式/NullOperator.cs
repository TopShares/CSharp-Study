using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    /// <summary>
    /// null操作符：null传递操作符简化了空值的检查
    /// </summary>
    class NullOperator
    {
        string[] sArray = new string[] { "bc", "cde", null, "efgg", null };

        //以前用法
        public void OldMethod()
        {
            foreach (string item in sArray)
            {
                var length = item == null ? 0 : item.Length;
                Console.WriteLine(length);
            }
            Console.WriteLine("---");
        }
        //新方法：
        public void NewMethod()
        {
            foreach (string item in sArray)
            {
                var length = item?.Length;//如果为null直接输出null
                Console.WriteLine(length);
            }
            Console.WriteLine("---");
            foreach (string item in sArray)
            {
                var length = item?.Length ?? 0;
                Console.WriteLine(length);
            }
        }

    }
}
