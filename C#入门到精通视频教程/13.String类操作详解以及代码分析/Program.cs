using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mytest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var person = new Person();

            //Run(person);

            //Console.WriteLine(person.Name);

            //var str = string.Empty;

            //Run2(str);

            //Console.WriteLine(str);


            //var str = String.Concat("hello", "world");

            //var str2 = "hello" + "world";

            //var str3 = String.Format("{0}{1}", "hello", "world");

            //var s = string.Compare("1", "2");

            //var str = "";// string.Emtpy;

            //var b = string.IsNullOrEmpty(str);

            //var arr = new int[] { 10, 20, 30, 40, 50 };

            //var str = string.Join("|", arr);
        }

        static void Run(Person p)
        {
            p.Name = "jack";
        }

        static void Run2(string str)
        {
            str = "jack";
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
