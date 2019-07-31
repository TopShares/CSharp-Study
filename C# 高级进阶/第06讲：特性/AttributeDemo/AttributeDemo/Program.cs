using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Diagnostics;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonSQLHelper sqlHelper = new CommonSQLHelper();
            // sqlHelper.ConnString = "...";//使用这个有警告
            // sqlHelper.Update("");//添加true以后就不让使用了。


            //类特性的查找
            Teacher teacher = new Teacher();
            object[] classAttArray = teacher.GetType().GetCustomAttributes(typeof(MyCustomAttribute), true);
            foreach (var item in classAttArray)
            {
                MyCustomAttribute att = item as MyCustomAttribute;
                Console.WriteLine("Id={0}  IsNotNull={1}  Comment={2}", att.Id, att.IsNotNull, att.Comment);
            }
            Console.WriteLine("\r\n------------------------------------");

            //获取属性的特性
            PropertyInfo property = teacher.GetType().GetProperty("TeacherName");
            object[] propertyAttArray = property.GetCustomAttributes(typeof(MyCustomAttribute), true);
            foreach (var item in propertyAttArray)
            {
                MyCustomAttribute attr = item as MyCustomAttribute;
                Console.WriteLine(attr.Comment);
            }

            Console.WriteLine("\r\n------------------------------------");
            //获取数据表的别名
            Console.WriteLine("数据表的别名：" + GetDBTableName(teacher));

            Console.WriteLine("\r\n------------------------------------");
            //枚举特性
            Order order = new Order { Status = OrderStatus.Alreadypaid };
            Console.WriteLine(order.Status.GetDescription());

            TestDebug("程序出错了！");
            Console.Read();

        }

        [Conditional("DEBUG")]
        static void TestDebug(string info)
        {
            Console.WriteLine(info);
        }

        static string GetDBTableName<T>(T table)
        {
            object[] attArray = table.GetType().GetCustomAttributes(typeof(TableByNameAttribute), true);
            if (attArray == null || attArray.Length == 0)
            {
                return table.GetType().Name;
            }
            else
            {
                return ((TableByNameAttribute)attArray[0]).TableByName;
            }
        }
    }
}
