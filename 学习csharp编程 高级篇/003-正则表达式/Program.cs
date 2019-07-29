using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _003_正则表达式 {
    class Program {
        static void Main(string[] args)
        {
            //定位元字符 ^ $
            //string s = "I am blue cat.";
            //string res  = Regex.Replace(s, "^", "开始：");//搜索字符串 符合正则表达式的情况，然后把所有符合的位置，替换成后面的字符串
            //Console.WriteLine(res);
            //string res = Regex.Replace(s, "$", "结束");
            //Console.WriteLine(res);

            //string s = Console.ReadLine();
            //bool isMatch = true;//默认标志位，表示s是一个合法密码(全部是数字)
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (s[i] < '0' || s[i] > '9')//当前字符如果不是数字字符
            //    {
            //        isMatch = false;
            //        break;
            //    }
            //}
            //if (isMatch)
            //{
            //    Console.WriteLine("是一个合法密码");
            //}
            //else
            //{
            //    Console.WriteLine("不是一个合法密码");
            //}
            //string pattern = @"^\d*$";//正则表达式
            //string pattern = @"\d*";
            //bool isMatch = Regex.IsMatch(s, pattern);
            
            //Console.WriteLine(isMatch);

            //string pattern = @"^\W*$";

            //反义字符
            //string str = "I am a cat.";
            //string pattern = @"[^ahou]";//它代表一个字符， 除了ahou之外的任意一个字符
            //string s = Regex.Replace(str, pattern, "*");
            //Console.WriteLine(s);

            //重复描述字符
            //string qq1 = "234234";
            //string qq2 = "234234234234234";
            //string qq3 = "d4234234234";
            //string pattern = @"^\d{5,12}$";
            //Console.WriteLine( Regex.IsMatch(qq1,pattern) );
            //Console.WriteLine( Regex.IsMatch(qq2,pattern) );
            //Console.WriteLine( Regex.IsMatch(qq3,pattern) );

            //string s = "34 ((*&sdflkj 路口的设计费";
            //string pattern = @"\d|[a-z]";
            //MatchCollection col = Regex.Matches(s, pattern);
            //foreach (Match match in col)
            //{
            //    Console.WriteLine(match.ToString());//调用tostring方法，会输出match所匹配到的字符串
            //}

            //string s = "zhangsan;lisi,wangwu.zhaoliu";
            ////string pattern = @"[;,.]";
            //string pattern = @"[;]|[,]|[.]";
            //string[] resArray = Regex.Split(s, pattern);
            //foreach (var s1 in resArray)
            //{
            //    Console.WriteLine(s1);
            //}

            //重复 多个字符 使用（abcd）{n}进行分组限定
            string inputStr = Console.ReadLine();
            string strGroup2 = @"(ab\w{2}){2}";//  == "ab\w{2}ab\w{2}"
            Console.WriteLine("分组字符重复2两次替换为5555，结果为：" + Regex.Replace(inputStr, strGroup2, "5555"));

            Console.ReadKey();
        }
    }
}
