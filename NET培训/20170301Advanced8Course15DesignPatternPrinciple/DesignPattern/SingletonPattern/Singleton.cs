using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 构造很麻烦  很耗资源
    /// </summary>
    public class Singleton
    {
        private Singleton()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}被构造...", this.GetType().Name);
        }

        private static Singleton _Singleton = null;
        private static object Singleton_Lock = new object();
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)
            {
                lock (Singleton_Lock)
                {
                    Console.WriteLine("进入lock，wait一下");
                    Thread.Sleep(100);
                    if (_Singleton == null)
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
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
