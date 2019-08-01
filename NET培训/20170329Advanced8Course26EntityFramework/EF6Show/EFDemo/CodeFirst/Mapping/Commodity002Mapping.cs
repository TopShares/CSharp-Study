using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.CodeFirst
{
    public class Commodity002Mapping : EntityTypeConfiguration<Commodity002>
    {
        public Commodity002Mapping()
        {
            this.ToTable("JD_Commodity_002");
        }
    }
}
