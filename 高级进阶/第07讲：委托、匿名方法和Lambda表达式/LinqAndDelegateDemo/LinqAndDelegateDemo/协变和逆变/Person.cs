using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndDelegateDemo
{
    /// <summary>
    /// 父类
    /// </summary>
    public class Person
    {
        public string NowAddress { get; set; }
        public string identityCardNo { get; set; }

    }

    public interface IPerson<in T>
    {
        string SayHello(T content);
    }

    public class Teacher<T> : IPerson<T>
    {
        public string SayHello(T content)
        {
            return "大家好我正在学习的内容是：" + content;
        }
    }
}
