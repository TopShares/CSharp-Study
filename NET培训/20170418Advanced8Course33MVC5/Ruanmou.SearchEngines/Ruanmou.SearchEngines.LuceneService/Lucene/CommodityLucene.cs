using Ruanmou.SearchEngines.LuceneService.Interface;
using Ruanmou.SearchEngines.LuceneService.Model;
using Ruanmou.SearchEngines.LuceneService.Service;
using Ruanmou.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.SearchEngines.LuceneService
{
    public class CommodityLucene
    {
        private static Logger logger = new Logger(typeof(CommodityLucene));
        #region QueryCommodity
        /// <summary>
        /// 用lucene进行商品查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="keyword"></param>
        /// <param name="categoryIdList"></param>
        /// <param name="priceFilter">[13,50]  13,50且包含13到50   {13,50}  13,50且不包含13到50</param>
        /// <param name="priceOrderBy">price desc   price asc</param>
        /// <returns></returns>
        public static List<Commodity> QueryCommodity(int pageIndex, int pageSize, out int totalCount, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy)
        {
            totalCount = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(keyword) && (categoryIdList == null || categoryIdList.Count == 0)) return null;
                ILuceneQuery luceneQuery = new LuceneQuery();
                string queryString = string.Format(" {0} {1}",
                                                    string.IsNullOrWhiteSpace(keyword) ? "" : string.Format(" +{0}", AnalyzerKeyword(keyword)),
                                                    categoryIdList == null || categoryIdList.Count == 0 ? "" : string.Format(" +{0}", AnalyzerCategory(categoryIdList)));

                return luceneQuery.QueryIndexPage(queryString, pageIndex, pageSize, out totalCount, priceFilter, priceOrderBy);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("QueryCommodity参数为{0}出现异常", keyword), ex);
                return null;
            }
        }
        #endregion QueryCommodity

        /// <summary>
        /// 为keyword做盘古分词
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="luceneQuery"></param>
        /// <returns></returns>
        private static string AnalyzerKeyword(string keyword)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            ILuceneAnalyze analyzer = new LuceneAnalyze();
            string[] words = analyzer.AnalyzerKey(keyword);
            if (words.Length == 1)
            {
                queryStringBuilder.AppendFormat("{0}:{1}* ", "title", words[0]);
            }
            else
            {
                StringBuilder fieldQueryStringBuilder = new StringBuilder();
                foreach (string word in words)
                {
                    queryStringBuilder.AppendFormat("{0}:{1} ", "title", word);
                }
            }
            string result = queryStringBuilder.ToString().TrimEnd();
            logger.Info(string.Format("AnalyzerKeyword 将 keyword={0}转换为{1}", keyword, result));
            return result;
        }

        /// <summary>
        /// 为类别做custom分词
        /// </summary>
        /// <param name="categoryIdList"></param>
        /// <returns></returns>
        private static string AnalyzerCategory(List<int> categoryIdList)
        {
            return string.Join(" ", categoryIdList.Select(c => string.Format("{0}:{1}", "categoryid", c)));
        }
    }
}
