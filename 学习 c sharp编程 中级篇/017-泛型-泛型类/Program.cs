using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_泛型_泛型类 {
    class Program {
        static void Main(string[] args) {
            //var o1 = new ClassA<int>(12,34);//当我们利用泛型类构造的时候，需要制定泛型的类型
            //string s = o1.GetSum();
            //Console.WriteLine(s);
            var o2 = new ClassA<string,int>("wwww.","taikr.cm");
            Console.WriteLine(o2.GetSum());
            Console.ReadKey();
        }
    }
}
