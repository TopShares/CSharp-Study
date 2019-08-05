using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFistDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDB efdb = new EFDB();
            efdb.Teachers.Add(new Teacher
            {
                TeacherId = 1000,
                TeacherName = "Toke",
                Salary = "20000"
            });
            int result = efdb.SaveChanges();
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
