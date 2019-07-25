using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Data;

namespace EFDBDemo
{
    class Program
    {
        #region EF的基本使用
        //查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students objStudent = efdb.Students.SingleOrDefault(s => s.StudentName == "冯小强");
        //    if (objStudent != null)
        //    {
        //        Console.WriteLine(objStudent.StudentId + " " + objStudent.StudentName);
        //    }
        //    //用where()方法查询符合条件的数据
        //    IQueryable<Students> query = efdb.Students.Where(s => s.StudentId > 100002);
        //    Console.WriteLine("学号\t姓名\t年龄");
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}", item.StudentId, item.StudentName, item.Age);
        //    }
        //    Console.ReadKey();
        //}

        //添加
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    efdb.Students.Add(new Students()
        //        {
        //            StudentAddress = "北京海淀区28号",
        //            StudentName = "白富美",
        //            StudentIdNo = 130223199210111213,
        //            ClassId = 1,
        //            Gender = "女",
        //            Birthday = Convert.ToDateTime("1992-10-11"),
        //            Age = 24,
        //            PhoneNumber = "010-55662233"
        //        });
        //    int result = efdb.SaveChanges();
        //    if (result == 1)
        //        Console.WriteLine("添加成功！");
        //    Console.ReadKey();
        //}
        //修改
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    Students objStudent = efdb.Students.FirstOrDefault(s => s.StudentId == 100006);
        //    objStudent.StudentAddress = "北京昭阳区";
        //    objStudent.PhoneNumber = "13600000000";            
        //    int result = efdb.SaveChanges();

        //    if (result == 1)
        //        Console.WriteLine("修改成功！");
        //    Console.ReadKey();
        //}
        //删除
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    Students objStudent = efdb.Students.FirstOrDefault(s => s.StudentId == 100010);
        //    efdb.Students.Remove(objStudent);//从集合中删除学员对象
        //    int result = efdb.SaveChanges();

        //    if (result == 1)
        //        Console.WriteLine("删除成功！");
        //    Console.ReadKey();
        //}

        #endregion

        #region 基于Linq查询的CRUD

        ////添加
        //static void Main(string[] args)
        //{           
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "天津南开区狮子林大街28号",
        //        StudentName = "李超阳",
        //        StudentIdNo = 130223198910111213,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "022-55662232"
        //    };
        //    EFDBEntities efdb = new EFDBEntities();
        //    efdb.Entry<Students>(stu).State = EntityState.Added;
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();
        //}

        ////修改
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "2222",
        //        StudentName = "2222",
        //        StudentIdNo = 130223198910111222,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "55555555",
        //        StudentId = 100007//注意：这个应该改成你数据库的具体值
        //    };
        //    efdb.Set<Students>().Attach(stu);
        //    efdb.Entry<Students>(stu).State = EntityState.Modified;
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();
        //}

        ////删除
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students stu = new Students()
        //    {
        //        StudentId = 100010
        //    };
        //    efdb.Set<Students>().Attach(stu);
        //    efdb.Entry<Students>(stu).State = EntityState.Deleted;
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();
        //}

        ////查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentId > 100002
        //                  select stu;

        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId + "\t" + item.StudentName);
        //    }
        //    Console.ReadKey();
        //}
        #endregion

        #region Linq to Object

        //Linq to 字符串
        //static void Main(string[] args)
        //{
        //    string strTest = "we are studying linq to object";
        //    var query = from c in strTest
        //                select c;
        //    foreach (var c in query)
        //    {
        //        Console.WriteLine(c);
        //    }


        //    Console.ReadLine();
        //}      

