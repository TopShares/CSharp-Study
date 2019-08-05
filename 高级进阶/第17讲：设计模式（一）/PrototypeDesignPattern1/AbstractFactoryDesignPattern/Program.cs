using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBLInterface;
using Models;

namespace AbstractFactoryDesignPattern
{
    //抽象工厂设计模式
    //解决的问题：这一组对象的创建和选择问题
    //场景：当我们根据需要设计了一个接口库，这个接口库里面有很多的接口类。
    //我们根据不同的需求，做了不同的接口实现类库
    //用户就要根据需要选择其中的一组来使用

    //通常情况下，我们如果根据需要设计一组接口，可能在项目中直接实现这个接口就行了。
    //对象的创建，不仅延迟，而且需要我们做出选择。
    //在相关的参考书籍中，我们经常会看到抽象工厂通常以多数据库访问问题为例讲解。




    class Program
    {
        static void Main(string[] args)
        {
            //IStudentLogic student = new StudentLogicImpl();
            //ITeacherLogic teacher = new TeacherLogicImpl();

            ////....

            //通过抽象工厂，反射我们需要的类

            IStudentLogic studentLogic = BLFacotry.ProductCreator.CreateLogicClass<IStudentLogic>("StudentLogicImpl");

            Console.WriteLine(studentLogic.QueryList("")[0].StudentName);

            Console.Read();
        }
    }
}
