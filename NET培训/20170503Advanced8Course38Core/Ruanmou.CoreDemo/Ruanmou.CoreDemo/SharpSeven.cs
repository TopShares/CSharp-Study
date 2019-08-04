using System;
using System.Collections.Generic;
using System.Text;

namespace Ruanmou.CoreDemo
{
    /// <summary>
    /// c#6新语法
    /// </summary>
    public class SharpSeven
    {

        public void Show()
        {
            #region out参数
            {
                this.DoNoting(out int x, out int y);
                Console.WriteLine(x + y);

                this.DoNoting(out var l, out var m);

            }
            //Console.WriteLine(x + y);
            #endregion

            #region 模式
            this.PrintStars(null);
            this.PrintStars(3);

            this.Switch(null);
            this.Switch("ElevenEleven");
            this.Switch("Eleven");
            #endregion

            #region 元组
            {
                var result = this.LookupName(1);
                Console.WriteLine(result.Item1);
                Console.WriteLine(result.Item2);
                Console.WriteLine(result.Item3);
            }
            {
                var result = this.LookupNameByName(1);
                Console.WriteLine(result.first);
                Console.WriteLine(result.middle);
                Console.WriteLine(result.last);

                Console.WriteLine(result.Item1);
                Console.WriteLine(result.Item2);
                Console.WriteLine(result.Item3);
            }
            #endregion

            #region 局部函数
            {
                Add(3);
                int Add(int k)//闭合范围内的参数和局部变量在局部函数的内部是可用的，就如同它们在 lambda 表达式中一样。
                {
                    return 3 + k;
                }
            }
            #endregion

            #region 数字分隔号
            long big = 100_000;
            #endregion

        }

        /// <summary>
        /// System.ValueTuple 需要安装这个nuget包
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private (string, string, string) LookupName(long id) // tuple return type
        {
            return ("first", "middle", "last");
        }

        private (string first, string middle, string last) LookupNameByName(long id) // tuple return type
        {
            return ("first", "middle", "last");
            //return (first: "first", middle: "middle", last: "last");
        }

        /// <summary>
        /// 具有模式的 IS 表达式
        /// </summary>
        /// <param name="o"></param>
        public void PrintStars(object o)
        {
            if (o is null) return;     // 常量模式 "null"
            if (!(o is int i)) return; // 类型模式 定义了一个变量 "int i"
            Console.WriteLine(new string('*', i));
        }

        /// <summary>
        /// 可以设定任何类型的 Switch 语句（不只是原始类型）
        /// 模式可以用在 case 语句中
        /// Case 语句可以有特殊的条件
        /// </summary>
        /// <param name="text"></param>
        private void Switch(string text)
        {

            switch (text)
            {
                case "ElevenEleven" when text.Length > 10:
                    Console.WriteLine("ElevenEleven");
                    break;
                case "Eleven" when text.Length < 10:
                    Console.WriteLine("ElevenEleven");
                    break;
                case string s when s.Length > 7://模式
                    Console.WriteLine(s);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
                case null:
                    Console.WriteLine("null");
                    break;
            }
        }

        private void DoNoting(out int x, out int y)
        {
            x = 1;
            y = 2;
        }
    }
}
