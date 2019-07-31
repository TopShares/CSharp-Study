using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class CanonPrinter : IMultiPrinter
    {
        public void Print(string contents)
        {
            //在这里编写打印程序...
            Console.WriteLine("佳能打印机正在打印：" + contents);
        }
        public void Copy(string contents)
        {
            //在这里编写复印程序...
            Console.WriteLine("佳能打印机正在复印：" + contents);
        }
        public bool Fax(string contents)
        {
            //在这里编写传真程序...
            Console.WriteLine("佳能打印机正在传真：" + contents);
            return true;
        }


    }
}
