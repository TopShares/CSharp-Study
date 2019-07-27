using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class WeiXinSoftware : PhoneSoftware
    {
        public override void Strat()
        {
            Console.WriteLine("微信正在运行....现在是最新版本");
        }
    }
}
