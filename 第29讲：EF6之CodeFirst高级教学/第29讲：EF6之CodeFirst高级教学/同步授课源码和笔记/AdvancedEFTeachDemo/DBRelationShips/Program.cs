using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRelationShips
{
    class Program
    {
        //    static void Main(string[] args)
        //    {
        //        using (MyCodeFistDBEntitis db = new MyCodeFistDBEntitis())
        //        {
        //            db.Database.Log = Console.WriteLine;
        //            db.Students.Add(new Student { StudentName = "CodeFirst使用者", Gender = "男" });
        //            int result = db.SaveChanges();
        //            Console.WriteLine(result);
        //        }

        //        Console.Read();
        //    }

        static void Main(string[] args)
        {
            using (MyCodeFistDBEntitis db = new MyCodeFistDBEntitis())
            {
                db.Database.Log = Console.WriteLine;

                var student = db.Students.FirstOrDefault();
                student.StudentName = "修改后的姓名2";
                int result = db.SaveChanges();
                Console.WriteLine(result);
            }

            Console.Read();
        }
    }
}
