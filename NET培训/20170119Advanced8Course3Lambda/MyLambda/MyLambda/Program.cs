using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLambda.Extend;

namespace MyLambda
{
    /// <summary>
    /// 1 委托简介
    /// 2 匿名方法 匿名类 var
    /// 3 lambda表达式 goes to
    /// 4 系统自带委托Action/Func
    /// 5 扩展方法
    /// 6 linq扩展  
    /// 7 linq简单回顾
    /// 8 作业部署
    /// </summary>
    class Program
    {
        //private var name = "";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的lambda/linq课程");
                {
                    LambdaShow show = new LambdaShow();
                    show.Show();

                    show.NoShow();
                    show.ToDateTime(1);
                }
                #region MyRegion


                {
                    var model = new
                    {
                        Id = 1,
                        Name = "Alpha Go",
                        Age = 21,
                        ClassId = 2
                    };
                    Console.WriteLine(model.Id);
                    Console.WriteLine(model.Name);
                    //model.Name = "张伟东";

                    Student student = new Student()
                    {
                        Id = 1,
                        Name = "打兔子的猎人",
                        Age = 27,
                        ClassId = 2
                    };

                    var name = "";
                    Console.WriteLine(name);

                    //var id;
                }
                #endregion

                #region MyRegion


                {
                    int? ivalue = null;
                    int? ivalue2 = 1;

                    ivalue.ToDateTime(1);
                    ivalue2.ToDateTime(1);

                    int i = ExtendShow.ToInt(ivalue);


                    int i2 = ivalue.ToInt();

                    new Action(() => { }).Execute();
                }
                #endregion

                #region linq
                {
                    LinqShow show = new LinqShow();
                    show.Show();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
