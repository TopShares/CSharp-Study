using ESTM.Common.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.WCF.Service
{
    /// <summary>
    /// 产品管理模块接口契约
    /// </summary>
    [ServiceContract]
    [ServiceInterface]
    public interface IProductWCFService
    {
        [OperationContract]
        IList<DTO_TP_PRODUCT> GetAllProduct();
    }
}
