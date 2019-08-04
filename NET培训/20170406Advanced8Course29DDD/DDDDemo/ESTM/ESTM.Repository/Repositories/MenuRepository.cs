using ESTM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    [Export(typeof(IMenuRepository))]
    public class MenuRepository:EFBaseRepository<TB_MENU>,IMenuRepository
    {
        public IQueryable<TB_MENU> GetMenusByRole(TB_ROLE oRole)
        {
            var queryrole = UnitOfWork.context.Set<TB_ROLE>().AsQueryable();
            var querymenu = UnitOfWork.context.Set<TB_MENU>().AsQueryable();
            var querymenurole = UnitOfWork.context.Set<TB_MENUROLE>().AsQueryable();
            var lstres = from menu in querymenu
                         from menurole in querymenurole
                         from role in queryrole
                         where menu.MENU_ID == menurole.MENU_ID &&
                               menurole.ROLE_ID == role.ROLE_ID &&
                               role.ROLE_ID == oRole.ROLE_ID
                         select menu;
            return lstres;
        }
    }
}
