using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorator
{
    /// <summary>
    /// 装饰器的基类
    /// 也是一个学员
    /// 因为 继承了抽象类
    /// </summary>
    public class BaseStudentDecorator : AbstractStudent
    {
        private AbstractStudent _Student = null;
        public BaseStudentDecorator(AbstractStudent student)
        {
            this._Student = student;
        }
        public override void Show()
        {
            this._Student.Show();
            //Console.WriteLine("****************");
        }
    }
}
