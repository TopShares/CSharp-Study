using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP1
{
    public class ITEngineer
    {
        public string Name { get; set; }

        //面向细节编程：针对具体的对象实现编程
        public void BeginTrainingPartOne(CoursePartOne course)
        {
            course.Attend();
            course.SubmitHomework();
            course.Exam();
        }
        public void BeginTrainingPartTwo(CoursePartTwo course)
        {
            course.Attend();
            course.SubmitHomework();
            course.Exam();
        }
        public void BeginTrainingPartThree(CoursePartThree course)
        {
            course.Attend();
            course.SubmitHomework();
            course.Exam();
        }

    }
}
