using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DBRelationShips
{
    public class MyCodeFistDBEntitis : DbContext
    {
        //在构造方法中读取链接字符串（首先在配置文件中，添加节点）
        public MyCodeFistDBEntitis() : base("name=efdbConnString")
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<MyCodeFistDBEntitis>());
            Database.SetInitializer(new MyStudentIntializer());//自定义策略
        }

        //添加Dbset对象
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCard> StudentCards { get; set; }



        //重写一个重要的方法
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////【1】修改表名
            //var entityConfig = modelBuilder.Entity<Student>();
            //entityConfig.ToTable("MyStudent");

            ////【3】Map函数：继续Map,将一个实体映射到两张表
            //entityConfig.Map<Student>(s =>
            //{
            //    s.Properties(c => new { c.Studentkey, c.StudentName });
            //    s.ToTable("MyStudent1");
            //}).Map<Student>(c =>
            //{
            //    c.Properties(p => new { p.Studentkey, p.StudentName });
            //    c.ToTable("MyStudent2");
            //});


            base.OnModelCreating(modelBuilder);
        }

        public class MyStudentIntializer : DropCreateDatabaseAlways<MyCodeFistDBEntitis>
        {
            public override void InitializeDatabase(MyCodeFistDBEntitis context)
            {
                base.InitializeDatabase(context);
            }
            //初始化一些数据    db.Students.Add(new Student { StudentName = "CodeFirst使用者", Gender = "男" });
            protected override void Seed(MyCodeFistDBEntitis context)
            {
                for (int i = 0; i < 20; i++)
                {
                    context.Students.Add(new Student
                    {
                        StudentName = "新学员" + i,
                        Gender = "男"
                    });
                }
                context.SaveChanges();
                base.Seed(context);
            }

        }
    }
}
