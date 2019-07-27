using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod2
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractTemplate template1 = new ProductAProcess("A产品");
            template1.ProcessLogic();

            Console.WriteLine("-----------------------------------------------");

            AbstractTemplate template2 = new ProductAProcess("B产品");
            template2.ProcessLogic();

            Console.Read();
        }
    }
}
