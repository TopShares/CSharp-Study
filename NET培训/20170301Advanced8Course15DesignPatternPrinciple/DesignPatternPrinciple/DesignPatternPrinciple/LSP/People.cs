using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //abstract void Eat();

        public void Traditional()
        {
            Console.WriteLine("仁义礼智信 温良恭俭让 ");
        }
    }

    public class Chinese : People
    {
        public string Kuaizi { get; set; }
    }

    public class Hubei : Chinese
    {
        public string Majiang { get; set; }
    }

    public class Japanese //: People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public new void Traditional()
        //{
        //    Console.WriteLine("忍者精神 ");
        //}
        public void Ninja()
        {
            Console.WriteLine("忍者精神 ");
        }

    }

}
