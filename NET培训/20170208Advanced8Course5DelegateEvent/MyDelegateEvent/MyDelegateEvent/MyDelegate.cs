using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    public delegate void NoReturnNoParaOutClass();

    //public class DelegateClass : System.MulticastDelegate
    //{ }

    public class MyDelegate
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);//1 声明委托
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public delegate void NoReturnNoParaGeneric<T>();

        public void Show()
        {
            {
                NoReturnWithPara func = (x, y) => { };
                func += (x, y) => Console.WriteLine("123"); ;

                func.Invoke(3, 4);
            }



            //System.MulticastDelegate
            Student student = new Student()
            {
                Id = 96,
                Name = "Summer"
            };
            student.Study();

            //Predicate<int>

            //Func<string>

            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);//2 委托的实例化


                method.Invoke();//3 委托的调用
                method();

                //method.BeginInvoke(null, null);

                this.DoNothing();

            }

            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);//当前类的实例方法
                NoReturnNoPara method1 = new NoReturnNoPara(MyDelegate.DoNothingStatic);//当前类的静态方法
                NoReturnNoPara method2 = new NoReturnNoPara(student.Study);//其他类的实例方法
                NoReturnNoPara method3 = new NoReturnNoPara(Student.StudyAdvanced);//其他类的静态方法
            }

            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method += new NoReturnNoPara(this.DoNothing);
                method += new NoReturnNoPara(MyDelegate.DoNothingStatic);
                method += new NoReturnNoPara(student.Study);
                method += new NoReturnNoPara(Student.StudyAdvanced);

                method += new NoReturnNoPara(new Student().Study);
                method += new NoReturnNoPara(Student.StudyAdvanced);


                method += new NoReturnNoPara(() => Console.WriteLine("这里是lambda表达式"));
                //+=就是把多个方法按顺序排成列表，invoke时按顺序执行
                //method.Invoke();

                method -= new NoReturnNoPara(this.DoNothing);
                method -= new NoReturnNoPara(MyDelegate.DoNothingStatic);
                method -= new NoReturnNoPara(student.Study);

                method -= new NoReturnNoPara(new Student().Study);
                method -= new NoReturnNoPara(Student.StudyAdvanced);

                method -= new NoReturnNoPara(Student.StudyAdvanced);
                method -= new NoReturnNoPara(() => Console.WriteLine("这里是lambda表达式"));
                //-=就是从这个实例上，从后往前挨个匹配，找到第一个完全吻合的移除掉，且只移除一个，找不到不异常
                method.Invoke();


                //method.BeginInvoke(null, null);
                foreach (NoReturnNoPara item in method.GetInvocationList())
                {
                    item.BeginInvoke(null, null);
                }
            }



        }

        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        private static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }

    }
}
