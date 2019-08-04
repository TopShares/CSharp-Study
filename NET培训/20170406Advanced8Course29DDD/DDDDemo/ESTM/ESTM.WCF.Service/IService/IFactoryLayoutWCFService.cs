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
    /// 工厂布局模块接口契约
    /// </summary>
    [ServiceInterface]
    [ServiceContract]
    public interface IFactoryLayoutWCFService
    {
        [OperationContract]
        List<DTO_TM_PLANT> GetAllPlant();
    }
}
