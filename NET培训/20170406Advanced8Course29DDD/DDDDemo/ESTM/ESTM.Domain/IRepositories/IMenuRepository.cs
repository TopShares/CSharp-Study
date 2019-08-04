using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Domain
{
    /// <summary>
    /// 菜单这个聚合根的仓储接口
    /// </summary>
    public interface IMenuRepository:IRepository<TB_MENU>
    {
        IQueryable<TB_MENU> GetMenusByRole(TB_ROLE oRole);
    }
}
