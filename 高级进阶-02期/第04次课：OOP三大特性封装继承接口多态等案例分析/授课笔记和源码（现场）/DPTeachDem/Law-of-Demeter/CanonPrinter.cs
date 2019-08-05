using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Law_of_Demeter
{
    public class CanonPrinter : IPrinter
    {
        public void Copy()
        {
            Console.WriteLine("佳能打印机正在复印...");
        }

        public void Print()
        {
            Console.WriteLine("佳能打印机正在打印...");
        }
    }
}
