using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class GameSoftware : PhoneSoftware
    {
        //具体编写业务...

        public override void Strat()
        {
            Console.WriteLine("手机游戏正在运行...");
        }
    }
}
