using Ruanmou.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.DB.Mysql
{
    /// <summary>
    /// mysql版本的
    /// </summary>
    public class DBHelper : IDBHelper
    {
        public DBHelper()
        {
            Console.WriteLine("这里是{0}的无参构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
    }
}
