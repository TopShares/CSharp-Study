using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorator
{
    /// <summary>
    /// 具体的装饰器
    /// 也是一个学员
    /// 因为 继承了BaseStudentDecorator,也就是间接继承了抽象类
    /// </summary>
    public class StudentPayDecorator : BaseStudentDecorator
    {
        public StudentPayDecorator(AbstractStudent student)
            : base(student)//表示调用父类的带参数构造函数
        {

        }

        /// <summary>
        /// 多重override
        /// </summary>
        public override void Show()
        {
            Console.WriteLine("通过腾讯课堂在线付费报名。。。。");

            base.Show();//调用父类的show方法
            
        }
    }
}
