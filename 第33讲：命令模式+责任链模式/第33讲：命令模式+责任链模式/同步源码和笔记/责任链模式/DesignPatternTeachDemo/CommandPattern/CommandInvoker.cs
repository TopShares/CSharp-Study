using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 命令激发者（发布者，传递者）
    /// 作用：收集所有命令（就好比服务员把我们点菜的菜单收集过来），批量执行所有命令，根据需要撤销指定命令
    /// </summary>
    public class CommandInvoker
    {
        //使用集合保存批量命令（命令容器）
        private List<ICommand> commandList = new List<ICommand>();

        //将命令添加到命令集合
        public void SetCommand(ICommand command)
        {
            if (command.CommandStatus == 1)//这个命令在加入之前，必须符合要求
            {
                commandList.Add(command);
            }
            else //对于状态不对的，可以否决（因为命令加入，可以动态完成）
            {
                Console.WriteLine($"{command} 此命令当前不能执行！");
            }           
        }
        /// <summary>
        /// 批量执行命令（具体执行什么命令，我们开发的时候，根本不知道，只有运行才知道）
        /// </summary>
        public void ExcuteCommand()
        {
            foreach (var item in commandList)
            {
                item.DoWork();
            }
        }
        /// <summary>
        /// 撤销指定命令
        /// </summary>
        /// <param name="command"></param>
        public void CancelCommand(ICommand command)
        {
            this.commandList.Remove(command);
        }


    }
}
