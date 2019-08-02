using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_类的定义和声明 {
    class Program {
        static void Main(string[] args) {
            //Vehicle car1 = new Vehicle();
            //car1.speed = 100;
            //car1.Run();
            //car1.Stop();
            //Console.WriteLine(car1.speed);
            //Vector3 v1 = new Vector3();
            //v1.x = 1;
            //v1.y = 1;
            ////v1.z = 1;
            //v1.SetX(1);
            //v1.SetY(1);
            //v1.SetZ(1);
            Vector3 v1 = new Vector3(1,1,1);
            //Console.WriteLine(v1.Length());

            //使用属性
            //v1.MyIntProperty = 600;//对属性设置值
            //int temp = v1.MyIntProperty;//对属性取值
            //Console.WriteLine(temp);
            //v1.X = 100;
            //Console.WriteLine(v1.X);
            v1.Name = "siki";
            Console.WriteLine(v1.Name);
            Console.ReadKey();
        }
    }
}
