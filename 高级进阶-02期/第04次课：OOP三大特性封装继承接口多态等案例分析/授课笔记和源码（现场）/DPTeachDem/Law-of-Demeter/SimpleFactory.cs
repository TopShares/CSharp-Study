using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Configuration;

namespace Law_of_Demeter
{
    public class SimpleFactory
    {
        //配置用户的需求
        private static string printType = ConfigurationManager.AppSettings["printType"].ToString();

        public static IPrinter CreatePrinter()
        {
            return (IPrinter)Assembly.Load("Law-of-Demeter").CreateInstance("Law_of_Demeter." + printType);
        }
    }
}
