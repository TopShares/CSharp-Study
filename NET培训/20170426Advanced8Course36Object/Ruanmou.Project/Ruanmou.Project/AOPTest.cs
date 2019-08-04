using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ruanmou.Bussiness.Interface;
using Ruanmou.Bussiness.Service;
using Ruanmou.EF.Model;
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
    public class AOPTest
    {
        public static void Show()
        {

            {
                //程序注册 基于特性
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IBaseService, BaseService>();
                container.RegisterType<IUserMenuService, UserMenuService>(new InjectionConstructor(typeof(DbContext), 123));//指定构造函数的参数值
                container.RegisterType<IUserCompanyService, UserCompanyService>();
                container.RegisterType<DbContext, JDContext>();

                container.AddNewExtension<Interception>().Configure<Interception>()
               .SetInterceptorFor<IUserMenuService>(new InterfaceInterceptor());

                using (IUserMenuService service = container.Resolve<IUserMenuService>())
                {
                    User user = service.Find<User>(1);//继承接口无效
                    service.UserLastLogin(user);//只有这个才有拦截
                }
            }

            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                IUnityContainer container = new UnityContainer();
                section.Configure(container, "ruanmouContainer");

                using (IUserMenuService service = container.Resolve<IUserMenuService>())
                {
                    User user = service.Find<User>(1);//都会生效
                    service.UserLastLogin(user);
                }
            }
        }
    }
}
