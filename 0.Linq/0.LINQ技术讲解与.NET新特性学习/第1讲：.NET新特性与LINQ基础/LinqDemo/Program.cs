using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class Program
    {
        //示例1：使用var推断类型
        //static void Main(string[] args)
        //{
        //    var a = 20;
        //    var bookName = ".NET开发";
        //    var objStudent = new Student() { StudentName = "小张", Age = 22 };
        //    Console.WriteLine("共有{0} 个人在学习{1} 系列课程，其中{2} ,{3}岁,已经是高手了。",
        //        a, bookName, objStudent.StudentName, objStudent.Age);
        //    Console.ReadLine();
        //}

        //示例2：普通变量定义方法与var定义的比较
        //static void Main(string[] args)
        //{
        //    int a = 20;
        //    string bookName = ".NET开发";
        //    Student objStu = new Student() { StudentName = "小张", Age = 22 };
        //    Console.WriteLine("共有{0} 个人在学习{1} 系列课程，其中{2} ,{3}岁,已经是高手了。",
        //        a, bookName, objStu.StudentName, objStu.Age);
        //    Console.ReadLine();
        //}

        // 示例3：var与object的区别
        //static void Main(string[] args)
        //{
        //    object b = 20;
        //    b = ".NET开发";

        //    var a = 20;
        //    a = ".NET开发";       

        //   Console.ReadLine();
        //}

        //示例4：匿名类的使用
        //static void Main(string[] args)
        //{
        //    var objPerson = new
        //    {
        //        Name = "小王",
        //        Age = 25,
        //        ClassName = "软件1班"
        //    };
        //    Console.WriteLine("姓名：{0} 年龄：{1} 班级：{2}",
        //        objPerson.Name, objPerson.Age, objPerson.ClassName);
        //    Console.ReadLine();
        //}

        //var使用应注意的问题
        //static void Main(string[] args)
        //{
        //    var a=2008;
        //    var b =new int[] { 1, 2, 3 };          
        //    var e = "北京";
        //    Console.WriteLine("a={0} e={1}", a, e);
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    Console.Write("请输入您的姓名：");
        //    string stuName = Console.ReadLine();
        //    Console.WriteLine();
        //    Console.Write("请输入您的5门课程总成绩：");
        //    int sum = int.Parse(Console.ReadLine());
        //    Console.WriteLine();
        //    Console.WriteLine("{0}{1}", stuName.StuInfo(), sum.GetAvg());
        //    Console.ReadLine();
        //}
        //示例7：定义和使用带参数的扩展方法
        //static void Main(string[] args)
        //{
        //    Student objStudent = new Student() { StuName = "张晓丽" };
        //    string info = objStudent.ShowStuInfo(67, 89);
        //    Console.WriteLine(info);
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    int a;                 //定义变量
        //    a = 100;            //给变量赋值
        //    int b = a + 10;  //使用变量
        //}

        //示例8：委托的定义与使用
        //static void Main(string[] args)
        //{
        //    //【3】创建委托对象，关联“具体方法”
        //    CalculatorDelegate objCal = new CalculatorDelegate(Add);
        //    //【4】通过委托去调用方法，而不是直接使用方法
        //    int result = objCal(10, 20);
        //    Console.WriteLine("10+20={0}", result);

        //    objCal -= Add;  //断开当前委托对象所关联的方法（加法）
        //    objCal += Sub; //重新指向一个新的方法（减法）

        //    result = objCal(10, 20); //重新使用委托对象，完成减法功能
        //    Console.WriteLine("10-20={0}", result);
        //    Console.ReadLine();
        //}
        ////【2】根据委托定义一个“具体方法”实现加法功能
        //static int Add(int a, int b)
        //{
        //    return a + b;
        //}
        ////【2】根据委托定义一个“具体方法”实现减法功能
        //static int Sub(int a, int b)
        //{
        //    return a - b;
        //}

        //示例9：匿名方法的使用
        //static void Main(string[] args)
        //{
        //     //委托变量接收一个匿名方法
        //    CalculatorDelegate objCal = delegate(int a, int b)
        //    {
        //          return a + b;
        //    };
        //    int result = objCal(10, 20);
        //    Console.WriteLine("10+20={0}", result);
        //    Console.ReadLine();
        //}
        ////示例11：Lambda表达式的定义与使用
        //static void Main(string[] args)
        //{
        //    //委托变量接收一个Lambda表达式
        //    CalculatorDelegate objCal = (int a, int b) => { return a + b; };
        //    int result = objCal(10, 20);
        //    Console.WriteLine("10+20={0}", result);
        //    Console.ReadLine();
        //}
        //示例12：Lambda表达式的更多应用方法
        //static void Main(string[] args)
        //{
        //    MathDelegate objMath = a => a * a;
        //    int result = objMath(10);
        //    Console.WriteLine("a的平方={0}", result);
        //    Console.ReadLine();
        //}
    }
    public delegate int MathDelegate(int a);

    //【1】声明委托（定义一个函数的原型：返回值 + 参数类型和个数）
    public delegate int CalculatorDelegate(int a, int b);

}


