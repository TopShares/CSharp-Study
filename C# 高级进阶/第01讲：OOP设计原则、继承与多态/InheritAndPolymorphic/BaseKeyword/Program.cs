using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一只狗和一只猫
            Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
            Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");          
            Console.WriteLine("主人要求她们自我介绍后表演节目......");
            Console.WriteLine();
            objCat.Dancing();
            Console.WriteLine();
            objDog.Race();
            Console.ReadLine();
        }
    }
}
