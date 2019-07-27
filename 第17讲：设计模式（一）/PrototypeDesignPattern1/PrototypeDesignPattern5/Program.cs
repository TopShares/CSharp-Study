using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PrototypeDesignPattern5
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

            //基于原型构建对象，并进一步修饰对象，将对象属性中对象类型的做克隆
            Customer c2 = (Customer)c1.Clone();
            c2.PurchaseRecord = (Record)c1.PurchaseRecord.Clone();

            c2.PurchaseRecord.CourseName = ".NET高级进阶课程";
            c2.PurchaseRecord.CoursePrice = 2500;

            c1.ShowCustomerInfo();
            c2.ShowCustomerInfo();

            //以上解决了对象内部对象克隆的问题，但是如果对象之间的关系进一步复杂，则容易出现克隆递归问题

            //其实我们可以通过对象序列化方式实现深度复制
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, c1);//就是获取对象运行时所有状态，并形成一个“内存对象”
            ms.Seek(0, SeekOrigin.Begin);

            var c3 = (Customer)bf.Deserialize(ms);
            c3.PurchaseRecord.CourseName = "微信小程序";
            c3.PurchaseRecord.CoursePrice = 1500;
            c3.ShowCustomerInfo();

            Console.Read();

            //原型模式：也就是当我考虑对象new的时候，有性能影响，为了避免直接new导致的这种性能损失，可以考虑原型模式来构建新对象
            //注意问题：对象克隆需要实现接口，如果对象只有一级对象属性，就用原型模式的基本方法。
            //对于多个深度关联的对象，可以使用内存流和序列化方法。
        }
    }
}
