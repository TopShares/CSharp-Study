using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    /// <summary>
    /// 人事经理
    /// </summary>
    public class ConcreteHandler2 : AbstractHandler
    {
        /// <summary>
        /// 具体处理者要完成的任务
        /// </summary>
        /// <param name="param"></param>
        public override void RequstAction(int param)
        {
            if (param >3 && param <= 6)
            {
                Console.WriteLine($"请假申请的天数为{param} ,人事经理同意！");
            }
            else
            {
                if (this.superior != null)
                    this.superior.RequstAction(param);
            }
        }
    }
}
