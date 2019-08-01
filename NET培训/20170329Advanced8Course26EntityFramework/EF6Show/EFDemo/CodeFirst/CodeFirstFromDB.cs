namespace EFDemo.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
            : base("name=CodeFirst")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Commodity001> Commodity001 { get; set; }
        public virtual DbSet<Commodity002> Commodity002 { get; set; }
        public virtual DbSet<Commodity003> Commodity003 { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CodeFirstContext>(new CreateDatabaseIfNotExists<CodeFirstContext>());
            //Database.SetInitializer<CodeFirstContext>(new DropCreateDatabaseAlways<CodeFirstContext>());
            //Database.SetInitializer<CodeFirstContext>();
            //null
            Database.SetInitializer<CodeFirstContext>(new DropCreateDatabaseIfModelChanges<CodeFirstContext>());//不检查实体变化

            modelBuilder.Configurations.Add(new Commodity002Mapping());


            modelBuilder.Entity<Category>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ParentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity001>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity001>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity002>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity002>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity003>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity003>().ToTable("JD_Commodity_003")
                .Property(c => c.ClassId).HasColumnName("CategoryId");

            modelBuilder.Entity<Commodity003>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
