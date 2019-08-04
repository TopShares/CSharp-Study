using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Diagnostics;

using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Util;
using Lucene.Net.Store;
using PanGu;
using Ruanmou.SearchEngines.LuceneService.Interface;
using Ruanmou.SearchEngines.LuceneService.Model;
using Ruanmou.Core;

namespace Ruanmou.SearchEngines.LuceneService.Service
{
    public class LuceneQuery : ILuceneQuery
    {
        #region Identity
        private Logger logger = new Logger(typeof(LuceneQuery));
        #endregion Identity

        #region QueryIndex
        /// <summary>
        /// 获取商品信息数据
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public List<Commodity> QueryIndex(string queryString)
        {
            IndexSearcher searcher = null;
            try
            {
                List<Commodity> ciList = new List<Commodity>();
                Directory dir = FSDirectory.Open(StaticConstant.IndexPath);
                searcher = new IndexSearcher(dir);
                Analyzer analyzer = new PanGuAnalyzer();

                //--------------------------------------这里配置搜索条件
                QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "title", analyzer);
                Query query = parser.Parse(queryString);
                Console.WriteLine(query.ToString()); //显示搜索表达式
                TopDocs docs = searcher.Search(query, (Filter)null, 10000);

                foreach (ScoreDoc sd in docs.ScoreDocs)
                {
                    Document doc = searcher.Doc(sd.Doc);
                    ciList.Add(DocumentToCommodityInfo(doc));
                }

                return ciList;
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }



        /// <summary>
        /// 分页获取商品信息数据
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="pageIndex">第一页为1</param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Commodity> QueryIndexPage(string queryString, int pageIndex, int pageSize, out int totalCount, string priceFilter, string priceOrderBy)
        {
            totalCount = 0;
            IndexSearcher searcher = null;
            try
            {
                List<Commodity> ciList = new List<Commodity>();
                FSDirectory dir = FSDirectory.Open(StaticConstant.IndexPath);
                searcher = new IndexSearcher(dir);
                Analyzer analyzer = new PanGuAnalyzer();

                //--------------------------------------这里配置搜索条件
                QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "title", analyzer);
                Query query = parser.Parse(queryString);
                
                pageIndex = Math.Max(1, pageIndex);//索引从1开始
                int startIndex = (pageIndex - 1) * pageSize;
                int endIndex = pageIndex * pageSize;

                NumericRangeFilter<float> numPriceFilter = null;
                if (!string.IsNullOrWhiteSpace(priceFilter))
                {
                    bool isContainStart = priceFilter.StartsWith("[");
                    bool isContainEnd = priceFilter.EndsWith("]");
                    string[] floatArray = priceFilter.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Split(',');
                    float start = 0;
                    float end = 0;
                    if (!float.TryParse(floatArray[0], out start) || !float.TryParse(floatArray[1], out end))
                    {
                        throw new Exception("Wrong priceFilter");
                    }
                    numPriceFilter = NumericRangeFilter.NewFloatRange("price", start, end, isContainStart, isContainEnd);
                }

                Sort sort = new Sort();
                if (!string.IsNullOrWhiteSpace(priceOrderBy))
                {
                    SortField sortField = new SortField("price", SortField.FLOAT, priceOrderBy.EndsWith("asc", StringComparison.CurrentCultureIgnoreCase));
                    sort.SetSort(sortField);
                }

                TopDocs docs = searcher.Search(query, numPriceFilter, 10000, sort);
                //TopDocs docs = searcher.Search(query, null, 10000);
                
                totalCount = docs.TotalHits;
                //PrintScores(docs, startIndex, endIndex, searcher);
                for (int i = startIndex; i < endIndex && i < totalCount; i++)
                {
                    Document doc = searcher.Doc(docs.ScoreDocs[i].Doc);
                    ciList.Add(DocumentToCommodityInfo(doc));
                }

                return ciList;
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }

        private void PrintScores(TopDocs docs, int startIndex, int endIndex, MultiSearcher searcher)
        {
            ScoreDoc[] scoreDocs = docs.ScoreDocs;
            for (int i = startIndex; i < endIndex && i < scoreDocs.Count(); i++)
            {
                int docId = scoreDocs[i].Doc;
                Document doc = searcher.Doc(docId);
                logger.Info(string.Format("{0}的分值为{1}", doc.Get("productid"), scoreDocs[i].Score));
            }
        }

        #endregion QueryIndex

        #region private
        private Commodity DocumentToCommodityInfo(Document doc)
        {
            return new Commodity()
                       {
                           Id = int.Parse(doc.Get("id")),
                           Title = doc.Get("title"),
                           ProductId = long.Parse(doc.Get("productid")),
                           CategoryId = int.Parse(doc.Get("categoryid")),
                           ImageUrl = doc.Get("iamgeurl"),
                           Price = decimal.Parse(doc.Get("price")),
                           Url = doc.Get("url")
                       };
        }

        #endregion private
    }
}
