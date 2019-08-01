using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLambda
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("{0} {1}跟着Eleven老师学习.net高级开发", this.Id, this.Name);
        }
    }

    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
