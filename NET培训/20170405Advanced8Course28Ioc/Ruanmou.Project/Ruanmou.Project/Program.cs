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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Project
{
    /// <summary>
    /// 1 Ioc(DI)介绍
    /// 控制反转ioc   是目的
    /// DI依赖注入    是手段
    /// 2 Unity容器使用
    /// 3 EF分层封装数据访问
    /// 4 测试数据访问
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是IOC+EF");

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

                IUnityContainer container = new UnityContainer();
                container.RegisterType<IBaseService, BaseService>();
                container.RegisterType<IUserMenuService, UserMenuService>();
                container.RegisterType<DbContext, JDContext>();

                using (IUserMenuService service = container.Resolve<IUserMenuService>())
                {
                    User user = service.Find<User>(2);
                }


                //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                //IUnityContainer container = new UnityContainer();
                //section.Configure(container, "ruanmouContainer");

                //ICategoryService categoryService = container.Resolve<ICategoryService>();
                //Category category = categoryService.Find(1);
                //categoryService.Update(category);
                //categoryService.Show();

                //IBaseService<Category> iBaseServie = container.Resolve<IBaseService<Category>>();

                //Category category1 = iBaseServie.Find(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
