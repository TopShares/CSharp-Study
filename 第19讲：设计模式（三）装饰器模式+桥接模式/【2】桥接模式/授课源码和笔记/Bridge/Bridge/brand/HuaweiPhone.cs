using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// 华为手机
    /// </summary>
    class HuaweiPhone : PhoneBrand
    {
        public override void Run()
        {
            base.software.Strat();
        }
    }
}
