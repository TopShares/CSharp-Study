using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP1
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // ShowMyCar();

            ShowYourCar();

            Console.Read();
        }

        static void ShowMyCar()
        {
            ICar car1 = new ABrandCar() { Brand = "A品牌", Color = "白色" };
            ICar car2 = new BBrandCar() { Brand = "B品牌", Color = "黑色" };

            MyCar newCar = new MyCar();
            newCar.ShowMyCar(car1);
            newCar.ShowMyCar(car2);

        }
        static void ShowYourCar()
        {
            ISP2.ICarBase car1Base = new ISP2.ABrandCar() { Brand = "A品牌", Color = "白色" };
            ISP2.ICarBase car2 = new ISP2.BBrandCar() { Brand = "B品牌", Color = "黑色" };

            ISP2.YourCar newCar = new ISP2.YourCar();
            newCar.ShowYourCar(car1Base);
            newCar.ShowYourCar(car2);

            ISP2.ICarAdvanced car1Advance = new ISP2.ABrandCar() { Brand = "A品牌", Color = "白色" };
            newCar.ShowYourCarAdvance(car1Advance);

        }

    }
}
