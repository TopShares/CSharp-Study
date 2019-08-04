using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Domain
{
    /// <summary>
    /// 用户这个聚合根的仓储接口
    /// </summary>
    public interface IUserRepository:IRepository<TB_USERS>
    {
        IEnumerable<TB_USERS> GetUsersByRole(TB_ROLE oRole);
    }
}
