using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProxy
{
    /// <summary>
    /// 代理类：也必须要实现接口
    /// </summary>
    public class Proxy : IDataAcquisition
    {
        //通过接口和实现类组合(这个地方可以通过反射完成)
        IDataAcquisition adapter = new DataAcquisition();
        public string[] Read()
        {
            return adapter.Read();
        }

        public int Write(string[] data)
        {
            return adapter.Write(data);
        }
    }
}
