using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ruanmou.Project
{
    public class EFTest
    {
        public static void Show()
        {
            #region 导航属性 延迟加载
            //Console.WriteLine("******************************************");
            //using (JDContext context = new JDContext())
            //{
            //    //var companyList = context.Set<Company>().Where(c => c.Id > 0);
            //    var companyList = context.Set<Company>().Where(c => c.Id > 0).ToList();//.ToList()直接Company都加载过来
               
            //    foreach (var company in companyList)
            //    {
            //        Console.WriteLine("Company id={0} name={1}", company.Id, company.Name);
            //    }
            //}

            //Console.WriteLine("******************************************");
            //using (JDContext context = new JDContext())
            //{
            //    //实体类型包含其它实体类型（POCO类）的属性（也可称为导航属性），且同时满足如下条件即可实列延迟加载，
            //    //1.该属性的类型必需为public且不能为Sealed；
            //    //2.属性标记为Virtual
            //    context.Configuration.LazyLoadingEnabled = true;//默认是true  针对导航属性的
            //    var companyList = context.Set<Company>().Where(c => c.Id > 0);
            //    foreach (var company in companyList)
            //    {
            //        Console.WriteLine("Company id={0} name={1}", company.Id, company.Name);
            //        foreach (var item in company.User)//这个时候才去数据库查询user
            //        {
            //            Console.WriteLine("User name={0}", item.Name);
            //        }
            //    }

            //    //作用：在您访问导航属性时，会从数据源自动加载相关实体，若实体尚未在 实体上下文对象中，则您访问的每个导航属性都会导致针对数据源执行一个单独的查询。
            //}
            //Console.WriteLine("******************************************");
            //using (JDContext context = new JDContext())
            //{
            //    context.Configuration.LazyLoadingEnabled = false;//不延迟加载,不会再次查询了
            //    var companyList = context.Set<Company>().Where(c => c.Id > 0);
            //    foreach (var company in companyList)
            //    {
            //        Console.WriteLine("Company id={0} name={1}", company.Id, company.Name);
            //        foreach (var item in company.User)//这个时候才不去数据库查询了，所以用户全是空的了
            //        {
            //            Console.WriteLine("User name={0}", item.Name);
            //        }
            //    }
            //}
            //Console.WriteLine("******************************************");
            //using (JDContext context = new JDContext())
            //{
            //    context.Configuration.LazyLoadingEnabled = false;//不延迟加载，指定Include，一次性加载出来
            //    var companyList = context.Set<Company>().Include("User").Where(c => c.Id > 0);//User.Name
            //    foreach (var company in companyList)//这个时候才去数据库查询company和user
            //    {
            //        Console.WriteLine("Company id={0} name={1}", company.Id, company.Name);
            //        foreach (var item in company.User)
            //        {
            //            Console.WriteLine("User name={0}", item.Name);
            //        }
            //    }
            //}

            ////using (JDContext context = new JDContext())//LoadProperty 手动加载
            ////{
            ////    context.Configuration.LazyLoadingEnabled = false;//不延迟加载，指定Include，一次性加载出来
            ////    var companyList = context.Set<Company>().Where(c => c.Id > 0);
            ////    foreach (var company in companyList)//这个时候才去数据库查询company和user
            ////    {
            ////        Console.WriteLine("Company id={0} name={1}", company.Id, company.Name);
            ////        foreach (var item in company.User)
            ////        {
            ////            Console.WriteLine("User name={0}", item.Name);
            ////        }
            ////    }
            ////}
            #endregion 导航属性 延迟加载

            #region 插入数据自增id

            using (JDContext context = new JDContext())//保存  TransactionScope
            {
                context.Database.Log += c => Trace.WriteLine(c);
                using (TransactionScope trans = new TransactionScope())
                {
                    Company company = new Company()
                    {
                        Name = "Test1",
                        CreateTime = DateTime.Now,
                        CreatorId = 1,
                        LastModifierId = 0,
                        LastModifyTime = DateTime.Now,
                    };
                    context.Company.Add(company);
                    context.SaveChanges();//company.id赋值了

                    User userNew = new User()
                    {
                        Account = "Admin",
                        State = 0,
                        CompanyId = company.Id,
                        CompanyName = "软谋教育",
                        CreateTime = DateTime.Now,
                        CreatorId = 1,
                        Email = "57265177@qq.com",
                        LastLoginTime = null,
                        LastModifierId = 0,
                        LastModifyTime = DateTime.Now,
                        Mobile = "18664876671",
                        Name = "つ Ｈ ♥. 花心胡萝卜",
                        Password = "12356789",
                        UserType = 1
                    };
                    context.User.Add(userNew);
                    context.SaveChanges();//userNew.id赋值了
                    trans.Complete();//提交事务
                }
            }
            using (JDContext context = new JDContext())//保存  TransactionScope
            {
                context.Database.Log += c => Trace.WriteLine(c);
                context.Configuration.LazyLoadingEnabled = false;
                Company company = new Company()
                {
                    Name = "Test1",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                };

                User userNew = new User()
                {
                    Account = "Admin",
                    State = 0,
                    CompanyId = company.Id,
                    CompanyName = company.Name,
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Email = "57265177@qq.com",
                    LastLoginTime = null,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                    Mobile = "18664876671",
                    Name = "つ Ｈ ♥. 花心胡萝卜",
                    Password = "12356789",
                    UserType = 1
                };
                company.User = new List<User>() { userNew };
                context.Company.Add(company);
                context.SaveChanges();
            }
            #endregion 插入数据自增id
        }
    }
}
