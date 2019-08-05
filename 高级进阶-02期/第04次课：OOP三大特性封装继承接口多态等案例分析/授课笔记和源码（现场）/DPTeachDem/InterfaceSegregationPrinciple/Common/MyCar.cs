using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP1
{
    public class MyCar
    {
        public void ShowMyCar(ICar car)
        {
            car.Start();
            car.Drive();
            car.OpenNav();
            car.OpenSkylight();
            car.StartABS();
            car.StartESC();
            car.SwitchFourwheeldrive();
            car.SwitchSportModel();
            car.Stop();
        }
    }
}
