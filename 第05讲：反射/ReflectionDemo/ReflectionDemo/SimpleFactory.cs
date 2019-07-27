using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Configuration;

namespace ReflectionDemo
{
    public class SimpleFactory
    {

        private static string typeName = ConfigurationManager.AppSettings["TypeName"].ToString();

        public static IQueryService GetEntity()
        {
            return (IQueryService)Assembly.Load("ReflectionDemo").CreateInstance(typeName);
        }
    }
}
