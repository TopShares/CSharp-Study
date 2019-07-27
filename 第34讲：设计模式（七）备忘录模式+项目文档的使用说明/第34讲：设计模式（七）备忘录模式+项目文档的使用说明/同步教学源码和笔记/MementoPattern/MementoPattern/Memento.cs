using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    /// <summary>
    /// 备忘录
    /// </summary>
    public class Memento
    {
        //需要保存的部分数据参数，可以是N个...

        public string StateParam1 { get; set; }
        public string StateParam2 { get; set; }
        public string StateParam3{ get; set; }

    }
}
