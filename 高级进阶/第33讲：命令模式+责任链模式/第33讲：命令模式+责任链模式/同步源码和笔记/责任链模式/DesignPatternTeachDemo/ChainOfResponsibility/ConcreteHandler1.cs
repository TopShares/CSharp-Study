using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    /// <summary>
    /// 部门经理
    /// </summary>
    public class ConcreteHandler1 : AbstractHandler
    {
        /// <summary>
        /// 具体处理者要完成的任务
        /// </summary>
        /// <param name="param"></param>
        public override void RequstAction(int param)
        {
            //在这个地方可以根据需要添加具体的业务逻辑，我们这个地方主要是模拟一个请假
            if (param >= 1 && param <= 3)
            {
                Console.WriteLine($"请假申请的天数为{param} ,部门经理同意！");
            }
            else
            {
                if (this.superior != null)//必须保证有继承者
                    this.superior.RequstAction(param);//如果自己处理不了，则交给继承者去完成
            }
        }
    }
}
