using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            // This expression adds the values of its two arguments.
            // Both arguments must be of the same type.
            Expression sumExpr = Expression.Add(
                Expression.Constant(1),
                Expression.Constant(2)
            );

            // Print out the expression.
            Console.WriteLine(sumExpr.ToString());

            var func = Expression.Lambda<Func<int>>(sumExpr).Compile();

            var i = func();

            //Console.WriteLine(Expression.Lambda<Func<int>>(sumExpr).Compile()());


            // select * from xxxTable where i ==2

            ////我们就看到了，Expression 将 func装到了自己的口袋里
            //Expression<Func<int, bool>> exp = i => i == 2;

            ////将func函数从Expression中取出来。
            //var func = exp.Compile();

            //var b = func(10);


            DatamipEntities entity = new DatamipEntities();

            entity.Product.Add(new Product() { ProductID = 9, ProductName = "商品9" });

            ////entity.SaveChanges();

            //var query = from p in entity.Product
            //            join o in entity.Order
            //            on p.ProductID equals o.ProductID
            //            select new { ProductID=p.ProductID, OrderTitle=o.OrderTitle };

            //var list = query.ToList();
        }
    }
}
