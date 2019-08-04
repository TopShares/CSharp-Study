using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ruanmou.Interface;
using Ruanmou.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ruanmou.Project
{
    public class IOCTest
    {
        public static void Show()
        {
            Console.WriteLine("**************************************");
            {
                ApplePhone applePhone = new ApplePhone();
                Console.WriteLine("applePhone.iHeadphone==null? {0}", applePhone.iHeadphone == null);
                Console.WriteLine("applePhone.iMicrophone==null? {0}", applePhone.iMicrophone == null);
                Console.WriteLine("applePhone.iPower==null? {0}", applePhone.iPower == null);
            }



            Console.WriteLine("*****************UnityAndroid*********************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, AndroidPhone>();
                //接口--类型    父类-子类  抽象类-子类    
                //container.RegisterInstance<IPhone>(new AndroidPhone());//实例注册
                IPhone phone = container.Resolve<IPhone>();

                Console.WriteLine("phone.iHeadphone==null? {0}", phone.iHeadphone == null);
                Console.WriteLine("phone.iMicrophone==null? {0}", phone.iMicrophone == null);
                Console.WriteLine("phone.iPower==null? {0}", phone.iPower == null);
            }
            Console.WriteLine("*****************UnityApple*********************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, ApplePhone>();
                container.RegisterType<IMicrophone, Microphone>();
                container.RegisterType<IHeadphone, Headphone>();
                container.RegisterType<IPower, Power>();

                IPhone phone = container.Resolve<IPhone>();

                Console.WriteLine("phone.iHeadphone==null? {0}", phone.iHeadphone == null);
                Console.WriteLine("phone.iMicrophone==null? {0}", phone.iMicrophone == null);
                Console.WriteLine("phone.iPower==null? {0}", phone.iPower == null);
            }


            Console.WriteLine("*****************UnityContainer*********************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, ApplePhone>(new PerResolveLifetimeManager());
                container.RegisterType<IPhone, ApplePhone>("Apple");
                container.RegisterType<IPhone, AndroidPhone>("Android");
                container.RegisterType<IMicrophone, Microphone>();
                container.RegisterType<IHeadphone, Headphone>();
                container.RegisterType<IPower, Power>();

                container.AddNewExtension<Interception>().Configure<Interception>()
                .SetInterceptorFor<IPhone>(new InterfaceInterceptor());

                IPhone iphone1 = container.Resolve<IPhone>();
                iphone1.Call();
                IPhone iphone2 = container.Resolve<IPhone>("Apple");
                IPhone iphone3 = container.Resolve<IPhone>("Android");
                IPhone iphone4 = container.Resolve<IPhone>();
                IPhone iphone5 = container.Resolve<IPhone>();
            }
            Console.WriteLine("*****************UnityContainer*********************");
            {
                IUnityContainer container = new UnityContainer();
                //container.RegisterType<IPhone, AndroidPhone>(new TransientLifetimeManager());瞬时
                container.RegisterType<IPhone, AndroidPhone>(new ContainerControlledLifetimeManager());//容器单例
                //container.RegisterType<IPhone, AndroidPhone>(new PerThreadLifetimeManager());//线程单例


                IPhone iphone1 = null;
                Action act1 = new Action(() =>
                {
                    iphone1 = container.Resolve<IPhone>();
                });
                var result1 = act1.BeginInvoke(null, null);

                IPhone iphone2 = null;
                Action act2 = new Action(() =>
                {
                    iphone2 = container.Resolve<IPhone>();
                });

                var result2 = act2.BeginInvoke(null, null);

                act1.EndInvoke(result1);
                act2.EndInvoke(result2);

                //IPhone iphone1 = container.Resolve<IPhone>();
                //IPhone iphone2 = container.Resolve<IPhone>();

                Console.WriteLine(object.ReferenceEquals(iphone1, iphone2));
            }
            Console.WriteLine("*****************UnityContainer*********************");
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                IUnityContainer container = new UnityContainer();
                section.Configure(container, "testContainer");

                IPhone phone = container.Resolve<IPhone>();
                phone.Call();
            }




            Console.WriteLine("*****************UnityContainer*********************");
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                IUnityContainer container = new UnityContainer();
                section.Configure(container, "testContainerAOP");
                IPhone phone = container.Resolve<IPhone>();
                phone.Call();
            }
        }
    }
}
