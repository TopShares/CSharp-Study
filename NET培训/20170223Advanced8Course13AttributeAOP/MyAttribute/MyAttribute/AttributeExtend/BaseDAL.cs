using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    public class BaseDAL
    {
        /// <summary>
        /// 校验而且保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Save<T>(T t)
        {
            bool isSafe = true;

            Type type = t.GetType();

            foreach (var property in type.GetProperties())
            {
                object[] oAttributeList = property.GetCustomAttributes(true);
                foreach (var item in oAttributeList)
                {
                    if (item is IntValidateAttribute)
                    {
                        IntValidateAttribute attribute = item as IntValidateAttribute;
                        isSafe = attribute.Validate((int)property.GetValue(t));
                    }
                }
                if (!isSafe)
                    break;
            }

            if (isSafe)
                Console.WriteLine("保存到数据库");
            else
                Console.WriteLine("数据不合法");
        }
    }
}
