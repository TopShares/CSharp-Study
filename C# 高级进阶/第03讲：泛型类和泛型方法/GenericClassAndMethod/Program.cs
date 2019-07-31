using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassAndMethod
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //【1】创建泛型类对象
        //    GenericStack<int> stack1 = new GenericStack<int>(5);
        //    //【2】入栈
        //    stack1.Push(1);
        //    stack1.Push(2);
        //    stack1.Push(3);
        //    stack1.Push(4);
        //    stack1.Push(5);
        //    //【3】出栈
        //    Console.WriteLine(stack1.Pop());
        //    Console.WriteLine(stack1.Pop());
        //    Console.WriteLine(stack1.Pop());
        //    Console.WriteLine(stack1.Pop());
        //    Console.WriteLine(stack1.Pop());

        //    GenericStack<string> stack2 = new GenericStack<string>(5);

        //    stack2.Push("课程1");
        //    stack2.Push("课程2");
        //    stack2.Push("课程3");
        //    stack2.Push("课程4");
        //    stack2.Push("课程5");

        //    Console.WriteLine(stack2.Pop());
        //    Console.WriteLine(stack2.Pop());
        //    Console.WriteLine(stack2.Pop());
        //    Console.WriteLine(stack2.Pop());
        //    Console.WriteLine(stack2.Pop());

        //    Console.Read();

        //}


        //static void Main(string[] args)
        //{
        //    //【1】实例化泛型类型对象
        //    GenericClass2<int, Course, Teacher> myClass2 = new GenericClass2<int, Course, Teacher>();

        //    //【2】给对象属性赋值
        //    myClass2.Publisher = new Teacher { Name = "常老师", Count = 20 };
        //    myClass2.ProductList = new List<Course>()
        //        {
        //            new Course (){ CourseName=".Net全栈开发VIP课程", Period=6},
        //            new Course (){ CourseName=".Net高级进阶VIP课程", Period=3},
        //            new Course (){ CourseName="ASP.NET开发VIP班", Period=3},
        //        };

        //    //【3】调用对象的方法
        //    Course myCourse = myClass2.BuyProduct(0);
        //    string info = $"我购买的课程名称是：{myCourse.CourseName}  学期：{myCourse.Period} 个月  课程主讲：{myClass2.Publisher.Name}";
        //    Console.WriteLine(info);
        //    Console.Read();

        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("20+30={0}", Add1(20, 30));

        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("10+20={0}", Add2(10, 20));
        //    Console.WriteLine("20.5+56.5={0}", Add2(20.5, 56.6));
        //    Console.WriteLine("20.5+56={0}", Add2(20.5, 56));

        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("20.5-56={0}", Sub(20.5, 56));

        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("20.5*5={0}", Multiply(20.5, 5));
        //    Console.WriteLine("20.5*5.1={0}", Multiply(20.5, 5.1));

        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("20.5/5={0}", Div(20.5, 5));
        //    Console.WriteLine("20/5={0}", Div(20, 5));
        //    Console.WriteLine("20.5/10.5={0}", Div(20.5, 10.5));
        //    Console.WriteLine("205/0.5={0}", Div(25, 0.5));

        //    Console.WriteLine("-------计算一个数的“求和”----------");
        //    Console.WriteLine(Sum(10));

        //    Console.Read();

        //}

        //实现四则混合运算《泛型方法》
        static T Add1<T>(T a, T b)
        {
            //  return a + b; //这种写法是错误的
            dynamic a1 = a;//动态类型仅在编译期间存在，运行期间会被object类型替代（编译的时候不考虑具体类型）
            dynamic b1 = b;
            return a1 + b1;
        }

        static T Add2<T>(T a, T b) where T : struct
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 + b1;
        }

        static T Sub<T>(T a, T b) where T : struct
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 - b1;
        }

        static T Multiply<T>(T a, T b) where T : struct
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 * b1;
        }
        static T Div<T>(T a, T b) where T : struct
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 / b1;
        }


        //实现一个数求和（1000）
        //private static int Sum(int a)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < a; i++)
        //    {
        //        sum += i;
        //    }
        //    return sum;
        //}

        private static T Sum<T>(T a) where T : struct
        {
            T sum = default(T);
            for (dynamic i = 0; i <= a; i++)
            {
                sum += i;
            }
            return sum;
        }


        static void Main(string[] args)
        {
            //使用委托
            MyGenericDelegate<int> mydelegate1 = Add;
            MyGenericDelegate<double > mydelegate2 = Sub;

            Console.WriteLine(mydelegate1(10, 20));
            Console.WriteLine(mydelegate2(10.5, 20.6));

            Console.Read();
        }


        static int Add(int a, int b)
        {
            return a + b;
        }
        static double Sub(double a, double b)
        {
            return a - b;
        }
    }

    //定义委托
  //  public delegate int MyDelegate(int a, int b);

    //定义泛型委托
    public delegate T MyGenericDelegate<T>(T a, T b);

}
