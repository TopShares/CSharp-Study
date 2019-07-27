using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo2
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //创建上下文对象
        //    EFDBEntities efdb = new EFDBEntities();
        //    efdb.Students.Add(new Students
        //    {
        //        StudentAddress = "北京海淀区28号",
        //        StudentName = "白富美",
        //        StudentIdNo = 130223199210111213,
        //        ClassId = 1,
        //        Gender = "女",
        //        Birthday = Convert.ToDateTime("1992-10-11"),
        //        Age = 24,
        //        PhoneNumber = "010-55662233"
        //    });
        //    int result = efdb.SaveChanges();
        //    Console.WriteLine(result);
        //    Console.Read();
        //}

        static void Main(string[] args)
        {
            //创建上下文对象
            EFDBEntities efdb = new EFDBEntities();

            var stuList1 = efdb.Students.Where(s => s.Age > 18);

            var stuList2 = stuList1.Where(s => s.Gender.Equals("男"));

            foreach (var item in stuList2)
            {
                Console.WriteLine(item.StudentName);
            }

            var stuList3 = efdb.Students.ToList();
            Console.WriteLine(stuList3.Count .ToString ());

            Console.Read();
        }
    }
}
