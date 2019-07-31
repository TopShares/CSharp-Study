using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 命令接受者：最终要执行的命令（方法）
    /// </summary>
    public class CommandReceiver
    {
        public void Method1()
        {
            Console.WriteLine("执行方法1");
        }
        public void Method2()
        {
            Console.WriteLine("执行方法2");
        }
        public void Method3()
        {
            Console.WriteLine("执行方法3");
        }
    }
}
