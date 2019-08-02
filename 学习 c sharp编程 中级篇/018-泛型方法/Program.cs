using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_泛型方法 {
    class Program {
        public static string GetSum<T,T2,T3,T4>(T a, T b)
        {
            return a + "" + b;
        } 
        static void Main(string[] args) {
            Console.WriteLine(GetSum<int,int,int,int>(12,34));
            Console.WriteLine(GetSum<double,double,double,double>(12.3,34.5));
            Console.WriteLine(GetSum<string,string,string,string>("23r,","wer3l2kj"));
            Console.ReadKey();
        }
    }
}
