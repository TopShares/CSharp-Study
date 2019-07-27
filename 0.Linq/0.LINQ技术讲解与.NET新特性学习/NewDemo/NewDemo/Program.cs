using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("---------------------自动属性初始化的测试--------------------");
            ////【1】自动属性初始化的测试
            //Student objStudent = new NewDemo.Student();
            //Console.WriteLine(objStudent.Name + "   " + objStudent.Age);

            //Console.WriteLine("------------------字符串格式化的新特性测试-----------------");
            ////【2】字符串格式化的新特性测试
            //NewFormat format = new NewFormat();
            //format.OldMethod();
            //Console.WriteLine("--------------------------------------------------------------------------");
            //format.NewMethod();


            //Console.WriteLine("--------------------表达式属性和表达式方法------------------");
            ////【3】表达式属性和表达式方法
            //ExpressionApp exp = new ExpressionApp();
            //Console.WriteLine(exp.Age );
            //Console.WriteLine(exp.Add(15,25));

            //Console.WriteLine("----------------泛型集合Dictionary初始化----------------");
            ////【4】泛型集合Dictionary初始化
            //NewCollectionInit collection = new NewCollectionInit();
            //Dictionary<string, int> student = collection.NewMethod();
            //foreach (string item in student.Keys)
            //{
            //    Console.WriteLine($"{item}--------{student[item]}");
            //}


            //Console.WriteLine("-----------------用static声明静态类的引用--------------");
            ////【5】用static声明静态类的引用        
            //int result = StaticClassApp.NewMethod2(-15, -30);
            //Console.WriteLine($"-15和-30的绝对值相加={result }");


            Console.WriteLine("-----------------------null条件表达式-------------------------");
            //【7】null条件表达式
            NullOperator no = new NullOperator();
            no.OldMethod();
            no.NewMethod();


            Console.ReadLine();
        }
    }
}
