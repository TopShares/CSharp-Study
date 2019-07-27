
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Castle.DynamicProxy;

namespace AOPTeachDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------【AOP】面向切面编程-------\r\n\r\n");

            //创建订单信息对象
            CourseOrder order = new CourseOrder
            {
                CourseId = 1001,
                CourseName = ".NET高级VIP课程",
                CoursePrice = 3500,
                SchoolId = 502102,
                StudentId = 293400
            };

            //【1】基于普通的接口编程
            Console.WriteLine("【基于普通接口编程】\r\n");
            IOrderService orderService = new OrderService();
            int result = orderService.SubmitOrder(order);
            Console.WriteLine("订单提交返回结果：" + result);

            //【2】基于装饰器设计模式为核心业务切入方法
            Console.WriteLine("\r\nAOP实现方式1：【基于装饰器设计模式为核心业务切入方法】\r\n");
            orderService = new AOPBasedDecorator(orderService);
            result = orderService.SubmitOrder(order);
            Console.WriteLine("订单提交返回结果：" + result);

            //【3】基于动态代理方式为核心业务切入方法
            Console.WriteLine("\r\nAOP实现方2：【基于远程动态代理方式为核心业务切入方法】\r\n");
            //通过代理产生具体的OrderServiceProxy对象，但是这个过程细节，其实我们根本看不到
            IOrderService orderService3 = ProxyBusiness.CreateObject<OrderServiceProxy>();
            //调用核心业务
            result = orderService3.SubmitOrder(order);//实际上调用的是Invoke方法
            Console.WriteLine("订单提交返回结果：" + result);
            Console.WriteLine("---------------------------------------------------------------");
            List<CourseOrder> list = orderService3.GetAllOrders();

            //【4】基于第三方Castle动态代理方式为核心业务切入方法
            Console.WriteLine("\r\nAOP实现方3：【基于第三方Castle动态代理方式为核心业务切入方法】\r\n");
            ProxyGenerator generator = new ProxyGenerator();//为类或接口提供代理对象
            AOPBasedCastle intercepor = new AOPBasedCastle();
            //基于Castle动态代理完成对象创建
            IOrderService orderService4 = generator.CreateClassProxy<OrderServiceCastle>(intercepor);
            result = orderService4.SubmitOrder(order);//实际上调用的是Invoke方法
            Console.WriteLine("订单提交返回结果：" + result);


            Console.Read();
        }
    }
}
