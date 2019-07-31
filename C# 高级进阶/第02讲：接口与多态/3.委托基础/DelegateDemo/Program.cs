using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //【3】创建委托对象，关联具体方法
            CalculatorDelegate objCal = new CalculatorDelegate(Add);

            //【4】通过委托去调用方法，而不是直接使用方法
            //    int result = objCal(10, 20);

            //objCal -= Add;//断开委托对象和具体方法的关联
            objCal += Sub;

            int result = objCal(10, 20);


            Console.WriteLine("a+b=" + result);
            Console.ReadLine();
        }

        //【2】根据委托定义一个“具体方法”实现加法功能
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
    }

    //【1】声明委托（定义方法原型：返回值 + 参数类型和个数）
    public delegate int CalculatorDelegate(int a, int b);

}
