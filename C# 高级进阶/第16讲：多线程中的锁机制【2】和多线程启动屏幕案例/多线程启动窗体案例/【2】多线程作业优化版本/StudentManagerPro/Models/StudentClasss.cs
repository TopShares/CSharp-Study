using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 班级对象
    /// </summary>
    [Serializable ]
    public class StudentClasss
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

    }
}
