using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonCommandPattern
{
    /// <summary>
    /// 行为的实现者
    /// </summary>
    public class Receiver
    {
        public void Method1()
        {
            Console.WriteLine("现在正在执行方法1");
        }
        public void Method2()
        {
            Console.WriteLine("现在正在执行方法2");
        }
        public void Method3()
        {
            Console.WriteLine("现在正在执行方法3");
        }
    }
}
