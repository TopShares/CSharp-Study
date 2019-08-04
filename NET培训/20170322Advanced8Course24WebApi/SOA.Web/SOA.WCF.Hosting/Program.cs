using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("I'm Console");
                ServiceInit.StartService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }

        }
    }
}
