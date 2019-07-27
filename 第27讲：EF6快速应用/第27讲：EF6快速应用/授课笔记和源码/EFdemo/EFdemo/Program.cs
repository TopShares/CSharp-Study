using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFdemo
{
    class Program
    {
        #region 导航属性

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "北京001号",
        //        StudentName = "王某某",
        //        StudentIdNo = 130223198910121215,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-12"),
        //        Age = 25,
        //        PhoneNumber = "010-88996655",
        //        ClassId = (from c in efdb.StudentClass where c.ClassName == "软件1班" select c.ClassId).SingleOrDefault()
        //    };
        //    efdb.Students.Add(stu);
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();

        //}

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    Students stu = new Students()
        //    {
        //        StudentAddress = "北京002号",
        //        StudentName = "刘某某",
        //        StudentIdNo = 130223198910121216,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-12"),
        //        Age = 26,
        //        PhoneNumber = "010-88996655"

        //    };
        //    //var classObject = (from c in efdb.StudentClass where c.ClassName.Equals("软件2班") select c).SingleOrDefault();
        //    //classObject.Students.Add(stu);
        //    (from c in efdb.StudentClass where c.ClassName.Equals("软件2班") select c).SingleOrDefault().Students.Add(stu);

        //    efdb.Students.Add(stu);
        //    Console.WriteLine(efdb.SaveChanges());
        //    Console.ReadKey();

        //}

        #endregion

        #region SQL语句生成结果的观察

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();

        //    var stuList = from s in efdb.Students
        //                  where s.StudentId > 100005
        //                  select s;

        //    Console.WriteLine(stuList.Count());

        //    Console.ReadKey();

        //}

        ////观察SQL语句：第二种，查询条件，带着变量（变量将会变成参数）效率提高
        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    int stuId = 100002;

        //    var stuList = from stu in efdb.Students
        //                  where stu.StudentId > stuId
        //                  select stu;

        //    foreach (var item in stuList)
        //    {
        //        Console.WriteLine(item.StudentId);
        //    }

        //    Console.ReadLine();
        //}
        #endregion

        #region 一般的状态跟踪和查询

        //static void Main(string[] args)
        //{

        //    EFDBEntities efdb = new EFDBEntities();
        //    StudentClass stuClass = new StudentClass() { ClassId = 10, ClassName = "软件10班" };

        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString ());//输出当前的对象状态  Entry获取当前模型的状态

        //    efdb.StudentClass.Add(stuClass);
        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString());

        //    efdb.SaveChanges();
        //    Console.WriteLine(efdb.Entry(stuClass).State.ToString());

        //    Console.Read();
        //}

        ////状态跟踪和无状态跟踪
        //static void Main(string[] args)
        //{

        //    EFDBEntities efdb = new EFDBEntities();

        //    //状态跟踪查询的执行
        //    var stu1 = (from s in efdb.Students select s).FirstOrDefault();
        //    Console.WriteLine(efdb.Entry(stu1).State.ToString());

        //    //无状态的跟踪查询
        //    var stu2 = efdb.Students.AsNoTracking().Select(s => s).FirstOrDefault();
        //    Console.WriteLine(efdb.Entry(stu2).State.ToString());
        //    Console.Read();
        //}

        #endregion

        #region 批量操作中状态管理的重要性

        //static void Main(string[] args)
        //{
        //    EFDBEntities efdb = new EFDBEntities();
        //    efdb.Configuration.AutoDetectChangesEnabled = false;//禁止跟踪

        //    //观察时间
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //    sw.Start();

        //    for (int i = 11; i < 2011; i++)
        //    {
        //        StudentClass stuClass = new StudentClass() { ClassId = i, ClassName = $"软件{i}班" };
        //        efdb.StudentClass.Add(stuClass);
        //    }
        //    Console.WriteLine(efdb.SaveChanges());

        //    //展示一下时间
        //    sw.Stop();
        //    TimeSpan timeSpan = sw.Elapsed;
        //    Console.WriteLine($"第一次执行总耗时：{timeSpan.TotalMilliseconds}");

        //    efdb.Configuration.AutoDetectChangesEnabled = true;//开启跟踪
        //    sw.Start();
        //    for (int i = 2011; i < 4011; i++)
        //    {
        //        StudentClass stuClass = new StudentClass() { ClassId = i, ClassName = $"软件{i}班" };
        //        efdb.StudentClass.Add(stuClass);
        //    }
        //    Console.WriteLine(efdb.SaveChanges());

        //    //展示一下时间
        //    sw.Stop();
        //    timeSpan = sw.Elapsed;
        //    Console.WriteLine($"第二次执行总耗时：{timeSpan.TotalMilliseconds}");

        //    Console.Read();
        //}

        #endregion

        #region 添加对象的优化

        //static void Main(string[] args)
        //{
        //    Students stu1 = new Students()
        //    {
        //        StudentAddress = "天津001",
        //        StudentName = "赵某某2",
        //        StudentIdNo = 130223198910111222,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "022-55662820"
        //    };
        //    Students stu2 = new Students()
        //    {
        //        StudentAddress = "天津002",
        //        StudentName = "孙某某2",
        //        StudentIdNo = 130223198910111223,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "022-55662821"
        //    };

        //    //using (EFDBEntities efdb = new EFdemo.EFDBEntities())
        //    //{
        //    //    efdb.Entry(stu1).State = System.Data.Entity.EntityState.Added;//显示告知变化
        //    //    efdb.Entry(stu2).State = System.Data.Entity.EntityState.Added;//显示告知变化
        //    //    Console.WriteLine(efdb.SaveChanges());
        //    //}

        //    using (EFDBEntities efdb = new EFdemo.EFDBEntities())
        //    {              
        //        efdb.Students.Add(stu1);
        //        efdb.Students.Add(stu2);
        //        Console.WriteLine(efdb.SaveChanges());
        //    }

        //    Console.Read();

        //}

        #endregion

        #region 修改对象的优化

        //static void Main(string[] args)
        //{
        //    Students stu = new EFdemo.Students
        //    {
        //        StudentAddress = "2222",
        //        StudentName = "2222",
        //        StudentIdNo = 130223198910111228,
        //        ClassId = 2,
        //        Gender = "男",
        //        Birthday = Convert.ToDateTime("1990-10-11"),
        //        Age = 24,
        //        PhoneNumber = "88888888",
        //        StudentId = 100015
        //    };

        //    using (EFDBEntities efdb = new EFdemo.EFDBEntities())
        //    {
        //        efdb.Entry(stu).State = System.Data.Entity.EntityState.Modified;//表示修改的状态，这个不能省略
        //        Console.WriteLine(efdb.SaveChanges());
        //    }
        //    Console.Read();
        //}

        #endregion

        #region 删除对象的优化

        ////方法1
        //static void Main(string[] args)
        //{
        //    //将主键值封装到要删除的对象中
        //    Students stu = new Students { StudentId = 100014 };
        //    using (EFDBEntities efdb = new EFdemo.EFDBEntities())
        //    {
        //        efdb.Set<Students>().Attach(stu);
        //        efdb.Entry(stu).State = System.Data.Entity.EntityState.Deleted;

        //        Console.WriteLine(efdb.SaveChanges());
        //    }

        //    Console.Read();
        //}
        ////方法2
        //static void Main(string[] args)
        //{
        //    //将主键值封装到要删除的对象中
        //    Students stu = new Students { StudentId = 100014 };
        //    using (EFDBEntities efdb = new EFdemo.EFDBEntities())
        //    {
        //        efdb.Set<Students>().Attach(stu);//在使用下的Remove方法的时候，必须首先附加
        //        efdb.Students.Remove(stu);

        //        Console.WriteLine(efdb.SaveChanges());
        //    }

        //    Console.Read();
        //}

        #endregion

        #region 查询与缓存

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
        //    Console.ReadLine();
        //}

        //查询：使用本地缓存(如果两个查询有关联，请大家注意，缓存的使用)
        static void Main(string[] args)
        {
            using (EFDBEntities efdb = new EFDBEntities())
            {
                var stuList = from stu in efdb.Students select stu;
                foreach (var item in stuList)
                {
                    Console.WriteLine(item.StudentId + "\t" + item.StudentName);
                }

                //查询学生总数
                Console.WriteLine("学生总数：{0}", efdb.Students.Count());

                //使用缓存查询学生总数
                Console.WriteLine("学生总数：{0}", efdb.Students.Local.Count());

                Console.ReadLine();
            }
        }



        #endregion
        
    }
}
