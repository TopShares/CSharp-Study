using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

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

        #region Linq to Object

        //Linq to 字符串
        //static void Main(string[] args)
        //{
        //    string strTest = "we are studying linq to object";
        //    //定义查询表达式
        //    var query = from c in strTest
        //                select c;
        //    //遍历查询结果并输出
        //    foreach (char ch in query)
        //    {
        //        Console.WriteLine(ch);
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
        //        Console.WriteLine( item.StudentName);
        //    }
        //    Console.ReadLine();
        //}

        //查询语句和查询方法对比
        //static void Main(string[] args)
        //{
        //    string strTest = "We are studying Linq To Object";

        //   //var query = from c in strTest 
        //   //            where char.IsUpper(c)
        //   //            select c;

        //    var query = strTest.Where(c => char.IsUpper(c));

        //    foreach (char ch in query)
        //    {
        //        Console.WriteLine(ch);
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
        //    var stuList = from stu in students
        //                  where stu.StudentName.StartsWith("张") && stu.Gender == "男"
        //                  orderby stu.Age ascending
        //                  select stu;
        //    //var stuList = students.Where(stu => stu.StudentName.StartsWith("张")
        //    //    && stu.Gender == "男")
        //    //    .OrderBy(stu => stu.Age);

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
        //    //获取集合中“第一个”对象
        //    Students objStudent = (from s in students select s).FirstOrDefault();
        //    //输出第一个对象张浩明
        //    Console.WriteLine(objStudent.StudentName);

        //    //删除一个对象
        //    students.Remove(objStudent);
        //    //获取集合中“唯一的”对象
        //    objStudent = (from s in students select s).SingleOrDefault();
        //    //输出唯一对象
        //    Console.WriteLine(objStudent.StudentName);
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

        //使用Find方法实现简单查询
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    Students objStudent = efdb.Students.Find(100005);

        //    Console.WriteLine(objStudent.StudentId + "\t" + 
        //        objStudent.StudentName + "\t" + objStudent.Age);
        //    Console.ReadKey();
        //}

        // 使用 “导航属性” 查询多表的数据
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var stuList = from s in efdb.Students
        //                  where s.Age > 22
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
        //    //查询班级编号为1的学员
        //    var query = from s in efdb.Students
        //                where s.ClassId == 1 || s.ClassId == 2
        //                select new { s.StudentClass.ClassName, s.StudentName, s.StudentId };
        //    //在上一个查询基础上查询年龄大于22的学员
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
        //        ClassId = (from c in efdb.StudentClass where c.ClassName.Equals("软件1班") select c.ClassId).SingleOrDefault(),
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

        //    //查询班级实体，然后使用导航数据添加数据
        //    (from c in efdb.StudentClass where c.ClassName.Equals("软件2班") select c).SingleOrDefault().Students.Add(stu);

        //    efdb.Students.Add(stu);  
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

        #region 状态跟踪与管理

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentId > 100002
        //                  select stu;
        //    string sql = stuList.ToString();
        //    Console.WriteLine(sql);
        //    Console.ReadLine();
        //}
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    int stuId = 100002;
        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentId > stuId
        //                  select stu;
        //    string sql = stuList.ToString();
        //    Console.WriteLine(sql);
        //    Console.ReadLine();
        //}
        //状态跟踪
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    StudentClass stuClass = new StudentClass() { ClassId = 10, ClassName = "软件10班" };
        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString());   //输出当前对象的状态

        //    efdb.StudentClass.Add(stuClass);
        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString());

        //    efdb.SaveChanges();
        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString());

        //    Console.ReadLine();
        //}

        //无状态跟踪
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    //状态跟踪查询
        //    var stu1 = (from s in efdb.Students select s).FirstOrDefault();
        //    Console.WriteLine(efdb.Entry(stu1).State.ToString());

        //    //无状态跟踪查询        
        //    var stu2 = efdb.Students.AsNoTracking().Select(s => s).FirstOrDefault();
        //    Console.WriteLine(efdb.Entry(stu2).State.ToString());
        //    Console.ReadLine();
        //}

        //关闭状态管理
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    efdb.Configuration.AutoDetectChangesEnabled = false;//禁用

        //    for (int i = 20; i < 25; i++)
        //    {
        //        StudentClass stuClass = new StudentClass() { ClassId = i, ClassName = string.Format("软件{0}班", i) };
        //        efdb.StudentClass.Add(stuClass);
        //    }
        //    Console.WriteLine(efdb.SaveChanges()); 

        //    Console.ReadLine();
        //}

        #endregion

        #region EF优化后： 基于Linq查询的CRUD

        //添加
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

        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        efdb.Entry<Students>(stu).State = EntityState.Added;//显示告诉变化
        //       // efdb.Students.Add(stu);
        //        Console.WriteLine(efdb.SaveChanges()); 
        //    }

        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "天津南开区狮子林大街29号",
        //        StudentName = "王超阳",
        //        StudentIdNo = 130223198911111219,
        //        ClassId = 1,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-11-19"),
        //        Age = 28,
        //        PhoneNumber = "022-5566888888"
        //    };



        //    Console.ReadLine();
        //}

        //修改
        //static void Main(string[] args)
        //{
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "2222",
        //        StudentName = "2222",
        //        StudentIdNo = 130223198910111222,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "88888888",
        //        StudentId = 100007//注意：这个应该改成你数据库的具体值
        //    };
        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        efdb.Entry<Students>(stu).State = EntityState.Modified;//显示告诉变化            
        //        Console.WriteLine(efdb.SaveChanges());
        //    }

        //    Console.ReadLine();
        //}

        //删除
        //static void Main(string[] args)
        //{
        //    Students stu = new Students()
        //    {
        //        StudentId = 100019 //根据主键删除
        //    };
        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        efdb.Set<Students>().Attach(stu);//将给定实体添加到上下文
        //        efdb.Entry<Students>(stu).State = EntityState.Deleted;
        //        Console.WriteLine(efdb.SaveChanges());
        //    };
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    Students stu = new Students()
        //    {
        //        StudentId = 100012 //根据主键删除
        //    };
        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        efdb.Set<Students>().Attach(stu);
        //        efdb.Students.Remove(stu);
        //        efdb.SaveChanges();
        //    };
        //    Console.ReadLine();
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
        //   Console.ReadLine();
        //}

        //使用缓存
        //static void Main(string[] args)
        //{
        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        var stuList = from stu in efdb.Students select stu;
        //        foreach (var item in stuList)
        //        {
        //            Console.WriteLine(item.StudentId + "\t" + item.StudentName);
        //        }

        //        //查询学生总数
        //       // Console.WriteLine("学生总数：{0}", efdb.Students.Count());

        //        //使用缓存查询学生总数
        //        Console.WriteLine("学生总数：{0}", efdb.Students.Local.Count());

        //        Console.ReadLine();
        //    }
        //}
        #endregion

        #region 从实体框架回归到SQL
        //static void Main(string[] args)
        //{
        //    string sql1 = "update Students set StudentName='张新宇' where StudentId=100002";
        //    string sql2 = "update Students set StudentName=@StudentName where StudentId=@StudentId";
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //         new SqlParameter("@StudentName","刘莉"),  new SqlParameter("@StudentId",100004)
        //    };

        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {
        //        int result1 = efdb.Database.ExecuteSqlCommand(sql1);
        //        int result2 = efdb.Database.ExecuteSqlCommand(sql2, param);
        //        Console.WriteLine(result1 + "    " + result2);
        //    }

        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    string sql1 = "select count(*) from Students";
        //    string sql2 = "select * from Students where Gender=@Gender";
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //         new SqlParameter("@Gender","男")
        //    };

        //    using (EFDBEntities efdb = new EFDBEntities())
        //    {

        //        int stuCount = efdb.Database.SqlQuery<int>(sql1).ToList()[0];
        //        var stuList = efdb.Database.SqlQuery<Students>(sql2, param);

        //        Console.WriteLine("学生总数：" + stuCount);
        //        foreach (var stu in stuList)
        //        {
        //            Console.WriteLine("{0}\t{1}\t{2}", stu.StudentId, stu.StudentName, stu.Age);
        //        }
        //    };
        //    Console.ReadLine();
        //}
        //调用存储过程
        static void Main(string[] args)
        {
            SqlParameter[] param1 = new SqlParameter[]
            {
                 new SqlParameter("@StudentName","王大彪"),  new SqlParameter("@StudentId",100004)
            };
            SqlParameter[] param2 = new SqlParameter[]
            {
                 new SqlParameter("@ClassId",1)
            };
            using (EFDBEntities efdb = new EFDBEntities())
            {
                int result = efdb.Database.ExecuteSqlCommand("execute usp_updateStu @StudentName,@StudentId", param1);
                var stuList = efdb.Database.SqlQuery<Students>("execute usp_selectStu @ClassId", param2);
                Console.WriteLine(result);
                foreach (var stu in stuList)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", stu.StudentId, stu.StudentName, stu.Age);
                }
            };

            Console.ReadLine();
        }
        #endregion
    }
}
