using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_错误处理_异常处理_ {
    class Program {
        static void Main(string[] args) {
            try
            {
                int[] myArray = {1, 2, 3, 4};
                int myEle = myArray[4];
            }
                //catch ( NullReferenceException e )//在这里我们虽然写了异常捕捉的程序，但是我们捕捉的类型不对，所以当发生别的类型的异常的时候，依然会终止程序的运行
                //{
                //    Console.WriteLine("发生了异常:IndexOutOfRangeException");
                //    Console.WriteLine("您访问数组的时候，下标越界了");
                //}
            catch//当我们不写catch的参数的时候，那么这个catch会捕捉出现的任何异常信息
            {
                Console.WriteLine("您访问数组的时候，下标越界了");
            }
            finally
            {
                Console.WriteLine("这里是finally里面执行的代码");
            }

            
            Console.WriteLine("test");
            Console.ReadKey();
        }
    }
}
