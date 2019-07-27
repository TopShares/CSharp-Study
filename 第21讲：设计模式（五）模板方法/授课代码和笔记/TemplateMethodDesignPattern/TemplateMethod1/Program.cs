using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductAProcess pap = new ProductAProcess("A产品");
            pap.Process1();
            pap.Process2();
            pap.Process3();
            pap.Process4();
            Console.WriteLine("-----------------------------------------------");
            ProductBProcess pbp = new ProductBProcess("B产品");
            pbp.Process1();
            pbp.Process2();
            pbp.Process3();
            pbp.Process4();

            Console.Read();
        }
    }
}
