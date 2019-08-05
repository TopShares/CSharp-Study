using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            //while(reader.Read())
            //{
            //    objectList.Add(new newObject
            //    {
            //        p1 = reader[""].Tostring(),
            //    })
            //}

            //对应高性能项目，我们在创建一个相对比较复杂的项目时候，如果这个对象频繁被以实例方式使用，
            //就要考虑，这种初始化是否影响性能

            //一个客户多次购买商品
            Customer c1 = new Customer
            {
                CustomerId = 2001,
                CustomerName = "bark",
                PhoneNumber = "13602198001",
                PurchaseRecord = ".NET全栈开发课程"
            };
            c1.ShowCustomerInfo();

            Customer c2 = new Customer
            {
                CustomerId = 2001,
                CustomerName = "bark",
                PhoneNumber = "13602198001",
                PurchaseRecord = ".NET高级进阶课程"
            };
            c2.ShowCustomerInfo();

            Customer c3 = new Customer
            {
                CustomerId = 2001,
                CustomerName = "bark",
                PhoneNumber = "13602198001",
                PurchaseRecord = "微信小程序课程"
            };
            c3.ShowCustomerInfo();

            //分析：如果一个客户的信息我们填写有误，那么我们创建了多少个对象，就得修改多少次

            //引出：原型设计模式

            Console.Read();
        }
    }
}
