using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------【里氏替换原则】-------------------------------");

            //父类类型  变量  =  new 子类（）;

            Printer myPrinter1 = new HPPrinter();

            myPrinter1.Copy();  //覆盖的方法（普通的方法）
            myPrinter1.Print();   //重写的抽象方法
            myPrinter1.Scan();  //重写的虚方法


            ////以上方法调用口诀：继承的用“父类”，重写的用“子类”
            //Console.WriteLine("-----------------------------------------------------------------------------------------------");

            ////测试1：父类普通的方法调用，如果被子类覆盖过，则方法调用，取决于反射的类型
            //typeof(Printer).GetMethod("Copy").Invoke(myPrinter1, null);
            //typeof(HPPrinter).GetMethod("Copy").Invoke(myPrinter1, null);

            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            ////测试2：父类的抽象方法，被子类重写，直接调用子类的方法
            //typeof(Printer).GetMethod("Print").Invoke(myPrinter1, null);
            //typeof(HPPrinter).GetMethod("Print").Invoke(myPrinter1, null);

            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            ////测试3：父类的虚方法，被子类重新，则调用子类的方法
            //typeof(Printer).GetMethod("Scan").Invoke(myPrinter1, null);
            //typeof(HPPrinter).GetMethod("Scan").Invoke(myPrinter1, null);

            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            //Printer myPinter2 = new CanonPrinter();
            //typeof(Printer).GetMethod("Scan").Invoke(myPinter2, null);
            //typeof(CanonPrinter).GetMethod("Scan").Invoke(myPinter2, null);

            //Console.WriteLine("-----------------------------------------------------------------------------------------------");
            //HPPrinter printer1 = new HPPrinter();
            //printer1.Copy();

            ////new关键字我们开发中，一般还是少用为好，如果必须用，通常都是直接的子类类型定义。
            ////应用场合：一般我们在控件二次开发中，如果我们需要重新写一个新的事件方法，而这个事件在父类中已经存在了，则可以使用。


            //CanonPrinter printer2 = new CanonPrinter();
            //printer2.Copy();


            Console.Read();



        }
    }
}
