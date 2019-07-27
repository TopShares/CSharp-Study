using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ScreenProtector : Decorator
    {
        public void BMethod()
        {
            Console.WriteLine("BMethod()方法被调用");
        }

        public override void Show()
        {
            base.Show();

            BMethod();

            Console.WriteLine("手机装饰进行中...给手机贴膜...");
        }
    }
}
