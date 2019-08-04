using ESTM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    [Export(typeof(IUserRoleRepository))]
    public class UserRoleRepository : EFBaseRepository<TB_USERROLE>, IUserRoleRepository
    {
    }
}
