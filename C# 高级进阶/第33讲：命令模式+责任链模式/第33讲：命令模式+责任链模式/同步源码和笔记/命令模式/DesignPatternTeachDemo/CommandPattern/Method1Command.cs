using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 具体命令（接口实现类1）：将任何接收者类中的第一个方法封装为一个命令对象
    /// </summary>
    public class Method1Command : ICommand
    {
        public CommandReceiver receiver = null;

        /// <summary>
        /// 通够构造方法，明确我们要使用任务接收者
        /// </summary>
        /// <param name="receiver"></param>
        public Method1Command(CommandReceiver receiver)
        {
            this.receiver = receiver;
        }
        public int CommandStatus { get; set; }

        /// <summary>
        /// 完成具体方法的调用
        /// </summary>
        public void DoWork()
        {
            this.receiver.Method1();
        }
    }
}
