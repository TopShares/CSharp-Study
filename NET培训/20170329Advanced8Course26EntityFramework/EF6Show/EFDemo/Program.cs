
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.DBFirst;
//using EFDemo.CodeFirstFromDB;
//using EFDemo.CodeFirst;
using System.Data.Entity;
using System.Data.SqlClient;
namespace EFDemo
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
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师带来的EntityFramework6");

                using (advanced7Entities dbContext = new advanced7Entities())//是数据库映射的一个实例，同时也是一个连接
                //using (CodeFirstFromDBContext dbContext = new CodeFirstFromDBContext())
                //using (CodeFirstContext dbContext = new CodeFirstContext())
                {
                    {
                        User userNew = new User()
                        {
                            Account = "Admin",
                            State = 0,
                            CompanyId = 11,
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
                        dbContext.Users.Add(userNew);
                        //
                        dbContext.SaveChanges();


                        User user = dbContext.Users.Find(userNew.Id);
                        user.Name = "樱满集";
                        dbContext.SaveChanges();

                        dbContext.Users.Remove(user);
                        dbContext.SaveChanges();

                        var userList = dbContext.Users.Where(u => u.Id > 1);
                        foreach (var item in userList)//遍历   .ToList()
                        {
                            Console.WriteLine(item.Name);
                        }
                    }

                    //Commodity001 c1 = dbContext.Commodity001.Find(1);
                    //Commodity002 c2 = dbContext.Commodity002.Find(1);
                    //Commodity003 c3 = dbContext.Commodity003.Find(1);

                    //{
                    //    DbContextTransaction trans = dbContext.Database.BeginTransaction();
                    //    dbContext.Users.Find(2);

                    //    dbContext.Database.SqlQuery<User>("SELECT * FROM [USER] WHERE ID=@id", new SqlParameter("@id", 2));
                    //    dbContext.Database.ExecuteSqlCommand("UPDATE [USER] SET NAME=@name WHERE ID=@id"
                    //        , new SqlParameter("@name", "Kobe")
                    //        , new SqlParameter("@id", 2));
                    //    trans.Commit();
                    //}
                    {
                        var list = dbContext.Users.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id));
                        foreach (var user in list)
                        {
                            Console.WriteLine(user.Name);
                        }
                    }
                    {
                        var list = from u in dbContext.Users
                                   where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id)
                                   select u;

                        foreach (var user in list)
                        {
                            Console.WriteLine(user.Name);
                        }
                    }
                    {
                        var list = dbContext.Users.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14 }.Contains(u.Id))
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
                        var list = from u in dbContext.Users
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
                        var list = dbContext.Users.Where(u => u.Name.StartsWith("小") && u.Name.EndsWith("新"))
                                                   .Where(u => u.Name.EndsWith("新"))
                                                   .Where(u => u.Name.Contains("小新"))
                                                   .OrderBy(u => u.Id);

                        foreach (var user in list)
                        {
                            Console.WriteLine(user.Name);
                        }
                    }
                    {
                        var list = from u in dbContext.Users
                                   join c in dbContext.Companies on u.CompanyId equals c.Id
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
                    {
                        var list = from u in dbContext.Users
                                   join c in dbContext.Companies on u.CompanyId equals c.Id
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
