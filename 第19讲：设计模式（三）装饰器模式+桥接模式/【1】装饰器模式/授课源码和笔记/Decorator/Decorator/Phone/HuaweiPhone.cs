using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// 具体的实现类
    /// </summary>
    public class HuaweiPhone : Phone
    {
        public override void Show()
        {
            //在这里编写具体的对象要完成的逻辑...



            Console.WriteLine("我是华为手机...");
        }
    }
}
