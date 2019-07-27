using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern4
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer
            {
                CustomerId = 2001,
                CustomerName = "bark",
                PhoneNumber = "13602198001",
                PurchaseRecord = new Record
                {
                    CourseName = ".NET全栈开发课程",
                    CoursePrice = 3980
                }
            };

            //基于原型构建对象，并进一步修饰对象
            Customer c2 = (Customer)c1.Clone();
            c2.PurchaseRecord .CourseName= ".NET高级进阶课程";
            c2.PurchaseRecord.CoursePrice = 2500;

            c1.ShowCustomerInfo();
            c2.ShowCustomerInfo();

            Console.Read();

            //结果：克隆对象里面如果有引用类型的属性，那么修改的时候，原型对象属性值也会变化。
            //结论：对象浅复制--》被复制的对象的基础类型属性会完全复制，而引用类型只是地址的传递，所以新对象会和原型对象同时变化

            //解决方法：对象深复制方法--》把引用对象的变量也能够得到一个副本，而不是原有对象引用。

        }
    }
}
