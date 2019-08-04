using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 表达式目录树
    /// </summary>
    public class ExpressionTest
    {
        public static void Show()
        {
            {
                Func<int, int, int> func = (m, n) => m * n + 2;
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;//lambda表达式声明表达式目录树
                //Expression<Func<int, int, int>> exp1 = (m, n) =>
                //    {
                //        return m * n + 2;
                //    };


                //表达式目录树：语法树，或者说是一种数据结构
                int iResult1 = func.Invoke(12, 23);
                int iResult2 = exp.Compile().Invoke(12, 23);
            }
            {
                //自己拼装表达式目录树
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");//m
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");//n
                BinaryExpression binaryExpression = Expression.Multiply(parameterExpression, parameterExpression2);//m*n
                ConstantExpression constantExpression = Expression.Constant(2, typeof(int));//2
                BinaryExpression binaryExpressionAdd = Expression.Add(binaryExpression, constantExpression);//M*N+2
                Expression<Func<int, int, int>> exp = Expression.Lambda<Func<int, int, int>>(binaryExpressionAdd, new ParameterExpression[]
			    {
			    	parameterExpression, 
			    	parameterExpression2
			    });

                int iResult2 = exp.Compile().Invoke(12, 23);
            }
            {
                ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");//左边
                ParameterExpression paraRight = Expression.Parameter(typeof(int), "b");//右边
                BinaryExpression binaryLeft = Expression.Multiply(paraLeft, paraRight);//a*b
                ConstantExpression conRight = Expression.Constant(2, typeof(int));//右边常量
                BinaryExpression binaryBody = Expression.Add(binaryLeft, conRight);//a*b+2

                //只能执行表示Lambda表达式的表达式目录树，即LambdaExpression或者Expression<TDelegate>类型。如果表达式目录树不是表示Lambda表达式，需要调用Lambda方法创建一个新的表达式
                Expression<Func<int, int, int>> lambda =
                    Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);
                Func<int, int, int> func = lambda.Compile();//Expression Compile成委托
                int result = func(3, 4);
            }
            {
                //常量
                ConstantExpression conLeft = Expression.Constant(345);
                ConstantExpression conRight = Expression.Constant(456);
                BinaryExpression binary = Expression.Add(conLeft, conRight);//添加方法的
                Expression<Action> actExpression = Expression.Lambda<Action>(binary, null);
                actExpression.Compile()();//()=>345+456
            }

            {
                string sql = "SELECT * FROM uSER WHERE 1=1";
                if (true) sql += " and ";
                if (true) sql += " and ";

                IQueryable<int> list = null;



                //if (true) list = list.Where(i => i > 5);
                //if (true) list = list.Where(i => i > 5);

                if (true)
                {
                    Expression<Func<int, bool>> exp1 = x => x > 1;
                }
                if (true)
                {
                    Expression<Func<int, bool>> exp2 = x => x > 2;
                }
                Expression<Func<int, bool>> exp3 = x => x > 1 && x > 2;


                //list.Where()

                //拼装表达式目录树，交给下端用
                //Expression<Func<People, bool>> lambda = x => x.Age > 5;
                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");
                //Expression property = Expression.Property(parameterExpression, typeof(People).GetProperty("Age"));
                Expression property = Expression.Field(parameterExpression, typeof(People).GetField("Id"));
                ConstantExpression constantExpression = Expression.Constant(5, typeof(int));
                BinaryExpression binary = Expression.GreaterThan(property, constantExpression);//添加方法的
                Expression<Func<People, bool>> lambda = Expression.Lambda<Func<People, bool>>(binary, new ParameterExpression[]
			    {
			    	parameterExpression
			    });
                bool bResult = lambda.Compile()(new People()
                {
                    Id = 11,
                    Name = "打兔子的猎人",
                    Age = 28
                });
            }
            {
                //Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");
                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");
                Expression field = Expression.Field(parameterExpression, typeof(People).GetField("Id"));
                MethodCallExpression toString = Expression.Call(field, typeof(People).GetMethod("ToString"), new Expression[0]);
                ConstantExpression constantExpression = Expression.Constant("5", typeof(string));

                MethodCallExpression equals = Expression.Call(toString, typeof(People).GetMethod("Equals"), new Expression[] { constantExpression });
                Expression<Func<People, bool>> lambda = Expression.Lambda<Func<People, bool>>(equals, new ParameterExpression[]
			    {
			    	parameterExpression
			    });
                bool bResult = lambda.Compile()(new People()
                {
                    Id = 11,
                    Name = "打兔子的猎人",
                    Age = 28
                });
            }
            {
                People people = new People()
               {
                   Id = 11,
                   Name = "打兔子的猎人",
                   Age = 28
               };
                PeopleCopy peopleCopy = new PeopleCopy()
                {
                    Id = people.Id,
                    Name = people.Name,
                    Age = people.Age
                };
                PeopleCopy peopleCopy1 = Trans<People, PeopleCopy>(people);


                //Expression<Func<People, PeopleCopy>> lambda = p =>
                //        new PeopleCopy()
                //        {
                //            Id = p.Id,
                //            Name = p.Name,
                //            Age = p.Age
                //        };
                //lambda.Compile()(people);

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(PeopleCopy).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(People).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(PeopleCopy).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(People).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(PeopleCopy)), memberBindingList.ToArray());
                Expression<Func<People, PeopleCopy>> lambda = Expression.Lambda<Func<People, PeopleCopy>>(memberInitExpression, new ParameterExpression[]
                {
                parameterExpression
                });
                Func<People, PeopleCopy> func = lambda.Compile();//拼装是一次性的

                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(people);
                TransExp<People, PeopleCopy>(new People()
                {
                    Id = 12,
                    Name = "小雨天",
                    Age = 26
                });



            }

            #region 表达式链接
            {
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);
                Expression<Func<People, bool>> lambda5 = lambda1.Not();
                Do1(lambda3);
                Do1(lambda4);
                Do1(lambda5);
            }
            #endregion

        }

        private static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        private static TOut TransExp<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("funckey_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
                {
                parameterExpression
                });
                Func<TIn, TOut> func = lambda.Compile();//拼装是一次性的

                _Dic[key] = func;
            }
            return ((Func<TIn, TOut>)_Dic[key]).Invoke(tIn);
        }

        private static TOut Trans<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                foreach (var itemIn in tIn.GetType().GetProperties())
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                        break;
                    }
                }
            }
            foreach (var itemOut in tOut.GetType().GetFields())
            {
                foreach (var itemIn in tIn.GetType().GetFields())
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                        break;
                    }
                }
            }
            return tOut;
        }


        #region PrivateMethod
        private static void Do(Func<int, int, int> func)
        {
            func(1, 2);
        }

        private static void Do1(Func<People, bool> func)
        {
            List<People> people = new List<People>();
            people.Where(func);
        }
        private static void Do1(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            List<People> peopleList = people.Where(func.Compile()).ToList();
        }

        private static IQueryable<People> GetQueryable(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            return people.AsQueryable<People>().Where(func);
        }
        #endregion
    }
}
