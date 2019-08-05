using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP2
{
    public class ITEngineer
    {
        public string Name { get; set; }

        //面向细节编程：针对具体的对象实现编程
        //public void BeginTrainingPartOne(CoursePartOne course)
        //{
        //    course.Attend();
        //    course.SubmitHomework();
        //    course.Exam();
        //}
        //public void BeginTrainingPartTwo(CoursePartTwo course)
        //{
        //    course.Attend();
        //    course.SubmitHomework();
        //    course.Exam();
        //}
        //public void BeginTrainingPartThree(CoursePartThree course)
        //{
        //    course.Attend();
        //    course.SubmitHomework();
        //    course.Exam();
        //}
        //面向细节的不足：程序固定化，需求变化导致程序直接改动，无法扩展，也就是说上传由于下层的变化而不断变化！

        //面向抽象编程：针对抽象类和接口，实现编程
        //好处：通过抽象类或接口对象的返回，或传递，使得程序更好的扩展。
        //比如下面：当下层需求变化的时候，也就是增加课程阶段对象，而这个方法是稳定的，方法稳定对象即稳定！地基稳固。楼安全！

        public void BeginTraining(AbstractCourse course)
        {
            course.Attend();
            course.SubmitHomework();
            course.Exam();
        }

    }
}
