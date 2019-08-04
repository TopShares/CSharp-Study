using Ruanmou.Bussiness.Interface;
using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Service
{
    //public class CommodityCategoryService : BaseService, IUserMenuService
    //{
    //    #region Identity
    //    //操作基于这些完成
    //    private DbSet<User> _UserDbSet = null;
    //    private DbSet<Menu> _MenuDbSet = null;
    //    private DbSet<UserMenuMapping> _MappingDbSet = null;
    //    public CommodityCategoryService(DbContext dbContext)
    //        : base(dbContext)
    //    {
    //        this._MappingDbSet = dbContext.Set<UserMenuMapping>();
    //        this._UserDbSet = dbContext.Set<User>();
    //        this._MenuDbSet = dbContext.Set<Menu>();
    //    }
    //    #endregion Identity
    //}

    public class UserMenuService : BaseService, IUserMenuService
    {
        #region Identity
        //操作基于这些完成
        private DbSet<User> _UserDbSet = null;
        private DbSet<Menu> _MenuDbSet = null;
        private DbSet<UserMenuMapping> _MappingDbSet = null;
        public UserMenuService(DbContext dbContext)
            : base(dbContext)
        {
            this._MappingDbSet = dbContext.Set<UserMenuMapping>();
            this._UserDbSet = dbContext.Set<User>();
            this._MenuDbSet = dbContext.Set<Menu>();
        }
        #endregion Identity



        public void UserLastLogin(User user)
        {
            using (JDContext context = new JDContext())
            {
                user.LastLoginTime = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void DoSomething()
        {
            this._UserDbSet.Remove(null);
            this._MenuDbSet.Remove(null);
            this._MappingDbSet.Remove(null);

            base.Commit();
        }

        //public User Find(int id)
        //{
        //    using (JDContext context = new JDContext())
        //    {
        //        User user = context.Set<User>().Find(id);
        //        return user;
        //    }
        //}

        //public void Add(User user)
        //{ }

        //public void Update(User user)
        //{ }

        //public void Delete(User user)
        //{ }

        //public void List(User user)
        //{ }
    }
}
