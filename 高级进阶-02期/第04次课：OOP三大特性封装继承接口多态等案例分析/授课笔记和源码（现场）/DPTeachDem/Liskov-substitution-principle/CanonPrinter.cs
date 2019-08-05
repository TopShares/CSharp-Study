using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_principle
{
    public class CanonPrinter : Printer
    {
        public override void Print()
        {
            Console.WriteLine("【佳能】打印机正在打印...");
        }
    }
}
