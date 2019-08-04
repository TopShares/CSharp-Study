using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Ruanmou.Bussiness.Interface;
//using Ruanmou.Bussiness.Interface;
using Ruanmou.Bussiness.Service;
using Ruanmou.EF.Model;
using Ruanmou.Interface;
//using Ruanmou.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ruanmou.Project
{
    /// <summary>
    /// 1 Ioc(DI)介绍
    /// 控制反转ioc   是目的
    /// DI依赖注入    是手段
    /// 2 Unity容器使用
    /// 3 EF分层封装数据访问
    /// 4 测试数据访问
    /// 
    /// 
    /// 1 什么是领域驱动设计DDD  domain driven design
    /// 2 理解领域、拆分领域、细化领域
    /// 3 领域模型设计
    /// 4 EF访问基类，多种事务的实现方式
    /// 5 作业部署
    /// 
    /// 1 讲作业
    /// 2 EF数据访问层、三种事务方式、延迟加载、导航属性
    /// 3 mvc5初步接触：route、controller view，传值
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是IOC+EF");
                #region 依赖倒置
                //{
                //    AndroidPhone phone = new AndroidPhone();
                //}
                //{
                //    IPhone phone = new AndroidPhone();
                //}
                //{
                //    IPhone phone = ObjectFactory.CreatePhone();
                //}
                //IOCTest.Show();
                #endregion

                #region ioc

                //using (JDContext context = new JDContext())
                //{
                //    User user = context.Set<User>().Find(2);
                //}

                //UserService service = new UserService();
                ////User user = service.Find(2);
                //User user = service.Find<User>(2);

                //IUserMenuService service = new UserMenuService();
                //User user = service.Find<User>(2);
                //service.UserLastLogin(user);

                //{
                //    IUnityContainer container = new UnityContainer();
                //    container.RegisterType<IBaseService, BaseService>();
                //    container.RegisterType<IUserMenuService, UserMenuService>();
                //    container.RegisterType<DbContext, JDContext>();

                //    using (IUserMenuService service = container.Resolve<IUserMenuService>())
                //    {
                //        using (IUnitOfWork unitOfWork = new UnitOfWork())
                //        {
                //            User user = service.Find<User>(2);


                //            unitOfWork.Commit();
                //        }
                //    }
                //}
                #endregion ioc

                #region homework
                //IUnityContainer container = ContainerFactory.GetContainer();
                //{
                //    using (IUserMenuService iUserMenuService = container.Resolve<IUserMenuService>())
                //    {
                //        //用户列表
                //        List<User> userList = new List<User>();
                //        #region  a 增用户 (随机测试10个用户)
                //        {
                //            for (int i = 1; i <= 10; i++)
                //            {
                //                userList.Add(new User()
                //                {
                //                    Name = string.Format("Test{0}", i.ToString("000")),
                //                    Account = new Random().Next(10000, 99999).ToString(),
                //                    Password = "448",
                //                    Email = "25759541@qq.com",
                //                    Mobile = "13111111111",
                //                    CompanyId = i,
                //                    CompanyName = string.Format("软谋教育{0}", i.ToString("000")),
                //                    State = 1,
                //                    UserType = 2,
                //                    LastLoginTime = DateTime.Now,
                //                    CreateTime = DateTime.Now,
                //                    CreatorId = 1,
                //                    LastModifierId = 1,
                //                    LastModifyTime = DateTime.Now
                //                });
                //            }


                //            //userList[2].Mobile = "12333333333333333333333333333333333333333333333333333333";
                //            //异常，测试单Context多sql，一个异常，全部失败

                //            var userListInsert = iUserMenuService.InsertUsers(userList);
                //            foreach (var user in userListInsert)
                //            {
                //                Console.WriteLine("id={0}  name={1}", user.Id, user.Name);
                //            }

                //        }
                //        //单个操作的用户
                //        User userItem = userList[0];
                //        #endregion

                //        //菜单列表
                //        List<Menu> menuList = new List<Menu>();
                //        #region b 增菜单(随机测试10个菜单，要求起码三层父子关系id / parentid，SourcePath = 父SourcePath +/ +GUID)
                //        {
                //            //上级菜单
                //            Menu parentMenu = null;
                //            for (int i = 0; i < 10; i++)
                //            {

                //                if (i % 3 == 0)
                //                    parentMenu = null;

                //                Menu menu = new Menu()
                //                {
                //                    ParentId = 0, // parentMenu==null? 0: parentMenu.Id, //如果上级菜单不为空，则=parentMenu.Id
                //                    Name = string.Format("菜单{0}", i),
                //                    Description = string.Format("菜单描述{0}", i),
                //                    Url = string.Empty,
                //                    //SourcePath = "root",
                //                    State = 0,
                //                    MenuLevel = 1,
                //                    Sort = i,
                //                    CreateTime = DateTime.Now,
                //                    CreatorId = 1,
                //                    LastModifierId = 1,
                //                    LastModifyTime = DateTime.Now
                //                };

                //                if (parentMenu != null)
                //                {
                //                    menu.ParentId = parentMenu.Id;
                //                    menu.MenuLevel = parentMenu.MenuLevel + 1;
                //                    menu.SourcePath = parentMenu.SourcePath + "/" + Guid.NewGuid().ToString();
                //                }
                //                else
                //                {
                //                    menu.SourcePath = "root/" + Guid.NewGuid().ToString();
                //                }

                //                parentMenu = iUserMenuService.InsertMenu(menu);
                //                menuList.Add(menu);
                //                Console.WriteLine("id={0}  name={1}", parentMenu.Id, parentMenu.Name);
                //            }
                //        }
                //        //单个操作的菜单
                //        Menu menuItem = menuList[0];
                //        #endregion
                //        #region c 设置某个用户和10个菜单的映射关系（User  Menu  UserMenuMapping）
                //        {
                //            iUserMenuService.MappingUserMenu(userItem, menuList);
                //        }
                //        #endregion
                //        #region d 找出某用户拥有的全部菜单列表
                //        {
                //            var list = iUserMenuService.QueryMenuByUser(userItem);
                //        }
                //        #endregion
                //        #region e 找出拥有某菜单的全部用户列表
                //        {
                //            var users = iUserMenuService.QueryUserByMenu(menuItem);
                //        }
                //        #endregion
                //        #region f 根据菜单id找出全部子菜单的列表
                //        {
                //            var menus = iUserMenuService.QueryMenuByID(menuItem.Id);
                //        }
                //        #endregion
                //        #region g 找出名字中包含"系统"的菜单列表
                //        {
                //            var menus = iUserMenuService.QueryMenuByKeyWord("系统");
                //        }
                //        #endregion
                //        #region h 物理删除某用户的时候，删除其全部的映射
                //        {
                //            iUserMenuService.DeleteMappingByUser(userItem);
                //        }
                //        #endregion
                //        #region i 物理删除某菜单的时候，删除其全部的映射
                //        {
                //            iUserMenuService.DeleteMappingByMenu(menuItem);
                //        }
                //        #endregion
                //    }
                //}
                //{
                //    using (IUserMenuService iUserMenuService1 = container.Resolve<IUserMenuService>())
                //    using (IUserMenuService iUserMenuService2 = container.Resolve<IUserMenuService>())
                //    using (ICommodityService iCommodityService = container.Resolve<ICommodityService>())
                //    {
                //        Menu menu1 = iUserMenuService1.QueryMenu(m => m.Id > 10).FirstOrDefault();
                //        Menu menu2 = iUserMenuService1.QueryMenu(m => m.Id < 100).FirstOrDefault();
                //        Menu menu = iUserMenuService1.QueryMenu(m => m.Id > 10).FirstOrDefault();
                //        Commodity commodity = iCommodityService.QueryCommodity(c => c.Id > 100).FirstOrDefault();

                //        menu1.Name += "123";
                //        menu2.Name += "456";
                //        commodity.Price -= 1;
                //        //不同的context，只能用UnitOfWork来事务
                //        using (IUnitOfWork iUnitOfWork = container.Resolve<IUnitOfWork>())
                //        {
                //            //iUserMenuService1.Update(menu1);
                //            Menu menu3 = Clone(menu1);//做一个全新的对象
                //            //iUserMenuService1.Update(menu3);//异常，不能换一个对象去更新
                //            menu3.Id += 1;
                //            iUserMenuService1.Update(menu3);//异常，不能换一个对象去更新
                //            iUserMenuService2.Update(menu2);//可以更新一个，在context的本地属性
                //            iCommodityService.Update(commodity);

                //            iUnitOfWork.Commit();
                //        }
                //    }
                //}
                #endregion

                #region AOP
                {
                    //AOPTest.Show();
                }
                #endregion AOP

                #region EF
                {
                    EFTest.Show();
                }
                #endregion


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
        /// <summary>
        /// 还可以用表达式树的方式哦
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private static T Clone<T>(T t)
        {
            Type type = typeof(T);
            T tNew = (T)Activator.CreateInstance(type);
            foreach (var item in type.GetProperties())
            {
                item.SetValue(tNew, item.GetValue(t));
            }
            return tNew;
        }
    }
}
