using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRelationShips
{
  public   class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        //多对多
        public ICollection<Student> Student { get; set; }

    }
}
