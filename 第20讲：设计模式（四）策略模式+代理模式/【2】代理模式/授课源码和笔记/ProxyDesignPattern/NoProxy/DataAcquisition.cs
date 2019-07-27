using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoProxy
{
    public class DataAcquisition : IDataAcquisition
    {
        public string[] Read()
        {
            //实际开发中，在这里完成其他系统的数据接口


            //。。。
            return new string[] { "data1", "data2" };
        }

        public int Write(string[] data)
        {
            //实际开发中，在这里完成其他系统的数据接口


            return 1;
        }
    }
}
