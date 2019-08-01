using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 这里是注释，除了让人看懂这里写的是什么，对运行没有任何影响
    /// </summary>
    //[Obsolete("请不要使用这个了，请使用什么来代替", true)]
    [Serializable]
    public class People
    {
        //[Obsolete("请不要使用这个了1")]

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
