using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;

namespace EFAdvanceTeach
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTransaction1();
            // TestTransaction2();
            //TestCustomTransaction1();
            // TestCustomTransaction2();

            //LazyLoad();

            // CloaseLazyLoad();

            // ExplicitLoading();

            //  EagerLoad();

            TestLinq1();
        }

        #region EF中的事务

        //【1】在增删改中默认开启事务
        private static void TestTransaction1()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                //我们可以通过log接口来随时查看日志信息，它在DataBase里面
                db.Database.Log = Console.WriteLine;

                db.StudentClass.Add(new StudentClass { ClassId = 30, ClassName = ".NET高级学习班1" });
                db.StudentClass.Add(new StudentClass { ClassId = 31, ClassName = ".NET高级学习班2" });

                db.SaveChanges();
                Console.Read();
            }
        }
        //【2】在查询中是没有事务的
        private static void TestTransaction2()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                //我们可以通过log接口来随时查看日志信息，它在DataBase里面
                db.Database.Log = Console.WriteLine;

                db.StudentClass.FirstOrDefault();

                db.SaveChanges();
                Console.Read();
            }
        }

        //【3】其实，我们应该自己能够创建和控制事务的执行：就是自定义事务。
        //自定义事务可以在某些时候改变事务的隔离级别
        //默认：Read Commit （提交读） 我们可以改成未提交读（未提交读，可能产生脏数据）
        //脏数据：当一个事务在访问数据的时候，并且对这个数据做了修改，但是这个修改没有正式提交，
        //这时候，另外一个事务也在访问这个数据，然后使用了这个数据。这时候脏数据就产生。

        //select * from students with(nolock) ...这种情况是有脏数据的可能。
        //set transaction isolation level read committed //如果数据中有Share锁 ，同时记录中有排他性，会编程IS锁
        //结果：如果一个记录上有S锁，那么执行insert的时候是无法完成的，因为insert会加上排他锁。
        //如果加上nolock,这时候，我们执行的insert、update、等不会被影响。这种做法可以在高并发的情况下考虑。

        //实现自定义的事务1
        private static void TestCustomTransaction1()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                using (var cusTransaction = db.Database.BeginTransaction
                    (System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        db.Database.Log = Console.WriteLine;
                        //我们可以在这个地方添加需要的增删改操作...

                        db.StudentClass.Add(new StudentClass { ClassId = 35, ClassName = ".NET高级学习班5" });
                        db.StudentClass.Add(new StudentClass { ClassId = 36, ClassName = ".NET高级学习班6" });

                        db.SaveChanges();

                        cusTransaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        cusTransaction.Rollback();
                        throw ex;
                    }
                }
            }
            Console.Read();
        }

        //实现自定义的事务2
        private static void TestCustomTransaction2()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                using (var cusTransaction = new TransactionScope())
                {
                    try
                    {
                        db.Database.Log = Console.WriteLine;
                        //我们可以在这个地方添加需要的增删改操作...

                        db.StudentClass.Add(new StudentClass { ClassId = 45, ClassName = ".NET高级学习班11" });
                        db.StudentClass.Add(new StudentClass { ClassId = 46, ClassName = ".NET高级学习班10" });

                        db.SaveChanges();

                        cusTransaction.Complete();

                    }
                    catch (Exception ex)
                    {
                        Transaction.Current.Rollback();
                        throw ex;
                    }
                }
            }
            Console.Read();
        }

        #endregion

        #region DbContext中的三种加载模式研究：LazyLoad（延迟加载）、ExplictLoading（显示加载）、EagerLoad（立即加载）

        //【1】延迟加载：我们通过观察实体对象，发现他们之间会根据主外建生成导航属性。当我们查询实体的时候，如果有导航的外键对象
        //那么，我们在需要的时候，就可以加载。一定程度上，会增加数据库的压力。
        //观察：当我们获取Student对象的时候，StudentClass是否被同时加载？
        private static void LazyLoad()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                var student = db.Students.FirstOrDefault();//如果我们在这个地方打断点，然后观察关联对象，则可以看到二次查询出现

                //也可以直接输出
                var className = student.StudentClass.ClassName;

                Console.Read();
            }
        }

        //关闭延迟加载
        private static void CloaseLazyLoad()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                //关闭延迟加载
                db.Configuration.LazyLoadingEnabled = false;

                var student = db.Students.FirstOrDefault();//如果我们在这个地方打断点，然后观察关联对象，则可以看到二次查询出现

                //以下就会出错
                var className = student.StudentClass.ClassName;

            }
            Console.Read();
        }

        //【2】显示加载(就是我们关闭延迟加载后，如果需要再次加载，可以使用)
        private static void ExplicitLoading()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                //关闭延迟加载
                db.Configuration.LazyLoadingEnabled = false;

                var student = db.Students.FirstOrDefault();

                //对于已经关闭的延迟加载，我们可以再次手动开启
                db.Entry(student).Reference(s => s.StudentClass).Load();

                //以下就会出错
                var className = student.StudentClass.ClassName;
            }

            Console.Read();

        }
        //【3】立即加载：当我们获取一个实体对象的时候，与之关联的其他外键对象会被立即加载。
        private static void EagerLoad()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                db.Database.Log = Console.WriteLine;

                //关闭延迟加载
                db.Configuration.LazyLoadingEnabled = false;

                //注意：使用Include时，生成的SQL语句和前面是不一样的，使用后会立即加载，数据会一次查询出来，不会再单独生成其他的查询SQL语句
                //  var student = db.Students.Include("StudentClass").ToList();

                //还可以实现链式查询，生成更复杂的SQL语句，其实就是join查询
                var result = db.Students.Include("StudentClass").Include("ScoreList").ToList();

            }

            Console.Read();
        }

        #endregion

        //如果你的LINQ查询基础不行，请抓紧复习

        //LINQ查询我在这个课程中，要求大家把常见的14中关键词法都要掌握（MSDN上面例子可以直接参考）
        //必须把握基本框架：from 范围变量 in 对象集合或实体集合 

        //其他的请学员自己务必学习...

        //let关键词：查询中的临时变量
        private static void TestLinq1()
        {
            using (EFDBEntities db = new EFDBEntities())
            {
                var result = from s in db.Students
                             let nameLength = s.StudentName.Length
                             select new { nlen = nameLength, s };

                var list = result.ToList();
            }

            Console.Read();

        }

    }
}

