using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP1
{
    public class BBrandCar : AbstractCar, ICar
    {
        public void Start()
        {
            Console.WriteLine($"{Brand}汽车点火启动！");
        }
        public void Drive()
        {
            Console.WriteLine($"{Brand}汽车正常行驶！");
        }
        public void Stop()
        {
            Console.WriteLine($"{Brand}汽车停车！");
        }

        public void OpenNav()
        {
            Console.WriteLine($"{Brand}汽车打开导航！");
        }

        public void OpenSkylight()
        {
            Console.WriteLine($"{Brand}汽车打开天窗！");
        }

        public void StartABS()
        {
            Console.WriteLine($"{Brand}汽车ABS启动工作！");
        }

        //假如B汽车没有这个功能，是不能注释掉的（因为接口具有强制性）

        public void StartESC()
        {
            throw new NotImplementedException();
        }
        public void SwitchFourwheeldrive()
        {
            throw new NotImplementedException();
        }

        public void SwitchSportModel()
        {
            throw new NotImplementedException();
        }
    }
}
