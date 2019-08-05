using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace AOPTeachDemo
{
    /// <summary>
    /// AOP实现方式2：基于远程代理对象的订单业务扩展
    /// 这个类是泛型类，目的是能够为不同的类创建代理对象，而不是像装饰器一样，只能固定一个类，这个就是动态代理的好处
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AOPRealProxy<T> : RealProxy
    {
        //【1】基于对象组合方式，保存准备要装饰的对象
        private T targetObject;
        public AOPRealProxy(T t) : base(typeof(T))//初始化远程代理父类的时候，需要使用当前传入的类型
        {
            this.targetObject = t;
        }

        /// <summary>
        /// 【2】重写的方法：实际上这个方法是被装饰对象的核心方法调用
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            AddedValidateTime(msg); //【1】切入第1个方法
            CallPayInterface(msg);      //【2】切入第2个方法

            //核心业务的调用
            IMethodCallMessage callMsg = (IMethodCallMessage)msg;
            object result = callMsg.MethodBase.Invoke(this.targetObject, callMsg.Args);//参数1：核心的业务对象，参数2：方法参数


            AddedReminder(msg);      //【3】切入第3个方法

            return new ReturnMessage(result, new object[0], 0, null, callMsg);
        }


        #region 【3】编写切入的扩展方法

        //自定义扩展功能1：验证上课时间是否和其他课程冲突，以便提示学员是否决定报名
        public bool AddedValidateTime(IMessage order)
        {
            //在这里编写具体的验证过程...

            Console.WriteLine("切入方法1：报名前的上课时间是否冲突检验方法...");
            return false;
        }
        //自定义扩展功能2：通过第三方的接口付款（这个接口通常由专门的人去开发）
        public int CallPayInterface(IMessage order)
        {
            //在这里调用编写第三方支付接口的调用过程...

            Console.WriteLine("切入方法2：第三方支付接口的调用过程...");
            return 1;
        }

        //自定义扩展功能3：课程报名成功后，把当前学员的当前课程加入上课提醒日志
        public bool AddedReminder(IMessage order)
        {
            //在这里编写具体的验证过程...


            Console.WriteLine("切入方法3：报名后的上课弹窗提醒方法...");
            return true;
        }

        #endregion
    }


    /// <summary>
    /// 【4】代理业务类：完成被代理对象的创建
    /// </summary>
    public static class ProxyBusiness
    {
        /// <summary>
        /// 创建对象的泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateObject<T>()
        {
            //使用反射方法创建被代理的对象的实例，并实例化真实代理
            AOPRealProxy<T> realProxy = new AOPRealProxy<T>(Activator.CreateInstance<T>());

            return (T)realProxy.GetTransparentProxy();//返回当前我们注入的实例对象

        }
    }
}
