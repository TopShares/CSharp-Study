using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            //一个客户多次购买商品
            Customer c1 = new Customer
            {
                CustomerId = 2001,
                CustomerName = "bark",
                PhoneNumber = "13602198001",
                PurchaseRecord = ".NET全栈开发课程"
            };        

            //基于原型构建对象，并进一步修饰对象
            Customer c2 = (Customer)c1.Clone();
            c2.PurchaseRecord = ".NET高级进阶课程";

            Customer c3 = (Customer)c1.Clone();
            c3.PurchaseRecord = "微信小程序课程";


            c1.ShowCustomerInfo();
            c2.ShowCustomerInfo();          
            c3.ShowCustomerInfo();

            //以上可以看出，重复内容不在出现。
            //对于性能要求高的情况下，我们每次new一个对象都会耗费时间，并且多次执行初始化操作效率也低
            //建议：一般在初始化信息不发生变化的情况下，克隆是比较好的选择。

            //因为隐藏了对象创建的细节，性能又做了提升。
            //本质：不用创建新对象，而是动态获得了对象运行时的状态。

            //请思考：前面的对象属性都是基本数据类型，如果购买记录是一个引用类型，结果会如何？


            Console.Read();
        }
    }
}
