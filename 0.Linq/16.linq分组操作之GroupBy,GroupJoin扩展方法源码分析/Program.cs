using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>()
            {
                new Product() { ProductID=1, ProductName="商品1" },
                new Product() { ProductID=2, ProductName="商品2" }
            };

            var orderList = new List<Order>()
            {
                new Order() { OrderID=100001, OrderName="订单1", ProductID=1 },
                new Order() { OrderID=100002, OrderName="订单2", ProductID=2 },
                new Order() { OrderID=100003, OrderName="订单3", ProductID=1 }
            };

            //我想看一下 每一个商品的订单数。 

            /*
             *   商品1： ordercount：2
             *   商品2： ordercount：1
             */
            var query = from p in productList
                        join o in orderList
                        on p.ProductID equals o.ProductID
                        into grp
                        select new
                        {
                            ProductName = p.ProductName,
                            OrderCount = grp.Count()
                        };
        }
    }

    public class Order
    {
        public int OrderID { get; set; }

        public string OrderName { get; set; }

        public int ProductID { get; set; }

    }

    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
    }
}