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
    /// 权限管理模块接口契约
    /// </summary>
    [ServiceContract]
    [ServiceInterface]
    public interface IPowerManageWCFService
    {
        [OperationContract]
        IList<DTO_TB_MENU> GetMenusByRole();
    }
}
