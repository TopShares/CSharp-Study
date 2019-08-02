using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_操作列表的属性和方法 {
    class Program {
        static void Main(string[] args) {
            var scoreList = new List<int>();
            scoreList.Add(100);
            scoreList.Add(200);
            scoreList.Add(300);
            scoreList.Add(100);
            foreach (var temp in scoreList)
            {
                Console.Write(temp+" ");
            }
            Console.WriteLine();
            //scoreList.Insert(3, -1);//向指定索引位置插入元素
            //foreach (var temp in scoreList) {
            //    Console.Write(temp + " ");
            //}
            //Console.WriteLine();
            //scoreList.RemoveAt(0);
            //foreach (var temp in scoreList) {
            //    Console.Write(temp + " ");
            //}
            //Console.WriteLine();
            //int index  =scoreList.IndexOf(400);
            //Console.WriteLine(index);
            //Console.WriteLine( scoreList.IndexOf(100) );
            //Console.WriteLine( scoreList.LastIndexOf(100) );
            scoreList.Sort();
            foreach (var temp in scoreList) {
                Console.Write(temp + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
