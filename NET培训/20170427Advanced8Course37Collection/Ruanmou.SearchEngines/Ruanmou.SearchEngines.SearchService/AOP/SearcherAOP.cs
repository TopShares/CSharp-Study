using Ruanmou.SearchEngines.LuceneService;
using Ruanmou.SearchEngines.LuceneService.DataService;
using Ruanmou.SearchEngines.LuceneService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.SearchEngines.SearchService
{
    public class SearcherAOP : ISearcherAOP
    {

        public string QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy)
        {
            int totalCount = 0;
            List<Commodity> commodityList = CommodityLucene.QueryCommodity(pageIndex, pageSize, out totalCount, keyword, categoryIdList, priceFilter, priceOrderBy);

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(new PageResult<Commodity>()
             {
                 PageIndex = pageIndex,
                 PageSize = pageSize,
                 TotalCount = totalCount,
                 DataList = commodityList
             });
            return result;
        }
    }
}
