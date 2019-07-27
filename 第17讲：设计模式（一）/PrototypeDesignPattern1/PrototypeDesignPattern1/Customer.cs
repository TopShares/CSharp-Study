using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern1
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string PurchaseRecord { get; set; }//购买记录

        public void ShowCustomerInfo()
        {
            Console.WriteLine($"客户编号：{CustomerId}  客户姓名：{CustomerName}  电话号码：{PhoneNumber}  购买记录：{PurchaseRecord }");
        }
    }
}
