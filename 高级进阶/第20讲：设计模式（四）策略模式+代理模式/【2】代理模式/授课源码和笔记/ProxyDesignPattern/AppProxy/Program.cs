using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建代理类对象（实际开发中，代理类可以和相关的接口、实现类放到一个独立的模块中，任何的变化
            //都不会影响到客户端的使用
            //如果不使用代理类，客户端就得需要明确知道接口、接口实现类，而现在客户端只需要关系代理类就可以了。

            Proxy newProxy = new Proxy();

            Console.WriteLine(newProxy.Read().Length);

            newProxy.Write(null);

            Console.Read();
        }
    }
}
