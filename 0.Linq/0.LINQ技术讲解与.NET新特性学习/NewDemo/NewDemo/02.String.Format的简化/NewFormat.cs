using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    class NewFormat
    {
        //旧用法：string.Format("{0},{1}",变量1，变量2)实现格式化输出
        public void OldMethod()
        {
            Student objStudent = new NewDemo.Student();

            string s1 = string.Format("{0},{1}", objStudent.Name, objStudent.Age);
            string s2 = string.Format("姓名={0},年龄={1}", objStudent.Name, objStudent.Age);
            Console.WriteLine("{0},\r\n{1}", s1, s2);
            Console.WriteLine();

            string s3 = string.Format("{0,10},{1:d3}", objStudent.Name, objStudent.Age);
            string s4 = string.Format("{0,10},{1,10:d3}", objStudent.Name, objStudent.Age);
            Console.WriteLine("{0},\r\n{1}", s3, s4);
            Console.WriteLine();

            string s5 = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            Console.WriteLine(s5);
            Console.WriteLine();

            string sql = "select Name from Students where StudentId={0} and Age>{1}";
            Console.WriteLine(sql, objStudent.StudentId, objStudent.Age);

        }
        //新用法：在字符串前面添加“$”前缀，（变量可以直接写到{}内，并且有很强的智能提示）
        public void NewMethod()
        {
            Student objStudent = new NewDemo.Student();
            string s1 = $"{objStudent.Name },{objStudent.Age }";
            string s2 = $"姓名={objStudent.Name },年龄={objStudent.Age }";
            Console.WriteLine($"{ s1} ,\r\n{ s2} ");

            string s3 = $"{objStudent.Name,10},{objStudent.Age:d3}";
            string s4 = $"{objStudent.Name,10},{objStudent.Age,10:d3}";
            Console.WriteLine($"{ s3} ,\r\n{ s4} ");

            string s5 = $"{DateTime.Now:yyyy-MM-dd}";
            Console.WriteLine(s5);

            //典型应用
            string sql = $"select Name from Students where StudentId={objStudent.StudentId} and Age>{objStudent.Age }";
            Console.WriteLine( sql);
        }
    }
}
