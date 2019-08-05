using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP2
{
    /// <summary>
    /// 课程的公共内容
    /// </summary>
    public abstract class AbstractCourse
    {
        public string CourseName { get; set; } 
        public string TeacherName { get; set; }
        public int Period { get; set; }

        public abstract void Attend();

        public abstract void SubmitHomework();

        public abstract void Exam();
     
    }

}
