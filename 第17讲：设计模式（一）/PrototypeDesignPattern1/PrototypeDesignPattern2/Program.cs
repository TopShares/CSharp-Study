using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrototypeImpl p1 = new PrototypeImpl
            {
                ObjectId = 100, ObjectName = "myObject"
            };
            PrototypeImpl p2 = (PrototypeImpl)p1.Clone();//克隆原型实现类的对象p1，得到新的实例p2

            p2.ObjectName = "1111";

            Console.WriteLine(p2.ObjectId+"   "+p2.ObjectName);

            Console.Read();

            //对象通过克隆的方式，得到原型的“副本”。这种需求，有时候还是挺常见的。

            //在.NET平台提供一个ICloneable接口。也就是说我们不需要再单独创建这样一个原型类

        }
    }
}
