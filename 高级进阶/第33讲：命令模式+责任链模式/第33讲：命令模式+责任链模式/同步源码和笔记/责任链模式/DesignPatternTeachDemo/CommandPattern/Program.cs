using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //命令接收者
            CommandReceiver receiver = new CommandPattern.CommandReceiver();

            //具体命令
            ICommand command1 = new Method1Command(receiver);
            command1.CommandStatus = 1;

            ICommand command2 = new Method2Command(receiver);
            command2.CommandStatus = 1;

            ICommand command3 = new Method3Command(receiver);
            command3.CommandStatus = 0;

            //命令激发者（发布者）添加需要的命令
            CommandInvoker invoker = new CommandPattern.CommandInvoker();
            invoker.SetCommand(command1);
            invoker.SetCommand(command2);
            invoker.SetCommand(command3);


            //撤销命令
            invoker.CancelCommand(command1);


            //告诉命令接收者，批量执行命令
            invoker.ExcuteCommand();

            Console.Read();

        }
    }
}
