using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DBRelationShips
{
    public class MyCodeFistDBEntitis:DbContext
    {
        //在构造方法中读取链接字符串（首先在配置文件中，添加节点）
        public MyCodeFistDBEntitis() : base("name=efdbConnString") { }

        //添加Dbset对象
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCard> StudentCards { get; set; }



        //重写一个重要的方法
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
