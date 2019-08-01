using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using System.IO;
using NHibernate.Cfg;
using NhibernateShow.Model;

namespace NHibernateDemo
{
    /// <summary>
    /// 1  作业讲解
    /// 2  ORM介绍
    /// 3  NHibernate配置和访问
    /// 4  NHibernate数据访问基类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今晚学习ORM和NHibernate");
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MSSQL.cfg.config");
                Configuration config = new Configuration().Configure(path);

                ISessionFactory iSessionFactory = config.BuildSessionFactory();
                using (ISession session = iSessionFactory.OpenSession())
                {
                    User user = session.Get<User>(2);
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
