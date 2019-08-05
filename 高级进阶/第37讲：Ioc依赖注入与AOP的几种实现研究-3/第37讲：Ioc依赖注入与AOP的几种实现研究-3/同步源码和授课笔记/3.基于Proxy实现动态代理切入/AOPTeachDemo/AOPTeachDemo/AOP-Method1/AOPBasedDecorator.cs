using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPTeachDemo
{
    /// <summary>
    /// AOP实现方式1：基于装饰器设计模式的订单业务扩展（订单核心业务是由专门人完成的）
    /// </summary>
    public class AOPBasedDecorator : IOrderService
    {
        //基于对象组合方式，保存当前准备要装饰的对象
        public IOrderService orderService { get; set; }
        public AOPBasedDecorator(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        //接口实现1
        public List<CourseOrder> GetAllOrders()
        {
            return this.orderService.GetAllOrders();
        }

        public int SubmitOrder(CourseOrder order)
        {
            //【1】切入第1个方法
            AddedValidateTime(order);

            //【2】切入第2个方法
            CallPayInterface(order);


            int result = this.orderService.SubmitOrder(order);//原有核心业务的调用（具体怎么实现，这里并不关心）


            //【3】切入第3个方法
            AddedReminder(order);

            return result;
        }

        //自定义扩展功能1：验证上课时间是否和其他课程冲突，以便提示学员是否决定报名
        public bool AddedValidateTime(CourseOrder order)
        {
            //在这里编写具体的验证过程...

            Console.WriteLine("切入方法1：报名前的上课时间是否冲突检验方法...");
            return false;
        }
        //自定义扩展功能2：通过第三方的接口付款（这个接口通常由专门的人去开发）
        public int CallPayInterface(CourseOrder order)
        {
            //在这里调用编写第三方支付接口的调用过程...

            Console.WriteLine("切入方法2：第三方支付接口的调用过程...");
            return 1;
        }

        //自定义扩展功能3：课程报名成功后，把当前学员的当前课程加入上课提醒日志
        public bool AddedReminder(CourseOrder order)
        {
            //在这里编写具体的验证过程...


            Console.WriteLine("切入方法3：报名后的上课弹窗提醒方法...");
            return true;
        }
    }
}
