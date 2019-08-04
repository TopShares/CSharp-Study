using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ruanmou.Framework
{
    public class StaticConstant
    {
        public static string IndexPath = string.IsNullOrEmpty(ConfigurationManager.AppSettings["IndexPath"]) ? @"D:\data\Index\" : ConfigurationManager.AppSettings["IndexPath"];
        public static string DataPath = string.IsNullOrEmpty(ConfigurationManager.AppSettings["DataPath"]) ? @"D:\data\Index\" : ConfigurationManager.AppSettings["DataPath"];
    }
}
