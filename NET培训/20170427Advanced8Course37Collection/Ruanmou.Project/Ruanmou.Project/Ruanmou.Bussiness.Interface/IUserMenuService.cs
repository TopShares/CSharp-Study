using Ruanmou.EF.Model;
using Ruanmou.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Interface
{
    [UserHandlerAttribute]
    public interface IUserMenuService : IBaseService
    {
        void UserLastLogin(User user);

        /// <summary>
        /// a 增用户 (随机测试10个用户)
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        IEnumerable<User> InsertUsers(IEnumerable<User> users);

        /// <summary>
        /// b 增菜单 (随机测试10个菜单，要求起码三层父子关系id/parentid，SourcePath=父SourcePath+/+GUID)
        /// 这里一个一个菜单添加，因为下级菜单的parentid需要上级菜单的id
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        Menu InsertMenu(Menu menu);

        /// <summary>
        /// c 设置某个用户和10个菜单的映射关系（User  Menu  UserMenuMapping）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        void MappingUserMenu(User user, IEnumerable<Menu> menus);

        /// <summary>
        /// d 找出某用户拥有的全部菜单列表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Menu> QueryMenuByUser(User user);

        /// <summary>
        /// e 找出拥有某菜单的全部用户列表
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        List<User> QueryUserByMenu(Menu menu);

        /// <summary>
        /// f 根据菜单id找出全部子菜单的列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Menu> QueryMenuByID(int id);

        /// <summary>
        /// g 找出名字中包含"系统"的菜单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<Menu> QueryMenuByKeyWord(string keyword);

        /// <summary>
        /// h 物理删除某用户的时候，删除其全部的映射
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void DeleteMappingByUser(User user);

        /// <summary>
        /// i 物理删除某菜单的时候，删除其全部的映射
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        void DeleteMappingByMenu(Menu menu);

        IQueryable<Menu> QueryMenu(Expression<Func<Menu, bool>> where);

        /// <summary>
        /// 用户登陆 支持账号/手机/邮箱作为账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        User UserLogin(string account);

        /// <summary>
        /// 登陆成功后更新最后登陆时间
        /// </summary>
        /// <param name="user"></param>
        void LastLogin(User user);
    }
}
