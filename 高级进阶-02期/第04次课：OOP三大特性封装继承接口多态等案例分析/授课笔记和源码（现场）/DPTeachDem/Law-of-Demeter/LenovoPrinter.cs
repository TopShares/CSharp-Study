using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Law_of_Demeter
{
    public class LenovoPrinter : IPrinter
    {
        public void Copy()
        {
            Console.WriteLine("联想打印机正在复印...");
        }

        public void Print()
        {
            Console.WriteLine("联想打印机正在打印...");
        }
    }
}
