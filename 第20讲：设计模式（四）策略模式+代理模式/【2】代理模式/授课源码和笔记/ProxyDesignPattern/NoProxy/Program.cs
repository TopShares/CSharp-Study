using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoProxy
{
    class Program
    {
        //客户端
        static void Main(string[] args)
        {
            //基于接口的普通使用方法
            IDataAcquisition dataInteface = new DataAcquisition();

            Console.WriteLine(dataInteface.Read().Length);

            dataInteface.Write(null);

            Console.Read();
        }
    }
}
