using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP2
{
    //请大家回顾：MVC里面的Controller、以及EF里面的DBContext类，是不是都是继承一个类，实现若干接口
    public class ABrandCar : AbstractCar, ICarBase,ICarAdvanced //,IDisposable
    {
        public void Start()
        {
            Console.WriteLine($"{Brand}汽车点火启动！--无钥匙启动");
        }
        public void Drive()
        {
            Console.WriteLine($"{Brand}汽车正常行驶！--自动挡");
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

        public void StartESC()
        {
            Console.WriteLine($"{Brand}汽车ESC安全保障启动！");
        }


        public void SwitchFourwheeldrive()
        {
            Console.WriteLine($"{Brand}汽车切换到四轮驱动");
        }

        public void SwitchSportModel()
        {
            Console.WriteLine($"{Brand}汽车切换到运动模式！");
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
