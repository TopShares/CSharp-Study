using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Domain
{
    [Export(typeof(IPowerManagerDomainService))]
    public class PowerManagerDomainService:IPowerManagerDomainService
    {
        private IUserRepository _userRepository = null;
        private IRoleRepository _roleRepository = null;
        private IUserRoleRepository _userroleRepository = null;


        [ImportingConstructor]
        public PowerManagerDomainService(IUserRoleRepository oUserRoleRepository)
        {
            _userroleRepository = oUserRoleRepository;
        }

        public void AssignPower(TB_USERS oUser, TB_ROLE oRole)
        {
            if (oUser == null || oRole == null)
            {
                return;
            }
            var oUserRole = _userroleRepository.Find(x => x.USER_ID == oUser.USER_ID && x.ROLE_ID == oRole.ROLE_ID).FirstOrDefault();
            if (oUserRole == null)
            {
                oUserRole = new TB_USERROLE();
                oUserRole.ROLE_ID = oRole.ROLE_ID;
                oUserRole.USER_ID = oUser.USER_ID;
                oUserRole.ID = Guid.NewGuid().ToString();
                _userroleRepository.Insert(oUserRole);
            }
        }
    }
}
