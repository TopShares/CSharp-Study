namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<ScoreList> ScoreList { get; set; }
        public virtual DbSet<StudentClass> StudentClass { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>()
                .Property(e => e.LoginPwd)
                .IsUnicode(false);

            modelBuilder.Entity<Admins>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentClass>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentClass>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.StudentClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.StudentIdNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Students>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.StudentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.ScoreList)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);
        }
    }
}