        //Linq to List<T>
        //static void Main(string[] args)
        //{
        //    List<Students> students = new List<Students>
        //    { 
        //         new Students(){ StudentName="张浩明",Gender="男",Birthday=DateTime.Parse("1990-09-10")},
        //         new Students(){ StudentName="李晓燕",Gender="女",Birthday=DateTime.Parse("1992-03-12")},
        //         new Students(){ StudentName="郝云霄",Gender="女",Birthday=DateTime.Parse("1991-09-15") }
        //    };
        //    var stuList = from s in students where s.Gender == "女" select s;
        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentName);
        //    }

        //    Console.ReadLine();
        //}

        //查询语句和查询方法对比
        //static void Main(string[] args)
        //{
        //    string strTest = "We are studying Linq To Object";

        //    //var query = from c in strTest
        //    //            where char.IsUpper(c)
        //    //            select c;

        //    var query = strTest.Where(c => char.IsUpper(c));
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item);
        //    }


        //    Console.ReadLine();
        //}
        //static void Main(string[] args)
        //{
        //    List<Students> students = new List<Students>
        //        { 
        //             new Students(){ StudentName="张浩明",Gender="男",Age=21},
        //             new Students(){ StudentName="李晓燕",Gender="女",Age=23},
        //             new Students(){ StudentName="张云霄",Gender="男",Age=20}
        //        };
        //    //查询姓张的男学生，并且按年龄升序排列
        //    //var stuList = from stu in students
        //    //              where stu.StudentName.StartsWith("张") && stu.Gender == "男"
        //    //              orderby stu.Age ascending
        //    //              select stu;

        //    var stuList = students
        //        .Where(stu => stu.StudentName.StartsWith("张") & stu.Gender.Equals("男"))
        //        .OrderBy(stu => stu.Age);

        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentName + "\t" + item.Age);
        //    }


        //    Console.ReadKey();
        //}
        //查询方法和查询语句综合使用
        //static void Main(string[] args)
        //{
        //    List<Students> students = new List<Students>
        //    { 
        //         new Students(){ StudentName="张浩明",Gender="男",Birthday=DateTime.Parse("1990-09-10")},
        //         new Students(){ StudentName="李晓燕",Gender="女",Birthday=DateTime.Parse("1992-03-12")}//,
        //        // new Students(){ StudentName="郝云霄",Gender="女",Birthday=DateTime.Parse("1991-09-15") }
        //    };

        //    Console.ReadLine();
        //}

        #endregion

        #region 使用Linq to Entities查询数据

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    var query = from s in efdb.Students
        //                where s.StudentId == 100002
        //                select s;
        //    Console.WriteLine("学号\t姓名\t年龄");
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}", item.StudentId, item.StudentName, item.Age);
        //    }
        //    Console.ReadKey();
        //}

        //从Linq to Objects 到 Linq to Entitis
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    //查询姓张的男学生，并且按年龄升序排列
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentName.StartsWith("张") && stu.Gender == "男"
        //                  && stu.Birthday > Convert.ToDateTime("1990-01-01")
        //                  orderby stu.Age ascending
        //                  select stu;
        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId + "\t" + item.StudentName + "\t" + item.Age);
        //    }
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    DateTime birthday = Convert.ToDateTime("1990-01-01");
        //    //查询姓张的男学生，并且按年龄升序排列
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentName.StartsWith("张") && stu.Gender == "男"
        //                  && stu.Birthday > birthday
        //                  orderby stu.Age ascending
        //                  select stu;
        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId + "\t" + item.StudentName + "\t" + item.Age);
        //    }
        //    Console.ReadKey();
        //}

        //单表查询和数据投影
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentName.Contains("小")
        //                  orderby stu.Age descending
        //                  select new { stu.StudentId, stu.StudentName, stu.StudentIdNo, stu.Gender, stu.Age };


        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId + "\t" + item.StudentName + "\t" + item.Age);
        //    }
        //    Console.ReadKey();
        //}

        // 使用Find方法实现简单查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    Students objStudent = efdb.Students.Find(100005);

        //    Console.WriteLine(objStudent.StudentId + "\t" +
        //        objStudent.StudentName + "\t" + objStudent.Age);
        //    Console.ReadKey();
        //}

        //  使用 “导航属性” 查询多表的数据
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var stuList = from s in efdb.Students
        //                 where s.Age > 22
        //                  select new { s.StudentName, s.Age, s.StudentClass.ClassName };


        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentName + "\t" + item.Age + "\t" + item.ClassName);
        //    }
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var stuList = from score in efdb.ScoreList
        //                  select new
        //                  {
        //                      score.StudentId,
        //                      score.SQLServerDB,
        //                      score.Students.StudentName,
        //                      score.Students.StudentClass.ClassName
        //                  };

        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
        //           item.StudentId, item.StudentName, item.SQLServerDB,
        //           item.ClassName);
        //    }
        //    Console.ReadKey();
        //}

        //join联接查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var stuList = from score in efdb.ScoreList
        //                  join s in efdb.Students on score.StudentId equals s.StudentId
        //                  join c in efdb.StudentClass on s.ClassId equals c.ClassId
        //                  where s.Gender == "男"
        //                  select new { s.StudentId, s.StudentName, score.SQLServerDB, c.ClassName };


        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
        //            item.StudentId,
        //            item.StudentName,
        //            item.SQLServerDB,
        //            item.ClassName);
        //    }
        //    Console.ReadKey();
        //}

        //嵌套查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    //查询班级编号为1或者为2的学员
        //    var query = from s in efdb.Students
        //                where s.ClassId == 1 || s.ClassId == 2
        //                select new { s.StudentClass.ClassName, s.StudentName, s.StudentId };

        //    //在上一个查询基础上查询学号大于100002的学员
        //    var subQuery = from s in (query) where s.StudentId > 100002 select s;

        //    //执行查询
        //    var stuList = subQuery.ToList();

        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}",
        //            item.StudentId,
        //            item.StudentName,
        //            item.ClassName);
        //    }
        //    Console.ReadKey();
        //}
        //子查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    //使用子查询
        //    var subQuery = from s in
        //                       (from s in efdb.Students
        //                        where s.ClassId == 1 || s.ClassId == 2
        //                        select new { s.StudentClass.ClassName, s.StudentName, s.StudentId })
        //                   where s.StudentId > 100002
        //                   select s;

        //    foreach (var item in subQuery)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}",
        //            item.StudentId,
        //            item.StudentName,
        //            item.ClassName);
        //    }
        //    Console.ReadKey();
        //}

        //在select子句中使用子查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var query = from s in efdb.Students
        //                select new
        //                {
        //                    Name = s.StudentName,
        //                    Subject = from score in s.ScoreList
        //                              select new { sql = score.SQLServerDB, cs = score.CSharp }
        //                };

        //    //执行查询
        //    var stuList = query.ToList();

        //    foreach (var item in stuList)
        //    {
        //        Console.Write(item.Name);
        //        foreach (var s in item.Subject)
        //        {
        //            Console.Write("\t{0},{1}", s.sql, s.cs);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.ReadKey();
        //}

        //聚合查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    //计算所有的学生总数
        //    var query = from s in efdb.Students select s;
        //    int stuCount = query.Count();
        //    Console.WriteLine("学生总数：" + stuCount);

        //    //计算参考考试的学生考试总分
        //    var scoreQuery = from s in efdb.Students
        //                     where s.ScoreList.Count() > 0//参加考试的学生
        //                     select new
        //                     {
        //                         Name = s.StudentName,
        //                         Total = (from score in s.ScoreList                                     
        //                                  select (score .SQLServerDB+score .CSharp )).Sum()                                
        //                     };

        //    foreach (var item in scoreQuery)
        //    {
        //        Console.WriteLine("{0}\t{1}", item.Name, item.Total);
        //    }
        //    Console.ReadKey();
        //}
        #endregion

        #region 处理关联数据

        ////添加对象的同时关联实体操作
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "北京海淀区",
        //        StudentName = "王慧慧",
        //        StudentIdNo = 130223198910121213,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-12"),
        //        Age = 25,
        //        PhoneNumber = "010-88996655",
        //        ClassId = (from c in efdb.StudentClass where c.ClassName.Equals("软件1班") select c.ClassId).SingleOrDefault()
        //    };
        //    efdb.Students.Add(stu);
        //    Console.WriteLine(efdb.SaveChanges());

        //    Console.ReadKey();
        //}

        //通过嵌套查询获取外键对象的值
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    Students stu = new Students()
        //    {
        //        StudentAddress = "北京海淀区",
        //        StudentName = "李慧慧",
        //        StudentIdNo = 130223198910131213,
        //        Gender = "女",
        //        Birthday = Convert.ToDateTime("1990-10-13"),
        //        Age = 26,
        //        PhoneNumber = "010-88996699"
        //    };
        //    //查询班级实体，然后通过使用导航添加数据
        //    (from c in efdb.StudentClass where c.ClassName.Equals("软件2班") select c).SingleOrDefault().Students.Add(stu);

        //    Console.WriteLine(efdb.SaveChanges());

        //    Console.ReadKey();
        //}



        //级联删除
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    //找到软件2班
        //    var stuClass = (from c in efdb.StudentClass where c.ClassId == 2 select c).SingleOrDefault();

        //    //删除软件2班的学生
        //    for (int i = 0; i < stuClass.Students.Count; i++)
        //    {
        //        efdb.Students.Remove(stuClass.Students.FirstOrDefault());
        //    }
        //    //删除软件2班
        //    efdb.StudentClass.Remove(stuClass);
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();

        //    //efdb.Set<Students>().Attach(stu);
        //    //  efdb.Entry<Students>(stu).State = EntityState.Deleted;


        //}


        #endregion


    }
}
