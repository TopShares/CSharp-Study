using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// 具体装饰类：手机挂件
    /// </summary>
    public class PhoneHanger:Decorator
    {
        public override void Show()
        {
            base.Show();
            //在这里编写业务逻辑

            Console.WriteLine("手机装饰进行中...为手机增加挂件...");
        }
    }
}
