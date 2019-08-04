using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_线性表 {
    class Program {
        static void Main(string[] args) {
            //1.使用BCL中的List线性表
            //List<string> strList = new List<string>();
            //strList.Add("123");//0
            //strList.Add("456");//1
            //strList.Add("789");//2
            //Console.WriteLine(strList[1]);//通过索引器访问元素
            //strList.Remove("789");
            //Console.WriteLine(strList.Count);
            //strList.Clear();
            //Console.WriteLine(strList.Count);
            //Console.ReadKey();

            //使用我们自己的顺序表
            //SeqList<string> seqList = new SeqList<string>();
            LinkList<string> seqList = new LinkList<string>();

            seqList.Add("123");
            seqList.Add("456");
            seqList.Add("789");

            Console.WriteLine(seqList.GetEle(0));
            Console.WriteLine(seqList[0]);
            seqList.Insert("777",1);
            for (int i = 0; i < seqList.GetLength(); i++)
            {
                Console.Write(seqList[i]+" ");
            }
            Console.WriteLine();
            seqList.Delete(0);
            for (int i = 0; i < seqList.GetLength(); i++) {
                Console.Write(seqList[i] + " ");
            }
            Console.WriteLine();
            seqList.Clear();
            Console.WriteLine(seqList.GetLength());

            Console.ReadKey();


        }
    }
}
