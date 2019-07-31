using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectName.IBLL;
using ProjectName.BLL;
using ProjectName.Models;

namespace ProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentManager manager = new StudentManager();
            List<Student> list = manager.GetStudentByClass("软件2班");
            foreach (var item in list)
            {
                Console.WriteLine(item.StudentId + "\t" + item.StudentName);
            }
            Console.ReadLine();
        }
    }
}
