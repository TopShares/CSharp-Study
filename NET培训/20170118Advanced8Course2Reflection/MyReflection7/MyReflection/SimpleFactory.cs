using Ruanmou.DB.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class SimpleFactory
    {
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelper"];

        public static IDBHelper CreateDBHelper()
        {
            string dllName = IDBHelperConfig.Split(',')[1];
            string className = IDBHelperConfig.Split(',')[0];

            Assembly assembly = Assembly.Load(dllName);
            Type type = assembly.GetType(className);
            object oObject = Activator.CreateInstance(type);
            return (IDBHelper)oObject;

        }
    }
}
