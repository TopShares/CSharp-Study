

using System;
using System.Text;

namespace _002_字符串StringBuilder {
    class Program {
        static void Main(string[] args) {
            
            //1,
            //StringBuilder sb = new StringBuilder("www.devsiki.com");//利用构造函数创建stringbuilder
            //2
            //StringBuilder sb = new StringBuilder(20);//初始一个空的stringbuilder对象，占有20个字符的大小
            //3
            //StringBuilder sb = new StringBuilder("www.devsiki.com", 100);
            //sb.Append("/xxx.html");
            //当我们需要对一个字符串进行频繁的删除添加操作的时候，使用stringbuilder的效率比较高
            //Console.WriteLine(sb.ToString());

            //sb.Insert(0, "http://");
            //Console.WriteLine(sb);

            //sb.Remove(0, 3);
            //Console.WriteLine(sb);
            //sb.Replace(".", "");
            //sb.Replace('.', '-');
            //Console.WriteLine(sb);
             
            //string s = "www.devsiki.com";
            //s = s + "/xxx.html";
            //Console.WriteLine(s);

            

            Console.ReadKey();
        }
    }
}
