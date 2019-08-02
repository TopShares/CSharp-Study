using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_异常处理_案例2 {
    class Program {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;
            Console.WriteLine("请输入第一个数字");
            while (true)
            {
                try {
                    num1 = Convert.ToInt32(Console.ReadLine());//在try块中，如果有一行代码发生了异常，那么try块中剩余的代码就不会执行了
                    break;
                } catch {
                    Console.WriteLine("您输入的不是一个整数，请重新输入");
                }
                //break;//把break放在这里的话，不管发布发生异常都会执行，因为try对异常进行了处理
            }
            Console.WriteLine("请输入第二个数字");
            while (true)
            {
                try {
                    num2 = Convert.ToInt32(Console.ReadLine());//在try块中，如果有一行代码发生了异常，那么try块中剩余的代码就不会执行了
                    break;
                } catch {
                    Console.WriteLine("您输入的不是一个整数，请重新输入");
                }
                //break;//把break放在这里的话，不管发布发生异常都会执行，因为try对异常进行了处理
            }
            int sum = num1 + num2;
            Console.WriteLine(sum);
            Console.ReadKey();

        }
    }
}
