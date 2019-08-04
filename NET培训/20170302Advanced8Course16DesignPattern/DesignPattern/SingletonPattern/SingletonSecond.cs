using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonSecondPattern
{
    /// <summary>
    /// 构造很麻烦  很耗资源
    /// </summary>
    public class SingletonSecond
    {
        private SingletonSecond()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}被构造...", this.GetType().Name);
        }

        private static SingletonSecond _SingletonSecond = null;

        /// <summary>
        /// 静态构造函数：只能有一个，无参数的，程序无法调用
        /// 由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        /// </summary>
        static SingletonSecond()
        {
            _SingletonSecond = new SingletonSecond();
        }


        public static SingletonSecond CreateInstance()
        {
            return _SingletonSecond;
        }



        private int _i = 0;


        public void Write()
        {
            
            //Console.WriteLine("这里是write a file");
            this._i++;
        }

        public void ShowI()
        {
            Console.WriteLine(this._i);
        }

    }
}
