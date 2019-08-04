using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ruanmou.LuceneProject.Model;
using Ruanmou.LuceneProject.Utility;

namespace Ruanmou.LuceneProject.DataService
{
    /// <summary>
    /// 数据库查询
    /// </summary>
    public class CommodityRepository //: IRepository<Commodity>
    {
        private Logger logger = new Logger(typeof(CommodityRepository));

        public void SaveList(List<Commodity> commodityList)
        {
            if (commodityList == null || commodityList.Count == 0) return;
            IEnumerable<IGrouping<string, Commodity>> group = commodityList.GroupBy<Commodity, string>(c => GetTableName(c));

            foreach (var data in group)
            {
                SqlHelper.InsertList<Commodity>(data.ToList(), data.Key);
            }
        }

        private string GetTableName(Commodity commodity)
        {
            return string.Format("JD_Commodity_{0}", (commodity.ProductId % 30 + 1).ToString("000"));
        }

        /// <summary>
        /// 分页获取商品数据
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="pageIndex">从1开始</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Commodity> QueryList(int tableNum,int pageIndex, int pageSize)
        {
            string sql = string.Format("SELECT top {2} * FROM JD_Commodity_{0} WHERE id>{1};", tableNum.ToString("000"), pageSize * Math.Max(0, pageIndex - 1), pageSize);
            return SqlHelper.QueryList<Commodity>(sql);
        }
    }
}
