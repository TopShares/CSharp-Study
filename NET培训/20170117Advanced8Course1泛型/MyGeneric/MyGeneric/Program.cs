using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 1 引入泛型:延迟声明
    /// 2 如何声明和使用泛型
    /// 3 泛型的好处和原理
    /// 4 泛型类、泛型方法、泛型接口、泛型委托
    /// 5 泛型约束
    /// 6 协变 逆变(选修)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var list = new List<int>() { 1, 2, 3, 4 }
                //.Select(i => new
                //{
                //    id = i,
                //    name = "Test" + i
                //});
                //foreach (var item in list)
                //{
                //    Console.WriteLine(item.id);
                //    Console.WriteLine(item.name);
                //}

                //List<int>


                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师给大家带来的泛型Generic");
                int iValue = 123;
                string sValue = "456";
                DateTime dtValue = DateTime.Now;
                object oValue = new object();



                Console.WriteLine(typeof(List<int>));
                Console.WriteLine(typeof(Dictionary<int, string>));
                Console.WriteLine("**************************");
                CommonMethod.ShowInt(iValue);
                //CommonMethod.ShowInt(sValue);
                CommonMethod.ShowString(sValue);
                CommonMethod.ShowDateTime(dtValue);

                Console.WriteLine("**************************");
                CommonMethod.ShowObject(oValue);

                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(sValue);
                CommonMethod.ShowObject(dtValue);

                Console.WriteLine("**************************");
                GenericMethod.Show<object>(oValue);
                GenericMethod.Show<int>(iValue);
                GenericMethod.Show(iValue);//类型参数可以省略，由编译器推断出来
                //GenericMethod.Show<int>(sValue);//类型参数和参数必须匹配
                GenericMethod.Show<string>(sValue);
                GenericMethod.Show<DateTime>(dtValue);

                Console.WriteLine("**************************");
                People people = new People()
                {
                    Id = 11,
                    Name = "山冈"
                };
                Japanese japanese = new Japanese()
                {
                    Id = 112,
                    Name = "鬼子"
                };

                Chinese chinese = new Chinese()
                {
                    Id = 123,
                    Name = "口口"
                };
                Hubei hubei = new Hubei()
                {
                    Id = 123,
                    Name = "pig猪"
                };


                //Constraint.Show<People>(people);
                Constraint.Show<Chinese>(chinese);
                Constraint.Show<Hubei>(hubei);

                Constraint.ShowPeople(people);
                Constraint.ShowPeople(chinese);
                Constraint.ShowPeople(hubei);


                //Constraint.ShowInterface<People>(people);//没有实现ISports接口
                Constraint.ShowInterface<Chinese>(chinese);
                Constraint.ShowInterface<Hubei>(hubei);

                Constraint.ShowInterface<Japanese>(japanese);

                //Constraint.Show<Japanese>(japanese);//虽然Japanese有ID和Name，但是因为不是People，所以不能调用

                //Constraint.Show<int>(iValue);//约束后，只能按约束传递

                #region Monitor
                {
                    long commonTime = 0;
                    long objectTime = 0;
                    long genericTime = 0;
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        for (int i = 0; i < 1000000000; i++)
                        {
                            ShowCommon(iValue);
                        }
                        stopwatch.Stop();
                        commonTime = stopwatch.ElapsedMilliseconds;
                    }
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        for (int i = 0; i < 1000000000; i++)
                        {
                            ShowObject(iValue);
                        }
                        stopwatch.Stop();
                        objectTime = stopwatch.ElapsedMilliseconds;
                    }
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        for (int i = 0; i < 1000000000; i++)
                        {
                            ShowGeneric<int>(iValue);
                        }
                        stopwatch.Stop();
                        genericTime = stopwatch.ElapsedMilliseconds;
                    }
                    Console.WriteLine("commonTime = {0} objectTime = {1} genericTime = {2}", commonTime, objectTime, genericTime);
                }



                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private static void ShowCommon(int iParameter)
        { }
        private static void ShowObject(object oParameter)
        { }
        private static void ShowGeneric<T>(T tParameter)
        { }
    }
}
