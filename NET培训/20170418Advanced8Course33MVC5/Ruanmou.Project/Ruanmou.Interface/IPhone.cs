using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Interface
{
    public interface IPhone
    {
        void Call();
        IMicrophone iMicrophone { get; set; }
        IHeadphone iHeadphone { get; set; }
        IPower iPower { get; set; }
    }
}
