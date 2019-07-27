using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            Console.Read();
        }
    }
}
