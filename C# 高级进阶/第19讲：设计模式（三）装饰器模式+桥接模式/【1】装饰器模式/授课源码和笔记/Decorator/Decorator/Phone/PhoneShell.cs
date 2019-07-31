using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// 具体装饰类：手机壳--》继承装饰类
    /// 给Phone增加功能
    /// </summary>
    public class PhoneShell : Decorator
    {
        /// <summary>
        /// 自己独有的行为（当前也可以是属性）
        /// </summary>
        private void AMethod()
        {
            //在这里完成具体的业务...


            Console.WriteLine("AMethod（）方法被调用！");
        }

        public override void Show()
        {
            base.Show();//首先执行的是Phone的show行为

            //在这里可以编写需要的业务逻辑...
            AMethod();

            Console.WriteLine("手机装饰进行中...添加手机壳...");
        }
    }
}
