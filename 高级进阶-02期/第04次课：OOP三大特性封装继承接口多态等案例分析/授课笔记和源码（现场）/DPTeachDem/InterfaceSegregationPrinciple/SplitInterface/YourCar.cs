using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP2
{
    public class YourCar
    {
        /// <summary>
        /// 通用功能
        /// </summary>
        /// <param name="car"></param>
        public void ShowYourCar(ICarBase car)
        {
            car.Start();
            car.Drive();
            car.OpenNav();
            car.OpenSkylight();
            car.StartABS();          
        }

        //实现自由组装，灵活方便！

        //通过接口隔离，我们单独增加了接口类，方法也做了相应扩展（非常类似于：数据库中的二范式或三范式！）
        public void ShowYourCarAdvance(ICarAdvanced car)
        {
            car.StartESC();
            car.SwitchFourwheeldrive();
            car.SwitchSportModel();
        }

    }
}
