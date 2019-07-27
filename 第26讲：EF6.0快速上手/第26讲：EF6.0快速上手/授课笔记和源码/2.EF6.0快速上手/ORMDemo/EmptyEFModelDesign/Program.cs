using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyEFModelDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDBContainer efdb = new EmptyEFModelDesign.EFDBContainer();
            efdb.Teacher.Add(new Teacher
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
