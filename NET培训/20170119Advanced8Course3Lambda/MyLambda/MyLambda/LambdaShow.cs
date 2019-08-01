using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLambda
{
    public delegate void NoReturnNoParaOutClass();
    public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, in T17>
    (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17);

    public class LambdaShow
    {
        public delegate void NoReturnNoPara();//1 委托的声明
        public delegate int WithReturnNoPara();
        public delegate void NoReturnWithPara(int id, string name);
        public delegate LambdaShow WithReturnWithPara(DateTime time);

        public void Show()
        {
            string nameOut = "糯米飞机";
            {
                Student student = new Student();
                student.Id = 1;
                student.Name = "打兔子的猎人";
                student.Age = 27;
                student.ClassId = 2;

                student.Study();
            }
            {
                Student student = new Student()
                {
                    Id = 1,
                    Name = "打兔子的猎人",
                    Age = 27,
                    ClassId = 2
                };
                student.Study();
            }
            {
                NoReturnWithPara method = new NoReturnWithPara(this.DoNothing);//2 委托的实例化
                method.Invoke(1, "Gain");//3 委托的调用
            }
            {
                NoReturnWithPara method = this.DoNothing;
                method.Invoke(2, "憨豆");
            }

            {
                NoReturnWithPara method = new NoReturnWithPara(
                    delegate(int id, string name)
                    {
                        Console.WriteLine(nameOut);
                        Console.WriteLine("{0} {1} DoNothing");
                    });
                method.Invoke(3, "yoyo");
            }
            {
                NoReturnWithPara method = new NoReturnWithPara(
                                  (int id, string name) =>//goes to
                                  //lambda表达式：是一个匿名方法，是一个方法
                                  {
                                      Console.WriteLine(nameOut);
                                      Console.WriteLine("{0} {1} DoNothing");
                                  });
                method.Invoke(4, "Nine");
            }
            {
                NoReturnWithPara method = new NoReturnWithPara(
                                     (id, name) =>
                                     //去掉参数类型，原因是委托的约束
                                     {
                                         Console.WriteLine("{0} {1} DoNothing");
                                     });
                method.Invoke(5, "小昶");
            }
            {
                //如果方法体只有一行，那么可以去掉大括号和分号,多行不行
                //如果参数只有一个  可以去掉小括号
                //如果没有参数，直接用小括号

                NoReturnWithPara method = new NoReturnWithPara((id, name) => Console.WriteLine("{0} {1} DoNothing", id, name));
                method.Invoke(6, "梦醒时分");
            }
            {
                NoReturnWithPara method = (id, name) => Console.WriteLine("{0} {1} DoNothing", id, name);
                method.Invoke(7, "小石头");
                method(8, "Y");
            }

            {
                //0到16个参数  无返回值的委托
                Action act1 = () => Console.WriteLine("1234");
                Action<int> act2 = t => { };
                Action<int, NoReturnWithPara, LambdaShow, LambdaShow, string, string, string, string, string, string, string, string, string, string, string, string> act3 = null;
                Action<int, NoReturnWithPara, NoReturnWithPara, LambdaShow, LambdaShow, string, string, string, string, string, string, string, string, string, string, string, string> act4 = null;
            }
            {
                //0到16个参数  带返回值的委托
                Func<int> func1 = () => 1;
                int i = func1();

                Func<int, string> func2 = t => "1234";
                Func<int, int, NoReturnWithPara, LambdaShow, LambdaShow, string, string, string, string, string, string, string, string, string, string, string, string> func3 = null;
            }
            {
                //多返回值：1 返回对象  2  ref out
                WithReturnWithParaRefOut method = new WithReturnWithParaRefOut(
                    delegate(ref DateTime time, out int i)
                    {
                        i = 1;
                        return this;
                    });//lambda表达式不行
            }
        }


        public delegate LambdaShow WithReturnWithParaRefOut(ref DateTime time, out int i);


        private void DoNothing(int id, string name)
        {
            Console.WriteLine("{0} {1} DoNothing out");
        }

        private void DoNothing1()
        {
            Console.WriteLine("DoNothing");
        }

        private void DoNothing2()
        {
            Console.WriteLine("DoNothing");
        }
    }
}
