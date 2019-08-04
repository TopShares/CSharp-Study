using AutoMapper;
using ESTM.Common.DtoModel;
using ESTM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.WCF.Service
{
    [ServiceClass]
    public class PowerManageWCFService : IPowerManageWCFService
    {
        [Import]
        public IMenuRepository menuRepository { get; set; }

        [Import]
        public IUserRepository userRepository { get; set; }
        public IList<DTO_TB_MENU> GetMenusByRole()
        {
            IList<DTO_TB_MENU> lstRes = new List<DTO_TB_MENU>();

            //var lstRoleMenu = menuRepository.GetMenusByRole(new TB_ROLE() { ROLE_ID = "aaaa" }).ToList();

          

            return lstRes;
        }
    }
}
