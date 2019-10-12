using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mytest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bird = new Bird();

            bird.Name = "燕子";

            Animal animal = bird;   // 这个地方就是把  “子类”  转换为了  “父类”

            Bird bird2 = (Bird)animal;  //我们又把  “父类”  转化为了  “子类”

            Console.WriteLine(bird2.Name);
        }
    }

    /// <summary>
    /// 父类
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
    }

    public class Bird : Animal
    {
        public void Fly()
        {

        }
    }
}
