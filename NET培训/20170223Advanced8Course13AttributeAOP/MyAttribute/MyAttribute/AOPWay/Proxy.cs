using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AOPWay
{
    /// <summary>
    /// 使用.Net Remoting/RealProxy 实现动态代理
    /// </summary>
    public class Proxy
    {
        public static void Show()
        {
            User user = new User() { Name = "Eleven", Password = "123123123123" };

            //UserProcessor processor = new UserProcessor();

            UserProcessor userprocessor = TransparentProxy.Create<UserProcessor>();
            userprocessor.RegUser(user);
        }

        public class MyRealProxy<T> : RealProxy
        {
            private T tTarget;
            public MyRealProxy(T target)
                : base(typeof(T))
            {
                this.tTarget = target;
            }

            public override IMessage Invoke(IMessage msg)
            {
                PreProceede(msg);
                IMethodCallMessage callMessage = (IMethodCallMessage)msg;
                object returnValue = callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);
                PostProceede(msg);
                return new ReturnMessage(returnValue, new object[0], 0, null, callMessage);
            }
            public void PreProceede(IMessage msg)
            {
                Console.WriteLine("方法执行前");
            }
            public void PostProceede(IMessage msg)
            {
                Console.WriteLine("方法执行后");
            }
        }

        //TransparentProxy
        public static class TransparentProxy
        {
            public static T Create<T>()
            {
                T instance = Activator.CreateInstance<T>();
                MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
                T transparentProxy = (T)realProxy.GetTransparentProxy();
                return transparentProxy;
            }
        }

        public interface IUserProcessor
        {
            void RegUser(User user);
        }

        public class UserProcessor : MarshalByRefObject, IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。用户名称{0} Password{1}", user.Name, user.Password);
            }
        }

    }
}
