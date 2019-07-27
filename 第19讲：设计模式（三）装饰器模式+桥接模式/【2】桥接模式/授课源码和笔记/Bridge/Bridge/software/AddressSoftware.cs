using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class AddressSoftware : PhoneSoftware
    {    

        public override void Strat()
        {
            Console.WriteLine("手机通讯录在运行...");
        }
    }
}
