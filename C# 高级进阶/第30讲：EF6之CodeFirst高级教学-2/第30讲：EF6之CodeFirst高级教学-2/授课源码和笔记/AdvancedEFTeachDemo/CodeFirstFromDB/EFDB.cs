namespace CodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFDB : DbContext
    {
        public EFDB()
            : base("name=EFDB")
        {
        }

        public virtual DbSet<ScoreList> ScoreList { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCard> StudentCard { get; set; }
        public virtual DbSet<StudentClass> StudentClass { get; set; }
        public virtual DbSet<SysAdmin> SysAdmin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.StudentCard)
                .WithRequired(e => e.Student);

            modelBuilder.Entity<StudentCard>()
                .Property(e => e.CardType)
                .IsUnicode(false);

            modelBuilder.Entity<StudentClass>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<SysAdmin>()
                .Property(e => e.LoginPwd)
                .IsUnicode(false);

            modelBuilder.Entity<SysAdmin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);
        }
    }
}
