using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.BLL
{
    /// <summary>
    /// 数据库查询
    /// </summary>
    public class DBHelper
    {
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is {0} Query", typeof(DBHelper));
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }

            return new List<T>()
            {
                default(T),default(T),default(T),default(T)
            };
            
        }

    }
}
