using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    DIP1.ITEngineer engineer = new DIP1.ITEngineer { Name = "VIP学员" };
        //    Console.WriteLine($"新学期开始啦！大家好我是学员：{engineer.Name} 我本学期参加了下面的课程：");

        //    //依赖细节编程，调用三个不同的方法，同时传递不同的对象（结果：处处都应该以具体的对象为中心，传递具体对象）
        //    engineer.BeginTrainingPartOne(new CoursePartOne());
        //    engineer.BeginTrainingPartTwo(new CoursePartTwo());
        //    engineer.BeginTrainingPartThree(new CoursePartThree());

        //    //思考，如果我们有第四阶段内容，会怎么办？
        //    //方法：增加第四阶段的课程对象，同时修改ITEngineer类，增加一个方法调用，还得在外部增加独立的方法调用。
        //    //结论：首先违背开闭原则！发现，多对象存在高度依赖！没有达到高内聚，低耦合！
        //    //另一方理解：六大原则，其实是你中有我，我中有你！细节就是变化的！

        //    //解决方案：依赖抽象编程，因为抽象是不变的（目的，把变化的封装起来）



        //    Console.Read();
        //}


        static void Main(string[] args)
        {
            DIP2.ITEngineer engineer = new DIP2.ITEngineer { Name = "VIP学员" };
            Console.WriteLine($"新学期开始啦！大家好我是学员：{engineer.Name} 我本学期参加了下面的课程：");


            //依赖抽象编程，调用的方法不变，只有参数变化，后面的参数，我们可以通过依赖注入完成，或者工厂方法，解耦。
            engineer.BeginTraining(new DIP2.CoursePartOne());
            engineer.BeginTraining(new DIP2.CoursePartTwo());
            engineer.BeginTraining(new DIP2.CoursePartThree());



            Console.Read();
        }
    }
}
