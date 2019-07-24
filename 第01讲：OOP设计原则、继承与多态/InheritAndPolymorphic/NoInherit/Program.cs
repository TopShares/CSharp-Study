using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoInherit
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一只狗和一只猫
            Cat objCat = new Cat() { Name = "球球儿", Color = "黄色", Kind = "小花猫", Favorite = "小鱼" };
            Dog objDog = new Dog() { Name = "棒棒", Color = "黑色", Kind = "小黑狗", Favorite = "排骨" };
            Console.WriteLine("主人要求她们做自我介绍......");
            Console.WriteLine();
            //调用各自的方法
            objCat.Introduce();
            objDog.Introduce();
            Console.WriteLine();
            Console.WriteLine("主人要求她们表演节目......");
            objCat.Dancing();
            objDog.Race();
            Console.ReadLine();
        }
    }
}
