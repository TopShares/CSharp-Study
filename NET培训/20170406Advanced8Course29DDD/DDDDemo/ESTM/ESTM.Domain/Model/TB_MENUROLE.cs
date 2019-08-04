using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Domain
{
    /// <summary>
    /// 由于不会直接操作此表，所以TB_MENUROLE实体不必作为聚合根，只是作为领域实体即可
    /// </summary>
    public partial class TB_MENUROLE : IEntity
    {
    }
}
