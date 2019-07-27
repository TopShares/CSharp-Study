using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    /// <summary>
    /// 抽象任务处理类
    /// </summary>
    public abstract class AbstractHandler
    {
        /// <summary>
        /// 继承者：供子类访问
        /// </summary>
        protected AbstractHandler superior = null;

        public void SettHandler(AbstractHandler handler)
        {
            this.superior = handler;
        }

        /// <summary>
        /// 抽象的任务处理
        /// </summary>
        /// <param name="param"></param>
        public abstract void RequstAction(int param);
    }
}
