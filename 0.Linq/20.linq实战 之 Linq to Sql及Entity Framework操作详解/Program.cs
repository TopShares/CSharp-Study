using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DatamipEntities entity = new DatamipEntities();

            //entity.Product.Add(new Product() { ProductID=9, ProductName="商品9" });

            //entity.SaveChanges();

            var query = from p in entity.Product
                        join o in entity.Order
                        on p.ProductID equals o.ProductID
                        select new { ProductID=p.ProductID, OrderTitle=o.OrderTitle };

            var list = query.ToList();
        }
    }
}
