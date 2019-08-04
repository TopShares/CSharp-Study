using ExpressionDemo.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ExpressionVisitorTest
    {
        public static void Show()
        {
            {
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;

                OperationsVisitor visitor = new OperationsVisitor();
                //visitor.Visit(exp);
                Expression expNew = visitor.Modify(exp);
            }
            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Id > 5 
                                                         && x.Name.StartsWith("1")
                                                         && x.Name.EndsWith("1")
                                                         && x.Name.Contains("1");

                string sql = string.Format("Delete From [{0}] WHERE {1}"
                    , typeof(People).Name
                    , " [Age]>5 AND [ID] >5"
                    );
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 || (x.Name == "A" && x.Id > 5);
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {
                Expression<Func<People, bool>> lambda = x => (x.Age > 5 || x.Name == "A") && x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }





        }
    }
}
