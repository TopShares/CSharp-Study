using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mytest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var bird = new Bird();

            //bird.Fly();

            //var animal = new Animal();

            //animal.Fly();

            Animal animal = new Bird();

            animal.Fly();

            animal.Fly2();
        }
    }

    public abstract class Animal
    {
        public abstract void Fly();

        public virtual void Fly2()
        {
            Console.WriteLine("我是animal的方法");
        }
    }

    public class Bird : Animal
    {
        public override void Fly()
        {
            Console.WriteLine("我是  Fly   方法");
        }

        public override void Fly2()
        {
            Console.WriteLine("我是   fly2  方法");
        }
    }


    //public interface IFly
    //{
    //    void Fly();
    //}

    //public class Bird : IFly
    //{
    //    public void Fly()
    //    {
    //        Console.WriteLine("i can fly");
    //    }
    //}

    //public class Animal : IFly
    //{
    //    public void Fly()
    //    {
    //        Console.WriteLine("i am animal");
    //    }
    //}
}
