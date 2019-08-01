namespace EF6Show.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
            : base("name=CodeFirst")//表示调用父类的构造函数 
        {

        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<JDCommodityFirst> JD_Commodity_001 { get; set; }
        public virtual DbSet<JDCommoditySecond> JD_Commodity_002 { get; set; }
        public virtual DbSet<JDCommodityThird> JD_Commodity_003 { get; set; }
        public virtual DbSet<JD_Commodity_004> JD_Commodity_004 { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EF6Show.CodeFirst.Mapping.JDCommoditySecondMapping());

            modelBuilder.Entity<JDCommodityThird>().ToTable("JD_Commodity_003");
            modelBuilder.Entity<JDCommodityThird>().Property(c => c.ClassId).HasColumnName("CategoryId");

            Database.SetInitializer<CodeFirstContext>(new DropCreateDatabaseAlways<CodeFirstContext>());
            //Database.SetInitializer<CodeFirstContext>(null);
        }
    }
}
