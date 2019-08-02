using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_面向对象编程_继承 {
    class Crow:Bird {//我们继承了一个抽象类的时候，必须去实现抽象方法
        public override void Fly()
        {
            Console.WriteLine("乌鸦在飞行");
        }
    }
}
