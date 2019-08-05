using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//引入相关的命名空间
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace UnityIocByConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //【1】创建容器对象，并加装配置文件
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration("MyContainer");

            //【2】获取指定名称的配置节点,并获取当前配置节点下面的详细配置信息
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            section.Configure(container, "MyContainer");

            //【3】根据指定的name字符串返回指定的对象
            IOrderService orderService = container.Resolve<IOrderService>("OrderService2");

            //基于普通的接口编程使用对象
            List<CourseOrder> orderList = orderService.GetAllOrders();
            Console.WriteLine("订单总数："+orderList.Count );
            Console.Read();
        }
    }
}
