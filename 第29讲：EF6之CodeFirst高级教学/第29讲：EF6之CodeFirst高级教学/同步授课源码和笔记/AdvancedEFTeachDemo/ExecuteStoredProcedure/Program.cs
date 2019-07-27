using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddStudent();
            // UpdateStudent();
            //DeleteStudent();
            SelectStudent();
        }

        private static void AddStudent()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;
                db.Students.Add(new Students
                {
                    StudentName = "新添加的对象1",
                    Age = 20,
                    Birthday = Convert.ToDateTime("1998-01-01"),
                    ClassId = 2,
                    PhoneNumber = "13022202050",
                    StudentAddress = "天津",
                    Gender = "男",
                    StudentIdNo = 130229199801011220
                });

                int result = db.SaveChanges();
                Console.WriteLine(result);
                Console.Read();
            }
        }
        private static void UpdateStudent()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;
                Students student = db.Students.Where(s => s.StudentId.Equals(100024)).FirstOrDefault();
                student.StudentName = "修改后的对象1";

                int result = db.SaveChanges();
                Console.WriteLine(result);
                Console.Read();
            }
        }
        private static void DeleteStudent()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                Students student = new ExecuteStoredProcedure.Students { StudentId = 100024 };

                db.Students.Attach(student);
                db.Students.Remove(student);

                int result = db.SaveChanges();
                Console.WriteLine(result);
                Console.Read();
            }
        }

        private static void SelectStudent()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                var stuList = db.usp_selectStu(1).ToList();
                foreach (var item in stuList)
                {
                    Console.WriteLine($"{item.StudentName}\t{item.StudentId}\t{item.Gender}");
                }
                Console.Read();
            }
        }
    }
}
