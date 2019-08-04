using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 展示表达式树
    /// </summary>
    public class ExpressionTreeVisualizer
    {
        public static void Show()
        {
            //Expression<Func<People, bool>> lambda = x => x.Age > 5;
            //Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");
            Expression<Func<People, PeopleCopy>> lambda = p =>
                        new PeopleCopy()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Age = p.Age
                        };
        }
    }
}
