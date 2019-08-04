using ESTM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    [Export(typeof(IDepartmentRepository))]
    public class DepartmentRepository : EFBaseRepository<TB_DEPARTMENT>,IDepartmentRepository
    {

        
    }
}
