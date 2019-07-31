using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    /// <summary>
    /// 管理者
    /// </summary>
    public class Caretaker
    {
        /// <summary>
        /// 关联备忘录
        /// </summary>
        public Memento Memento { get; set; }

    }
}
