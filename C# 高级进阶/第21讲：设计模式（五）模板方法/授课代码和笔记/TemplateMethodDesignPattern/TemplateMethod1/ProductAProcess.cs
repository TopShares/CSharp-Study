using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod1
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductAProcess
    {
        private string productName;

        public ProductAProcess(string productName)
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

        //这个是A产品特殊的加工过程
        public void Process3()
        {
            Console.WriteLine($"{productName}加工流程3在运行...");
            //执行其他操作...(该操作是自己独有的)

        }
        public void Process4()
        {
            Console.WriteLine($"{productName}加工流程4在运行...");
            //执行其他操作...(该操作是自己独有的)

        }

    }
}
