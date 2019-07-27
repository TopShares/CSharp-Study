using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    /// <summary>
    /// 表达式应用的新特性
    /// </summary>
    class ExpressionApp
    {

        //【1】表达式属性：只有一个get访问器的单行属性可以使用lambda语法编写

        public DateTime Birthday { get; set; } = Convert.ToDateTime("1990-1-10");

        //public int Age
        //{
        //    get { return DateTime.Now.Year - Birthday.Year; }
        //}
        public int Age => DateTime.Now.Year - Birthday.Year;

        //【2】表达式方法：只有一条语句的方法可以使用lambda语法编写
        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}

        public int Add(int a, int b) => a + b;
    }
}
