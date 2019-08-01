using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public static class Extend
    {
        /// <summary>
        /// 根据类型获取表名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetTableName<T>(this T t) where T : new()
        {
            Type type = t.GetType();
            object[] oAttributeList = type.GetCustomAttributes(true);
            foreach (var item in oAttributeList)
            {
                if (item is TableAttribute)
                {
                    TableAttribute attribute = item as TableAttribute;
                    return attribute.GetTableName();
                }
            }

            return type.Name;
        }
    }
}
