using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    /// <summary>
    /// 
    /// </summary>
    public class ISPShow
    {
        public static void Show()
        {
            IExtendAdvanced phone = new Honor();
            //List<int>
            phone.Map();
            phone.Pay();

        }
    }
}
