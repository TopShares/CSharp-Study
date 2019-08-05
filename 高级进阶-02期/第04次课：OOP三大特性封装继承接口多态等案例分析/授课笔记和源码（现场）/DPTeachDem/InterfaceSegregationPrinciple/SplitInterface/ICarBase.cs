using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP2
{
    public interface ICarBase 
    {
        void Start();  //启动
        void Drive();  //行驶
        void Stop();   //停车
        void StartABS(); //启动ABS 
        void OpenSkylight(); //打开天窗
        void OpenNav();        //打开导航
    }
}
