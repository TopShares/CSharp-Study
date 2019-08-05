using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Law_of_Demeter
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPrinter printer = new HPPrinter();

            IPrinter printer = SimpleFactory.CreatePrinter();//这个方法具体返回何种对象，我们不关心，知道的最少！
            printer.Print();

            Console.Read();
        }
    }
}
