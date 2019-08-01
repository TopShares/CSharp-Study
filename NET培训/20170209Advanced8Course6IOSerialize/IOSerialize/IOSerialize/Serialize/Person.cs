using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize.Serialize
{
    [Serializable]  //必须添加序列化特性
    public class Person
    {
        [NonSerialized]
        public int Id = 1;

        public string Name { get; set; }
        
        public string Sex { get; set; }
    }

    [Serializable]  //必须添加序列化特性
    public class Programmer : Person
    {
        private string Language { get; set; }//编程语言
        public string Description { get; set; }
    }
}
