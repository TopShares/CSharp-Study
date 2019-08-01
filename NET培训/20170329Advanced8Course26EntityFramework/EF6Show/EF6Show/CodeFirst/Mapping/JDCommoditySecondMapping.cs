using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Show.CodeFirst.Mapping
{
    public class JDCommoditySecondMapping : EntityTypeConfiguration<JDCommoditySecond>
    {
        public JDCommoditySecondMapping()
        {
            this.ToTable("JD_Commodity_002");
            this.Property(c => c.ClassId).HasColumnName("CategoryId");
        }
    }
}
