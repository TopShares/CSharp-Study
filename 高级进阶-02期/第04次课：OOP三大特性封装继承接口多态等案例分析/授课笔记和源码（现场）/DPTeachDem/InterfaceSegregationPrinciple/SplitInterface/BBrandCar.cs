using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP2
{
    public class BBrandCar : AbstractCar, ICarBase
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
    }
}
