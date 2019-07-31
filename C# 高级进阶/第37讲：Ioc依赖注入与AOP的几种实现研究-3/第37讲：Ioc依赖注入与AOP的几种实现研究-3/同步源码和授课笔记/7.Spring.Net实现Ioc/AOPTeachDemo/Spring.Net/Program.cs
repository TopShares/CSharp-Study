using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//引入两个命名空间
using Spring.Context;
using Spring.Context.Support;

namespace Spring.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ioc框架Spring.Net简单使用");

            //【1】创建Spring容器上下文对象
            IApplicationContext appContext = ContextRegistry.GetContext();

            //【2】通过容器上下文对象给我们创建业务对象
            IOrderService orderService = appContext.GetObject("OrderService2") as IOrderService;

            //【3】基于接口正常使用对象
            int result = orderService.SubmitOrder(new CourseOrder());
            Console.WriteLine("订单提交返回结果："+result);

            Console.Read();
        }
    }
}
