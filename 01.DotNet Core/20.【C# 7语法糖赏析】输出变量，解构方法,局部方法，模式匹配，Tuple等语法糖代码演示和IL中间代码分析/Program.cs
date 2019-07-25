using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string val = "10";

            ////int reuslt;

            ////int.TryParse(val, out reuslt);

            //int.TryParse(val, out int result);

            //Console.WriteLine(result);

            //var tuple = GetData();

            //Console.WriteLine(tuple.Item1 + " " + tuple.Item2);

            //var (isSuccess, Msg) = GetData2();

            //Console.WriteLine(isSuccess + " " + Msg);

            //var (Name, Age) = new Person("jack", 20);

            //Console.WriteLine(Name + "  " + Age);

            //Console.WriteLine(GetLength("hello world！"));

            //int GetLength(string str)
            //{
            //    return str.Length;
            //}

            var list = new List<object>() { 1, "2" };

            foreach (var item in list)
            {
                switch (item)
                {
                    ////如果当前item是 int类型，那么就执行我把。。。
                    //case int val:
                    //    Console.WriteLine(val);
                    //    break;

                    //如果当前是string，那么请抢我转成int把。
                    case string str when int.TryParse(str, out int ival):
                        Console.WriteLine(ival);
                        break;
                    default:
                        break;
                }
            }
        }


        public static Tuple<bool, string> GetData()
        {
            return Tuple.Create(true, "操作成功！");
        }

        public static ValueTuple<bool, string> GetData1()
        {
            return ValueTuple.Create(true, "操作成功！");
        }

        public static (bool, string) GetData2()
        {
            return (true, "操作成功！");
        }
    }

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Deconstruct(out string name, out int age)
        {
            name = this.name;
            age = this.age;
        }
    }
}
