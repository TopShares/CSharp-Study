using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProxy
{
    /// <summary>
    /// 接口类：用于代理类和客户端的对接
    /// </summary>
    public interface IDataAcquisition
    {
        string[] Read();

        int Write(string[] data);

        //在这里根据实际需要添加其他接口...
    }
}
