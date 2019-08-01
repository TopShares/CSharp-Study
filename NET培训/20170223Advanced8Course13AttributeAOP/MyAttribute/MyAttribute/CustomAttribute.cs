
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 特性是一个继承或者间接继承Attribute的类
    /// 通常用attribute结尾，那么在使用的时候，可以去掉这个结尾
    /// 
    /// </summary>

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        { }

        public CustomAttribute(int id)
        { }

        public CustomAttribute(int id, string name)
        { }

        public string Remark { get; set; }

        public string Description = null;

        public void Show()
        { }
    }

    public class TableAttribute : Attribute
    {
        private string _TableName = null;

        public TableAttribute(string tableName)
        {
            this._TableName = tableName;
        }

        public string GetTableName()
        {
            return this._TableName;
        }

    }

    public class CustomChildAttribute : CustomAttribute
    {
    }

}
