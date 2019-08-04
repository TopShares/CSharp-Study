using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework
{
    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("UserHandler");
            return getNext()(input, getNext);
        }
    }
    public class UserHandlerAttribute : HandlerAttribute
    {
        public new int Order { get; set; }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandler() { Order = this.Order };
            return handler;
        }
    }


    public class LogBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBehavior");
            return getNext().Invoke(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }



}
