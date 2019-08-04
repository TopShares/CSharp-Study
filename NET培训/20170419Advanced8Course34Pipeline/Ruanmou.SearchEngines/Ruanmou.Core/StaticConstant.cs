using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ruanmou.Core
{
    public class StaticConstant
    {
        /// <summary>
        /// lucene索引位置
        /// </summary>
        public static string IndexPath = ConfigurationManager.AppSettings["IndexPath"];
    }
}
