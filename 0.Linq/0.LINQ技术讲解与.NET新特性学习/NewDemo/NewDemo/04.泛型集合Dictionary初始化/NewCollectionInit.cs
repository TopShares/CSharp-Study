using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo
{
    /// <summary>
    /// 泛型集合的新初始化方法
    /// </summary>
    class NewCollectionInit
    {
        public Dictionary<string, int> OldMethod()
        {
            Dictionary<string, int> student = new Dictionary<string, int>();
            student.Add("张三", 25);
            student.Add("李四", 34);
            student.Add("王五", 26);
            return student;
        }
        //新的初始化方法
        public Dictionary<string, int> NewMethod()
        {
            Dictionary<string, int> student = new Dictionary<string, int>()
            {
                ["张三"] = 25,
                ["李四"] = 34,
                ["王五"] = 26
            };
            return student;
        }
    }
}
