using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP2 
{
    public interface ICarAdvanced
    {
        void StartESC(); //启动ESC(ESP)
        void SwitchFourwheeldrive();//四驱模式
        void SwitchSportModel();//运动模式
    }
}
