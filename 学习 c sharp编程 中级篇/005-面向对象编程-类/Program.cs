using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_面向对象编程_类 {
    class Program {
        static void Main(string[] args) {
            //1，如果要使用一个类的话 要先引入它所在的命名空间，因为customer位于当前的命名空间下，所以不需要引入，我们可以直接使用Customer
            
            Customer customer1;//在这里我们使用Customer模板，声明了一个变量（对象）
            customer1　= new Customer();//对对象初始化 需要使用new加上类名
            customer1.name = "siki";//我们自己定义的类声明的对象，需要先进行初始化，才能使用 
            Console.WriteLine(customer1.name);
            customer1.Show();//使用对象中的方法
            Console.ReadKey();
        }
    }
}
