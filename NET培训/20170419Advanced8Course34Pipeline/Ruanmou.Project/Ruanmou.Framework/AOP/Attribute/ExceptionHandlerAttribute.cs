using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ruanmou.Framework.AOP.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework.AOP.Attribute
{
    public class ExceptionHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionHandler() { Order = this.Order };
        }
    }

}
