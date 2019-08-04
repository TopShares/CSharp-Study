using Ruanmou.LuceneProject.DataService;
using Ruanmou.LuceneProject.Model;
using Ruanmou.LuceneProject.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.LuceneProject
{
    /// <summary>
    /// 1 lucene简介
    /// 2 lucene.net七大对象介绍
    /// 
    /// 1 lucene索引建立和查询DEMO
    /// 2 索引增删改查和分词处理
    /// 3 针对京东数据建立索引和查询接口
    /// 4 作业部署
    /// </summary>
    class Program
    {
        /// <summary>
        /// Lucene.Net  3.0.3
        /// Lucene.Net.Analysis.PanGu  2.4.1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {


                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的lucene.net");

                //LuceneTest.InitIndex();
                //LuceneTest.Show();

                IndexBuilder.BuildIndex();


                int total = 0;
                string pricefilter = "[50,2000]";
                string priceorderby = "price desc";
                List<Commodity> commoditylist = CommodityLucene.QueryCommodity(1, 30, out total, "书", null, pricefilter, priceorderby);

                foreach (Commodity commodity in commoditylist)
                {
                    Console.WriteLine("title={0},price={1}", commodity.Title, commodity.Price);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
