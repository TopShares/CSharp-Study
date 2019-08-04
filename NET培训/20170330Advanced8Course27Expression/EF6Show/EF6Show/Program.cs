//using EF6Show.CodeFirst;
using EF6Show.CodeFirstDB;
//using EF6Show.DBFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Show
{
    /// <summary>
    /// 1 dbFirst
    /// 2 codeFirst from db &&codeFirst 
    /// 3 modelFirst
    /// 4 EF的增删改查
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今晚学习EntityFramework6");
                {
                    using (CodeFirstDBContext dbContext = new CodeFirstDBContext())
                    {
                        {
                            User user = dbContext.User.Find(2);

                            var list = dbContext.User.ToList();

                            User userNew = new User()
                            {
                                Account = "Admin",
                                State = 0,
                                CompanyId = 4,
                                CompanyName = "万达集团",
                                CreateTime = DateTime.Now,
                                CreatorId = 1,
                                Email = "57265177@qq.com",
                                LastLoginTime = null,
                                LastModifierId = 0,
                                LastModifyTime = DateTime.Now,
                                Mobile = "18664876671",
                                Name = "yoyo",
                                Password = "12356789",
                                UserType = 1
                            };
                            dbContext.User.Add(userNew);
                            dbContext.SaveChanges();

                            userNew.Name = "安德鲁";
                            dbContext.SaveChanges();

                            dbContext.User.Remove(userNew);
                            dbContext.SaveChanges();
                        }

                        {
                            DbContextTransaction trans = dbContext.Database.BeginTransaction();
                            dbContext.User.Find(2);

                            dbContext.Database.SqlQuery<User>("SELECT * FROM [USER] WHERE ID=@id", new SqlParameter("@id", 2)).ToList();

                            int iRQesult = dbContext.Database.ExecuteSqlCommand("UPDATE [USER] SET NAME=@name WHERE ID=@id"
                                , new SqlParameter("@name", "Kobe")
                                , new SqlParameter("@id", 2));
                            trans.Commit();
                        }

                        {
                            var list = dbContext.User.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id));

                            list = list.Where(v => v.Id < 5);
                            list = list.OrderBy(v => v.Id);

                            foreach (var user in list)
                            {
                                Console.WriteLine(user.Name);
                            }
                        }
                        {
                            var list = from u in dbContext.User
                                       where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id)
                                       select u;

                            foreach (var user in list)
                            {
                                Console.WriteLine(user.Name);
                            }
                        }
                        {
                            var list = dbContext.User.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id))
                                                      .Select(u => new
                                                      {
                                                          Account = u.Account,
                                                          Pwd = u.Password
                                                      });
                            foreach (var user in list)
                            {
                                Console.WriteLine(user.Pwd);
                            }
                        }
                        {
                            var list = from u in dbContext.User
                                       where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id)
                                       select new
                                       {
                                           Account = u.Account,
                                           Pwd = u.Password
                                       };

                            foreach (var user in list)
                            {
                                Console.WriteLine(user.Account);
                            }
                        }

                        {
                            var list = dbContext.User.Where(u => u.Name.StartsWith("小") && u.Name.EndsWith("新"))
                                                       .Where(u => u.Name.EndsWith("新"))
                                                       .Where(u => u.Name.Contains("小新"))
                                                       .OrderBy(u => u.Id);

                            foreach (var user in list)
                            {
                                Console.WriteLine(user.Name);
                            }
                        }
                        {
                            var list = from u in dbContext.User
                                       join c in dbContext.Company on u.CompanyId equals c.Id
                                       where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                                       select new
                                       {
                                           Account = u.Account,
                                           Pwd = u.Password,
                                           CompanyName = c.Name
                                       };
                            foreach (var user in list)
                            {
                                Console.WriteLine("{0} {1}", user.Account, user.Pwd);
                            }
                        }
                        {
                            var list = from u in dbContext.User
                                       join c in dbContext.Category on u.CompanyId equals c.Id
                                       into ucList
                                       from uc in ucList.DefaultIfEmpty()
                                       where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                                       select new
                                       {
                                           Account = u.Account,
                                           Pwd = u.Password
                                       };
                            foreach (var user in list)
                            {
                                Console.WriteLine("{0} {1}", user.Account, user.Pwd);
                            }
                        }




                    }
                }
                {
                    //using (DBFirstContext context = new DBFirstContext())
                    //{
                    //    User user = context.User.Find(2);

                    //    var list = context.User.ToList();

                    //    User userNew = new User()
                    //    {
                    //        Account = "Admin",
                    //        State = 0,
                    //        CompanyId = 4,
                    //        CompanyName = "万达集团",
                    //        CreateTime = DateTime.Now,
                    //        CreatorId = 1,
                    //        Email = "57265177@qq.com",
                    //        LastLoginTime = null,
                    //        LastModifierId = 0,
                    //        LastModifyTime = DateTime.Now,
                    //        Mobile = "18664876671",
                    //        Name = "yoyo",
                    //        Password = "12356789",
                    //        UserType = 1
                    //    };
                    //    context.User.Add(userNew);
                    //    context.SaveChanges();

                    //    userNew.Name = "安德鲁";
                    //    context.SaveChanges();

                    //    context.User.Remove(userNew);
                    //    context.SaveChanges();

                    //}
                }
                {
                    //using (CodeFirstContext context = new CodeFirstContext())
                    //{
                    //    User user = context.User.Find(2);

                    //    var list = context.User.ToList();

                    //    User userNew = new User()
                    //    {
                    //        Account = "Admin",
                    //        State = 0,
                    //        CompanyId = 4,
                    //        CompanyName = "万达集团",
                    //        CreateTime = DateTime.Now,
                    //        CreatorId = 1,
                    //        Email = "57265177@qq.com",
                    //        LastLoginTime = null,
                    //        LastModifierId = 0,
                    //        LastModifyTime = DateTime.Now,
                    //        Mobile = "18664876671",
                    //        Name = "yoyo",
                    //        Password = "12356789",
                    //        UserType = 1
                    //    };
                    //    context.User.Add(userNew);
                    //    context.SaveChanges();

                    //    userNew.Name = "安德鲁";
                    //    context.SaveChanges();

                    //    context.User.Remove(userNew);
                    //    context.SaveChanges();

                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
