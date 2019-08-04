using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ESTM.WCF.Service
{
    public class Bootstrapper
    {
        private string strBaseServiceUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();

        //启动所有的服务
        public void StartServices()
        {
            //1.读取此程序集里面的有服务契约的接口和实现类
            var assembly = Assembly.Load(typeof(Bootstrapper).Namespace);
            var lstType = assembly.GetTypes();
            var lstTypeInterface = new List<Type>();
            var lstTypeClass = new List<Type>();
            foreach (var oType in lstType)
            {
                //2.通过接口上的特性取到需要的接口和实现类
                var lstCustomAttr = oType.CustomAttributes;
                if (lstCustomAttr.Count() <= 0)
                {
                    continue;
                }
                var oInterfaceServiceAttribute = lstCustomAttr.FirstOrDefault(x => x.AttributeType.Equals(typeof(ServiceInterfaceAttribute)));
                if (oInterfaceServiceAttribute != null)
                {
                    lstTypeInterface.Add(oType);
                    continue;
                }
                var oClassServiceAttribute = lstCustomAttr.FirstOrDefault(x => x.AttributeType.Equals(typeof(ServiceClassAttribute)));
                if (oClassServiceAttribute != null)
                {
                    lstTypeClass.Add(oType);
                }                
            }

            //3.启动所有服务
            foreach (var oInterfaceType in lstTypeInterface)
            {
                var lstTypeClassTmp = lstTypeClass.Where(x => x.GetInterface(oInterfaceType.Name) != null).ToList();
                if (lstTypeClassTmp.Count <= 0)
                {
                    continue;
                }
                if(lstTypeClassTmp[0].GetInterface(oInterfaceType.Name).Equals(oInterfaceType))
                {
                    var oTask = Task.Factory.StartNew(() =>
                    {
                        OpenService(strBaseServiceUrl + "/" + oInterfaceType.Name, oInterfaceType, lstTypeClassTmp[0]);
                    });
                }
            }            
        }

        //通过服务接口类型和实现类型启动WCF服务
        private void OpenService(string strServiceUrl, Type typeInterface, Type typeclass)
        {
            Uri httpAddress = new Uri(strServiceUrl);
            using (ServiceHost host = new ServiceHost(typeclass))//需要添加System.SystemModel这个dll。。。。CSOAService这个为实现ICSOAService的实现类，WCF真正的实现方法再这个类里面
            {
                ///////////////////////////////////////添加服务节点///////////////////////////////////////////////////
                host.AddServiceEndpoint(typeInterface, new WSHttpBinding(), httpAddress);//ICSOAService这个为向外暴露的接口
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = httpAddress;
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += delegate
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("服务启动成功。服务地址：" + strServiceUrl);
                };

                host.Open();
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
