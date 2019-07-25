using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var student = new Student() { Name = "jack", Age = 20 };

            //var student = new Student();

            //student.Name = "jack";
            //student.Age = 20;

            var person = new { Name = "jack", Age = 20 };

            Action<int> Say = (i) => { };

            var person2 = new { Name = "jack", Age = 20,Say= Say};

        }
    }

    class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Student()
        {

        }

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public Student(string Name) : this(Name, default(int))
        {

        }


    }

}
