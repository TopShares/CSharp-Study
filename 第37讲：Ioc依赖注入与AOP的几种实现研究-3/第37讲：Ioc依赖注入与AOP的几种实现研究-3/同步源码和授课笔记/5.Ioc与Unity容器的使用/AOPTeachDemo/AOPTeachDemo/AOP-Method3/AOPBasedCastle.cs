using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//引入命名空间
using Castle.DynamicProxy;

namespace AOPTeachDemo
{
    /// <summary>
    /// AOP实现方式3：基于Castle动态代理完成订单对象扩展
    /// 需要实现一个拦截器接口
    /// </summary>
    public class AOPBasedCastle : IInterceptor
    {
        /// <summary>
        /// 接口实现方法：Intercept-->拦截器，用于完成核心业务调用
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            AddedValidateTime(invocation); //【1】切入第1个方法
            CallPayInterface(invocation);      //【2】切入第2个方法

            //核心业务调用
            invocation.Proceed();

            AddedReminder(invocation);      //【3】切入第3个方法
        }
        #region 编写切入的扩展方法

        //自定义扩展功能1：验证上课时间是否和其他课程冲突，以便提示学员是否决定报名
        public bool AddedValidateTime(IInvocation invocation)
        {
            //在这里编写具体的验证过程...

            Console.WriteLine("切入方法1：报名前的上课时间是否冲突检验方法...");
            return false;
        }
        //自定义扩展功能2：通过第三方的接口付款（这个接口通常由专门的人去开发）
        public int CallPayInterface(IInvocation invocation)
        {
            //在这里调用编写第三方支付接口的调用过程...

            Console.WriteLine("切入方法2：第三方支付接口的调用过程...");
            return 1;
        }

        //自定义扩展功能3：课程报名成功后，把当前学员的当前课程加入上课提醒日志
        public bool AddedReminder(IInvocation invocation)
        {
            //在这里编写具体的验证过程...


            Console.WriteLine("切入方法3：报名后的上课弹窗提醒方法...");
            return true;
        }

        #endregion

    }
}
