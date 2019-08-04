using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;//静态导入 static 类

namespace Ruanmou.CoreDemo
{
    public class SharpSix
    {
        #region 自动属性初始化(Auto-property initializers)
        public string Name { get; set; } = "summit";
        public int Age { get; set; } = 22;
        public DateTime BirthDay { get; set; } = DateTime.Now.AddYears(-20);
        public IList<int> AgeList
        {
            get;
            set;
        } = new List<int> { 10, 20, 30, 40, 50 };
        #endregion


        public void Show(People peopleTest)
        {

            #region 字符串嵌入值(String interpolation)
            Console.WriteLine($"年龄:{this.Age}  生日:{this.BirthDay.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"年龄:{{{this.Age}}}  生日:{{{this.BirthDay.ToString("yyyy -MM-dd")}}}");

            Console.WriteLine($"{(this.Age <= 22 ? "小鲜肉" : "老鲜肉")}");
            #endregion

            #region 导入静态类(Using Static)
            Console.WriteLine($"之前的使用方式: {Math.Pow(4, 2)}");
            Console.WriteLine($"导入后可直接使用方法: {Pow(4, 2)}");
            #endregion

            #region 空值运算符(Null-conditional operators)
            int? iValue = 10;
            Console.WriteLine(iValue?.ToString());//不需要判断是否为空
            string name = null;
            Console.WriteLine(name?.ToString());
            #endregion

            #region 对象初始化器(Index Initializers)
            IDictionary<int, string> dictOld = new Dictionary<int, string>()
            {
                { 1,"first"},
                { 2,"second"}
            };

            IDictionary<int, string> dictNew = new Dictionary<int, string>()
            {
                [4] = "first",
                [5] = "second"
            };

            #endregion

            #region 异常过滤器(Exception filters)
            int exceptionValue = 10;
            try
            {
                Int32.Parse("s");
            }
            catch (Exception e) when (exceptionValue > 1)//满足条件才进入catch
            {
                Console.WriteLine("catch");
                //return;
            }
            #endregion

            #region nameof表达式 (nameof expressions)
            Console.WriteLine(nameof(peopleTest)); //获取peopleTest这个字符串
            #endregion

            #region 在cath和finally语句块里使用await(Await in catch and finally blocks)

            #endregion
        }

        #region 在属性/方法里使用Lambda表达式(Expression bodies on property-like function members)
        public string NameFormat => string.Format("姓名: {0}", "summit");
        public void Print() => Console.WriteLine(Name);
        #endregion

    }



    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static async Task Get()
        {
            await Task.Run(() =>
            {

                Thread.Sleep(5000);
                Console.WriteLine("People.async.Get");
            });
            Console.WriteLine("People.async.Get after");
        }
    }
}
