using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod2
{
    /// <summary>
    /// 抽象类：就是一个抽象模板，定义并实现了一个模板方法
    /// </summary>
    public abstract class AbstractTemplate
    {
        protected string productName;

        public AbstractTemplate(string productName)
        {
            this.productName = productName;
        }

        public void Process1()
        {
            //执行其他操作...

            Console.WriteLine("加工流程1在运行...");
        }
        public void Process2()
        {
            //执行其他操作...

            Console.WriteLine("加工流程2在运行...");
        }

        //这个是产品特殊的加工过程
        public virtual void Process3()
        {
            Console.WriteLine($"{productName}加工流程3在运行...");
        }
        public virtual void Process4()
        {
            Console.WriteLine($"{productName}加工流程4在运行...");
        }

        //还可以在这里增加抽象方法...

        /// <summary>
        /// 增加一个过程执行逻辑
        /// 模板方法通常会有一个逻辑执行的骨架，而逻辑的组成可以是具体操作，也可以是抽象操作
        /// 如果是抽象操作，会推迟到子类实现
        /// </summary>
        public void ProcessLogic()
        {
            Process1();
            Process2();
            Process3();
            Process4();
        }
    }
}
