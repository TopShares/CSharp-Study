using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern3
{
    class Customer:ICloneable
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string PurchaseRecord { get; set; }//购买记录

        public object Clone()
        {
            return this.MemberwiseClone();//实现接口返回副本
        }

        public void ShowCustomerInfo()
        {
            Console.WriteLine($"客户编号：{CustomerId}  客户姓名：{CustomerName}  电话号码：{PhoneNumber}  购买记录：{PurchaseRecord }");
        }
    }
}
