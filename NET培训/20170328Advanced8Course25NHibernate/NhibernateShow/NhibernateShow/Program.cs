using NHibernate;
using NHibernate.Cfg;
using NhibernateShow.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateShow
{
    class Program
    {
        static void Main(string[] args)
        {

            {

                //ISession iSession = NhibernateFactory.CreateSession();

                //User user = iSession.Get<User>(7);

                //user.CustomName = "Tibbers1";


                //iSession.SaveOrUpdate(user);
                //iSession.Flush();


                ////iSession.Delete(user);
                ////iSession.Flush();
                //IList<User> userList = iSession.QueryOver<User>().Where(u => u.Id > 3).List();
            }
            {

                BaseDAL baseDAL = new BaseDAL();


                User user = baseDAL.Get<User>(5);
                baseDAL.ExecuteSql("");
                //var list1= baseDAL.GetListBySql<User>("SELECT * FROM [USER] WHERE ID>100;");

                var list3 = baseDAL.GetCustomerListByType<User>(131);
                var list4 = baseDAL.CreateCriteria<User>(131);

                //var list2 = baseDAL.List<User>();
                //foreach (var item in list2)
                //{
                //    Console.WriteLine(item.CustomName);
                //}
                var list2 = baseDAL.QueryList<User>(u => u.Id > 100);
                foreach (var item in list2)
                {
                    Console.WriteLine(item.CustomName);
                }
            }
            Console.Read();

        }
    }
}
