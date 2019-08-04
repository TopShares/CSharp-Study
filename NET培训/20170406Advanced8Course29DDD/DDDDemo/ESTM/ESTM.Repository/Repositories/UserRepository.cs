using ESTM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    [Export(typeof(IUserRepository))]
    public class UserRepository:EFBaseRepository<TB_USERS>,IUserRepository
    {
        
        public IEnumerable<TB_USERS> GetUsersByRole(TB_ROLE oRole)
        {
            throw new NotImplementedException();
        }
    }
}
