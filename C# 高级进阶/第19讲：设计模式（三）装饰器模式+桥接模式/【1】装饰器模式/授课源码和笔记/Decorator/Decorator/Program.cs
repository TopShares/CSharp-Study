using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //给我来一台手机
            Phone myPhone = new HuaweiPhone();

            //准备几个装饰件（准备要扩展的功能）  
            Decorator screenProtector = new ScreenProtector();
            Decorator phoneShell = new PhoneShell();

            //先给手机贴膜
            screenProtector.SetDecorate(myPhone);
            //再给已经贴膜的手机，家装手机壳
            phoneShell.SetDecorate(screenProtector);

            phoneShell.Show();

            Console.WriteLine();

            Phone yourPhone = new XiaomiPhone();
            Decorator screenProtector2 = new ScreenProtector();
            Decorator phoneShell2 = new PhoneShell();
            Decorator phoneHanger = new PhoneHanger();

            //先给手机贴膜
            screenProtector2.SetDecorate(yourPhone);
            //再给已经贴膜的手机，家装手机壳
            phoneShell2.SetDecorate(screenProtector2);

            //最后给加完壳的手机添加挂件
            phoneHanger.SetDecorate(phoneShell2);

            //展示你的手机效果
            phoneHanger.Show();

            Console.Read();

        }
    }
}
