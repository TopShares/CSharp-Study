using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP1
{
    public interface ICar
    {
        void Start();  //启动
        void Drive();  //行驶
        void Stop();   //停车
        void StartABS(); //启动ABS   

        void OpenSkylight(); //打开天窗
        void OpenNav();        //打开导航

        void StartESC(); //启动ESC(ESP)
        void SwitchFourwheeldrive();//四驱模式
        void SwitchSportModel();//运动模式
    }
}
