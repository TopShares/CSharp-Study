namespace Ruanmou.CoreDemo.DB
{
    using Microsoft.EntityFrameworkCore;
    public partial class EFDbContext : DbContext
    {
        //public EFDbContext()
        //    : base("name=EFDbContext")
        //{
        //}
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
             base.Database.EnsureCreated();
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMapping { get; set; }


    }
}
