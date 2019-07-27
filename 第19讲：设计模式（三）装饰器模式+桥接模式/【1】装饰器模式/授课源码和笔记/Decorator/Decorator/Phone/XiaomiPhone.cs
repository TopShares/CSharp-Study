using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class XiaomiPhone : Phone
    {
        public override void Show()
        {
            Console.WriteLine("我是小米手机");
        }
    }
}
