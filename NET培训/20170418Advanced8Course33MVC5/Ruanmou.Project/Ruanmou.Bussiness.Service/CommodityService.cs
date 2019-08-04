using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ruanmou.Bussiness.Interface;
using System.Linq.Expressions;
using System.Data.Entity;
using Ruanmou.EF.Model;

namespace Ruanmou.Bussiness.Service
{
    public class CommodityService : BaseService, ICommodityService
    {
        private DbSet<Commodity> _CommodityDbSet = null;
        public CommodityService(DbContext dbContext)
            : base(dbContext)
        {
            this._CommodityDbSet = dbContext.Set<Commodity>();
        }

        public IQueryable<EF.Model.Commodity> QueryCommodity(Expression<Func<EF.Model.Commodity, bool>> where)
        {
            return this._CommodityDbSet.Where(where);
        }

        public override void Dispose()
        {
            Console.WriteLine("已释放");
            base.Dispose();
        }
    }
}
