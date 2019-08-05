using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 命令接口
    /// </summary>
    public interface ICommand
    {
        int CommandStatus { get; set; }
        void DoWork();

    }
}
