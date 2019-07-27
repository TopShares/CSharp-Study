using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod2
{
 
    public class ProductBProcess : AbstractTemplate
    {
        public ProductBProcess(string productName)
            : base(productName)
        {
            //可以初始化其他内容...
        }
        public override void Process3()
        {
            base.Process3();
            Console.WriteLine($"{base.productName} 执行流程3的特殊加工工序...");
            //在这里执行...
        }
        public override void Process4()
        {
            base.Process4();
            Console.WriteLine($"{base.productName} 执行流程4的特殊加工工序...");
            //在这里执行...
        }
    }
}
