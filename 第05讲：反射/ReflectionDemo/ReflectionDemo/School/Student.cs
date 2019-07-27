using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student : IQueryService
    {
        public Student() { Console.WriteLine("Student()：无参数构造方法被调用！"); }
        public Student(int stuId)
        {
            this.StudentId = stuId;
            Console.WriteLine("Student(int stuId)：1个参数构造方法被调用！");
        }
        public Student(int stuId,string stuName)
        {
            this.StudentId = stuId;
            this.StudentName = stuName;
            Console.WriteLine("Student(int stuId,string stuName)：2个参数构造方法被调用！");
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string GetEntityTypeById()
        {
            //根据ID从数据库中查询学员的类型...

            return ".Net高级进阶VIP学员";
        }
      
    }
}
