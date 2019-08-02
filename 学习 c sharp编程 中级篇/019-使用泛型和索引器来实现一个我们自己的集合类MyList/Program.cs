using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_使用泛型和索引器来实现一个我们自己的集合类MyList {
    class Program {
        static void Main(string[] args) {
            
            MyList<int> mylist = new MyList<int>();
            mylist.Add(234);
            mylist.Add(14);
            mylist.Add(24);
            mylist.Add(24);
            mylist.Add(90);
            mylist.Add(274);
            //mylist[index]
            mylist.Insert(1,2);
            //mylist.RemoveAt(-1);
            mylist[0] = 100;//通过索引器 设置值
            for (int i = 0; i < mylist.Count; i++)
            {
                //Console.WriteLine(mylist.GetItem(i));
                Console.WriteLine(mylist[i]);//通过索引器 取值
            }
            Console.WriteLine(mylist.IndexOf(24));
            Console.WriteLine(mylist.LastIndexOf(24));
            mylist.Sort();
            Console.WriteLine();
            for (int i = 0; i < mylist.Count; i++) {
                //Console.WriteLine(mylist.GetItem(i));
                Console.WriteLine(mylist[i]);//通过索引器 取值
            }
            Console.ReadKey();
        }
    }
}
