using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Students objStudent = new Students()
        //    {
        //        StudentAddress = "天津市南开区",
        //        StudentName = "小轩",
        //        Age = 20,
        //        Birthday = Convert.ToDateTime("1996-01-01"),
        //        ClassId = 2,
        //        Gender = "女",
        //        PhoneNumber = "022-99008877",
        //        StudentIdNo = 120223199601011213
        //    };

        //    EFDBEntities efdb = new EFDBEntities();
        //    efdb.Students.Add(objStudent);
        //    int result = efdb.SaveChanges();

        //    Console.WriteLine(result);
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    //创建数据库上下文对象
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students objStudent = efdb.Students.SingleOrDefault(s => s.StudentName == "冯小强");
        //    if (objStudent != null)
        //    {
        //        Console.WriteLine(objStudent.StudentName + "    " + objStudent.StudentId);
        //    }
        //    //使用where()方法查询符合条件的数据
        //    IQueryable<Students> query = efdb.Students.Where(s => s.StudentId > 100002);
        //    Console.WriteLine("学号\t姓名\t年龄");
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}", item.StudentId, item.StudentName, item.Age);
        //    }


        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    //创建数据库上下文对象
        //    EFDBEntities efdb = new EFDBEntities();

        //    //想修改对象，首先找到要修改的对象
        //    //  Students objStudent = efdb.Students.FirstOrDefault(s => s.StudentId == 1000006);

        //    Students objStudent = (from s in efdb.Students
        //                           where s.StudentId == 100006
        //                           select s).First<Students>();

        //    //在此修改各个属性值
        //    objStudent.StudentName = "张红利";
        //    objStudent.PhoneNumber = "99999999";

        //    //提交保存
        //    int result = efdb.SaveChanges();
        //    Console.WriteLine(result);

        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            //创建数据库上下文对象
            EFDBEntities efdb = new EFDBEntities();

            //首先找到要修改的对象
            Students objStudent = efdb.Students.FirstOrDefault(s => s.StudentId == 100015);

            efdb.Students.Remove(objStudent);//从集合中删除对象
            int result = efdb.SaveChanges();
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
