using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonThirdPattern
{
    /// <summary>
    /// 构造很麻烦  很耗资源
    /// </summary>
    public class SingletonThird
    {
        private SingletonThird()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}被构造...", this.GetType().Name);
        }

        /// <summary>
        /// 静态变量：由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        /// </summary>
        private static SingletonThird _SingletonThird = new SingletonThird();


        public static SingletonThird CreateInstance()
        {
            return _SingletonThird;
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
