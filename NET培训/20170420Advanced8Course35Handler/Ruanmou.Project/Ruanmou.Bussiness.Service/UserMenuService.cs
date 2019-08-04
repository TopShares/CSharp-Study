using Ruanmou.Bussiness.Interface;
using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Service
{
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
        public UserMenuService(DbContext dbContext, int id)
            : base(dbContext)
        {
            this._MappingDbSet = dbContext.Set<UserMenuMapping>();
            this._UserDbSet = dbContext.Set<User>();
            this._MenuDbSet = dbContext.Set<Menu>();
        }
        #endregion Identity

        public User UserLogin(string account)
        {
            return this._UserDbSet.FirstOrDefault(u => u.Mobile.Equals(account) || u.Account.Equals(account) || u.Email.Equals(account));
        }

        public void LastLogin(User user)
        {
            user.LastLoginTime = DateTime.Now;
            base.Update(user);
        }
        public void UserLastLogin(User user)
        {
            //using (JDContext context = new JDContext())
            //{
            //    user.LastLoginTime = DateTime.Now;
            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// a 增用户 (随机测试10个用户)
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public IEnumerable<User> InsertUsers(IEnumerable<User> users)
        {
            return base.Insert<User>(users);
        }

        /// <summary>
        /// b 增菜单 (随机测试10个菜单，要求起码三层父子关系id/parentid，SourcePath=父SourcePath+/+GUID)
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public Menu InsertMenu(Menu menu)
        {
            return base.Insert<Menu>(menu);
        }

        /// <summary>
        /// c 设置某个用户和10个菜单的映射关系（User  Menu  UserMenuMapping）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public void MappingUserMenu(User user, IEnumerable<Menu> menus)
        {
            var mappingList = menus.Select(o => new UserMenuMapping() { UserId = user.Id, MenuId = o.Id });
            base.Insert<UserMenuMapping>(mappingList);
        }

        /// <summary>
        /// d 找出某用户拥有的全部菜单列表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Menu> QueryMenuByUser(User user)
        {
            var menuIdList = _MappingDbSet.Where(o => o.UserId == user.Id).Select(o => o.MenuId);//并不会执行
            return _MenuDbSet.Where(o => menuIdList.Contains(o.Id)).ToList();
        }

        /// <summary>
        /// e 找出拥有某菜单的全部用户列表
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public List<User> QueryUserByMenu(Menu menu)
        {
            var userIdList = this._MappingDbSet.Where(o => o.MenuId == menu.Id).Select(o => o.UserId);
            return this._UserDbSet.Where(o => userIdList.Contains(o.Id)).ToList();
        }

        /// <summary>
        /// f 根据菜单id找出全部子菜单的列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Menu> QueryMenuByID(int id)
        {
            return this._MenuDbSet.Where(o => o.SourcePath.StartsWith(this._MenuDbSet.Where(m => m.Id == id).Select(m => m.SourcePath).FirstOrDefault())).ToList();
        }

        /// <summary>
        /// g 找出名字中包含"系统"的菜单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Menu> QueryMenuByKeyWord(string keyword)
        {
            return this._MenuDbSet.Where(o => o.Name.Contains(keyword)).ToList();
        }

        /// <summary>
        /// h 物理删除某用户的时候，删除其全部的映射
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void DeleteMappingByUser(User user)
        {
            var mappingList = this._MappingDbSet.Where(o => o.UserId == user.Id);
            using (var trans = base.Context.Database.BeginTransaction())
            {//同一个context，每次都即时commit，使用BeginTransaction(事务方式一)
                try
                {
                    base.Delete<User>(user);
                    //throw new Exception("123");//会取消前一次的提交
                    base.Delete<UserMenuMapping>(mappingList);//执行查询，按条执行sql，一个连接
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// i 物理删除某菜单的时候，删除其全部的映射
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public void DeleteMappingByMenu(Menu menu)
        {
            var menuList = this._MenuDbSet.Where(o => o.SourcePath.StartsWith(menu.SourcePath));
            var mappingList = this._MappingDbSet.Where(o => menuList.Select(m => m.Id).Contains(o.MenuId));
            this._MappingDbSet.RemoveRange(mappingList);
            this._MenuDbSet.RemoveRange(menuList);
            base.Commit();//移除多个对象，使用base.Commit即SaveChanges来完成事务(事务方式二)
            //执行查询，按条执行sql，一个连接
        }

        public IQueryable<Menu> QueryMenu(Expression<Func<Menu, bool>> where)
        {
            return this._MenuDbSet.Where(where);
        }

        /// <summary>
        /// 释放EF数据连接
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
