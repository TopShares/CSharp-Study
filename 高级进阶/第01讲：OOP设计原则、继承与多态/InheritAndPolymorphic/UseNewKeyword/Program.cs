using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseNewKeyword
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //创建一只狗和一只猫
        //    Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
        //    Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");          
        //    Console.WriteLine("主人要求她们自我介绍后表演节目......");
        //    Console.WriteLine();
        //    objCat.Dancing();
        //    Console.WriteLine();          
        //    objDog.Race();
        //    Console.ReadLine();
        //}

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
        //static void Main(string[] args)
        //{
        //    //创建一只狗和一只猫
        //    Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
        //    Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");
        //    //调用方法，传递子类对象
        //    Test(objCat);
        //    Test(objDog);           
        //    Console.ReadLine();
        //}
        //static void Test(Animal objAnimal)//以父类作为参数
        //{
        //    objAnimal.Have();
        //}
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
        //static void Main(string[] args)
        //{
        //    //创建一只狗和一只猫
        //    Cat objCat1 = new Cat("球球儿", "黄色", "小花猫", "小鱼");
        //    Cat objCat2 = new Cat("球球儿", "黄色", "小花猫", "小鱼");

        //    Console.WriteLine(objCat1.Equals(objCat2));

        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            //创建一只狗和一只猫
            Cat objCat = new Cat("球球儿", "黄色", "小花猫", "小鱼");
            objCat.Introduce();
            Dog objDog = new Dog("棒棒", "黑色", "小黑狗", "排骨");
            objDog.Introduce();
            Console.ReadLine();
        }
    }
}
