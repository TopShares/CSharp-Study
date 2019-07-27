using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace UnityAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nAOP实现方4：【基于Unity容器为核心业务切入方法】\r\n");

            //【6】容器的使用
            //6.1 创建一个容器对象
            IUnityContainer container = new UnityContainer();
            //6.2 通过容器注册IOrderService
            container.RegisterType<IOrderService, OrderService>();

            //6.3 为容器增加新的扩展（注入新的功能）
            container.AddNewExtension<Interception>()
                .Configure<Interception>()
                .SetInterceptorFor<IOrderService>(new InterfaceInterceptor());
            //Interception:拦截器
            //InterfaceInterceptor:接口拦截器

            //6.5 通过容器创建对象
            IOrderService orderService = container.Resolve<IOrderService>();

            //6.6 调用核心的业务逻辑
            CourseOrder order = new CourseOrder
            {
                CourseId = 1001,
                CourseName = ".NET高级VIP课程",
                CoursePrice = 3500,
                SchoolId = 502102,
                StudentId = 293400
            };

            orderService.SubmitOrder(order);

            Console.Read();
        }
    }
}
