using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRelationShips
{
    public class StudentClass
    {
        public int StudentClassId { get; set; }
        public string ClassName { get; set; }

        //表示一对多
        public virtual  ICollection<Student> Student { get; set; }
    }
}
