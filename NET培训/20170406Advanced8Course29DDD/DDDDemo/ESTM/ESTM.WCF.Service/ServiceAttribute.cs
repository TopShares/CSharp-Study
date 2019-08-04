using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.WCF.Service
{
    //标记此特性的为WCF服务接口
    public class ServiceInterfaceAttribute : Attribute
    {
    }

    //标记此特性的为WCF服务接口实现类
    public class ServiceClassAttribute : Attribute
    {
    }
}
