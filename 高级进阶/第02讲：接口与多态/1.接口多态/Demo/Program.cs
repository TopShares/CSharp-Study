using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(new HPMulitPrinter());
            Console.WriteLine("-----------------------------------------");
            Print(new CanonPrinter());

            Console.ReadLine();
        }

        //多态特性（接口作为方法的返回值、接口作为方法的参数）

        static void Print(IMultiPrinter printer)
        {
            printer.Print("学生信息表");
            printer.Copy("学生成绩单");
            printer.Fax("录取名单");           
        }


    }
}
