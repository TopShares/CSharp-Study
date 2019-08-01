using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateShow
{
    /// <summary>
    /// NH单例工厂
    /// </summary>
    public class NhibernateFactory
    {
        private NhibernateFactory()
        {

        }

        private static ISessionFactory iSessionFactory = null;
        static NhibernateFactory()
        {
            // 默认从 App.config,web.config或者hibernate.cfg.xml查找配置文件；  
            //var cfg = new NHibernate.Cfg.Configuration().Configure();  
            string totalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigFiles\\hibernate.cfg.config");
            Configuration configuration = new Configuration().Configure(totalPath);
            iSessionFactory = configuration.BuildSessionFactory();
        }

        /// <summary>
        /// 打开一个会话
        /// </summary>
        /// <returns></returns>
        public static ISession 
            CreateSession()
        {
            return iSessionFactory.OpenSession();
        }

    }
}
