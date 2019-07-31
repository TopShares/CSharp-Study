using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //给华为手机安装游戏，通讯录软件
            Console.WriteLine("华为.............................");
            TestPhone(new HuaweiPhone());

            //给OPPO手机安装...
            Console.WriteLine("OPPO..........................");
            TestPhone(new OPPOPhone());


            Console.WriteLine("小米..........................");
            TestPhone(new XiaomiPhone());

            Console.Read();

        }

        static void TestPhone(PhoneBrand myPhone)
        {
            myPhone.InstallSoftware(new GameSoftware());
            myPhone.Run();
            myPhone.InstallSoftware(new AddressSoftware());
            myPhone.Run();

            myPhone.InstallSoftware(new WeiXinSoftware());
            myPhone.Run();
        }
    }
}
