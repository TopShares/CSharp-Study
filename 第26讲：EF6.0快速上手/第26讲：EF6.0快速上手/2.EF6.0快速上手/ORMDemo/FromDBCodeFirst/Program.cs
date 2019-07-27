using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromDBCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDB efdb = new EFDB();
            var student = efdb.Student.Find(100007);
            Console.Read();

        }
    }
}
