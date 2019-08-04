using DecoratorPattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是设计模式的学习");
                AbstractStudent student = new StudentVip()
                {
                    Id = 381,
                    Name = "秋叶"
                };
                //student.Show();

                //int i = 0;
                //i = 1;
                //AbstractStudent student2 = new BaseStudentDecorator(student);
                //student2.Show();

                student = new BaseStudentDecorator(student);//覆盖了
                //student.Show();

                //AbstractStudent student3 = new StudentCoreDecorator(student);
                //student3.Show();

                student = new StudentPayDecorator(student);

                student = new StudentCoreDecorator(student);
                student = new StudentFrameworkDecorator(student);
                student = new StudentProjectDecorator(student);
                student = new StudentDesignDecorator(student);

                //student = new StudentPayDecorator(student);

                student.Show();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
