using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritancePolymorphism
{
    class Program
    { 
        //static void Main(string[] args)
        //{
        //    //创建一只狗和一只猫
        //    Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
        //    Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");
        //    //将子类对象添加的父类集合
        //    List<Animal> list = new List<Animal>();
        //    list.Add(objCat);
        //    list.Add(objDog);
        //    //取出子类对象
        //    foreach (Animal obj in list)
        //    {
        //        obj.Have();
        //    }
        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            //创建一只狗和一只猫
            Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
            Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");
            //调用方法，传递子类对象
            Test(objCat);
            Test(objDog);
            Console.ReadLine();
        }
        static void Test(Animal objAnimal)//以父类作为参数
        {
            objAnimal.Have();
        }

    }
}
