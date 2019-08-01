using MyAbstract.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract
{
    /// <summary>
    /// 1 作业讲解
    /// 2 封装继承多态
    /// 3 抽象类接口
    /// 4 重写overwrite(new)  覆写override 重载overload(方法) 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的接口抽象类课程");
                Student student = new Student()
                {
                    Id = 423,
                    Name = "假洒脱"
                };
                {
                    BasePhone phone = new Lumia();
                    //student.PlayLumia(phone);
                    student.PlayPhone(phone);
                }
                {
                    //BasePhone phone = new BasePhone();
                    //BasePhone phone = new Lumia();
                    //phone.Metro();

                    IExtend phone = new iPhone();
                    //IExtend phone = new IExtend();
                    //phone.Call();
                }
                {
                    BasePhone phone = new iPhone();
                    phone.Call();
                    //student.PlayIPhone(phone);
                    student.PlayPhone(phone);
                }
                Polymorphism.Poly.Test();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
