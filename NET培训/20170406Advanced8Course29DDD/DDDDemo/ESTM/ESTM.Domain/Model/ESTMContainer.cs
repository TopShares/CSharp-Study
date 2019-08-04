using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Domain
{
    [Export(typeof(DbContext))]
    public partial class ESTMContainer:DbContext
    {

    }
}
