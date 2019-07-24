using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildClassAndSuperClass
{
    class Program
    {  
        static void Main(string[] args)
        {
            //创建一只狗和一只猫
            Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
            Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");
            //将子类对象添加的父类集合
            List<Animal> list = new List<Animal>();
            list.Add(objCat);
            list.Add(objDog);
            //取出子类对象
            foreach (Animal obj in list)
            {
                if (obj is Cat)
                    ((Cat)obj).Have();
                else if (obj is Dog)
                    ((Dog)obj).Have();
            }
            Console.ReadLine();
        }
    }
}
