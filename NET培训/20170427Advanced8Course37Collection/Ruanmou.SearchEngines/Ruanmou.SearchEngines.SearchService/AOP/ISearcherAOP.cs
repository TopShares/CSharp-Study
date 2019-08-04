﻿using Ruanmou.SearchEngines.SearchService.AOP.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.SearchEngines.SearchService
{
    public interface ISearcherAOP
    {
        /// <summary>
        /// 分页获取商品信息数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="categoryIdList">类别id的集合 可为null</param>
        /// <param name="priceFilter">[13,50]  13,50且包含13到50   {13,50}  13,50且不包含13到50</param>
        /// <param name="priceOrderBy">price desc   price asc</param>
        /// <returns>PageResult Commodity tojson</returns>
        [LogHandlerAttribute(Order = 2)]
        [ExceptionHandlerAttribute(Order = 3)]
        [AfterLogHandlerAttribute(Order = 5)]
        string QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy);
    }
}
