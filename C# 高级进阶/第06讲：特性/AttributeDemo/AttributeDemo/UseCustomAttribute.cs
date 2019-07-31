using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{

    //序列化[Serializable]
    public class CommonSQLHelper
    {
        [Obsolete("该属性已过时，请使用新的属性：SqlConnString")]
        public string ConnString { get; set; }

        public string SqlConnString { get; set; }

        //添加ture以后不让使用了。
        [Obsolete("该方法已过时，请使用新的方法：public int Update(string sql,SqlParameter param)", true)]
        public int Update(string sql)
        {
            return -1;
        }

        public int Update(string sql, SqlParameter param)
        {
            return -1;
        }
    }


    /// <summary>
    /// 特性：本身是一个类，必须继承自Attribute
    /// 特性放到哪里？放到元数据中，不在IL里面（元数据读取使用反射）
    /// 自定义特性的基本使用
    /// AttributeUsageAttribute：用来修饰特性的特性
    /// AttributeTargets
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property,
        AllowMultiple = true, Inherited = true)]
    //  [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public MyCustomAttribute() { }
        public MyCustomAttribute(int id)
        {
            this.Id = id;
        }
        public MyCustomAttribute(int id, bool isnotnull) : this(id)
        {
            this.IsNotNull = isnotnull;
        }
        public MyCustomAttribute(int id, bool isnotnull, string comment)
            : this(id, isnotnull)
        {
            this.Comment = comment;
        }

        public int Id { get; set; }
        public bool IsNotNull { get; set; }//是否为空
        public string Comment { get; set; }//备注

        //特性也可以添加方法
        public string GetInfo()
        {
            return $"Id={Id}  IsNotNull={IsNotNull } Comment={Comment}";
        }
    }
    /// <summary>
    /// 特性可以继承
    /// </summary>
    public class YourCustomAttribute : MyCustomAttribute
    {
        public string CourseName { get; set; }
    }

    /// <summary>
    /// 别名特性：可以用来修饰类或者属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class TableByNameAttribute : Attribute
    {
        public TableByNameAttribute(string tableByName)
        {
            this.TableByName = tableByName;
        }

        /// <summary>
        /// 提供属性访问
        /// </summary>
        public string TableByName { get; }
    }
   

    /// <summary>
    /// 为枚举增加特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
        public string Description { get; }
    }

    /// <summary>
    /// 订单状态枚举
    /// 实际开发中，可以把描述内容，放到配置文件中
    /// </summary>
    public enum OrderStatus
    {
        [Description("未付款")]
        Unpaid = 0,
        [Description("已付款")]
        Alreadypaid = 1,
        [Description("已发货")]
        delivery = 2,
        [Description("确认收货")]
        Confirm = 3
    }
    //通过扩展方法给枚举增加扩展特性的获取方法
    public static class EnumExtend
    {
        public static string GetDescription(this Enum e)
        {
            FieldInfo field = e.GetType().GetField(e.ToString());
            DescriptionAttribute att = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return att.Description;
        }
    }
}
