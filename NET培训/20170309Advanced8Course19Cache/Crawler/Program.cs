using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Crawler.DataService;
using Crawler.Model;

namespace Crawler
{
    /// <summary>
    /// 1 爬虫，爬虫攻防
    /// 2 下载html
    /// 3 xpath解析html，获取数据和深度抓取
    /// 4 不一样的属性和ajax数据的获取
    /// 5 多线程爬虫
    /// </summary>
    class Program
    {
        private static Logger logger = new Logger(typeof(Program));
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的爬虫的学习");

                ////测试DownloadHtml
                //string html = HttpHelper.DownloadHtml(@"http://list.jd.com/list.html?cat=9987,653,655", Encoding.UTF8);

                ////测试获取分类页
                //string html1 = HttpHelper.DownloadHtml("http://www.jd.com/allSort.aspx", Encoding.UTF8);



                ////测试抓取商品列表
                //string testCategory = "{\"Id\":73,\"Code\":\"02f01s01T\",\"ParentCode\":\"02f01s\",\"Name\":\"烟机/灶具\",\"Url\":\"http://list.jd.com/list.html?cat=737,13297,1300\",\"Level\":3}";
                //new CommoditySearch(JsonConvert.DeserializeObject<Category>(testCategory)).Crawler();

                //List<Category> categoryList = CategorySearch.Crawler("http://www.jd.com/allSort.aspx");

                //Crawl();
            }
            catch (Exception ex)
            {
                logger.Error("异常啦，", ex);
                Console.WriteLine("*****************木有成功**********************");
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 抓取
        /// </summary>
        private static void Crawl()
        {
            DBInit dbInit = new DBInit();
            CategoryRepository categoryRepository = new CategoryRepository();
            Console.WriteLine("请输入Y/N进行类别表初始化确认！ Y 删除Category表然后重新创建，然后抓取类型数据，N（或者其他）跳过");
            string input = Console.ReadLine();
            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                dbInit.InitCategoryTable();
                List<Category> categoryList = CategorySearch.Crawler("http://www.jd.com/allSort.aspx");

                categoryRepository.Save(categoryList);
                Console.WriteLine("类型数据初始化完成，共抓取类别{0}个", categoryList.Count);
            }
            else
            {
                Console.WriteLine("你选择不初始化类别数据");
            }
            Console.WriteLine("*****************^_^**********************");

            Console.WriteLine("请输入Y/N进行商品数据初始化确认！ Y 删除全部商品表表然后重新创建，然后抓取商品数据，N（或者其他）跳过");
            input = Console.ReadLine();
            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                dbInit.InitCommodityTable();
                CrawlerCommodity();
            }
            Console.WriteLine("*****************^_^**********************");
            //CleanAll();
        }

        /// <summary>
        /// 抓取商品
        /// </summary>
        private static void CrawlerCommodity()
        {
            Console.WriteLine("{0} jd商品开始抓取 - -", DateTime.Now);
            CategoryRepository categoryRepository = new CategoryRepository();
            List<Category> categoryList = categoryRepository.QueryListByLevel(3);

            List<Task> taskList = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            foreach (Category category in categoryList)
            {
                CommoditySearch searcher = new CommoditySearch(category);
                //searcher.Crawler();
                taskList.Add(taskFactory.StartNew(searcher.Crawler));
                if (taskList.Count > 15)
                {
                    taskList = taskList.Where(t => !t.IsCompleted && !t.IsCanceled && !t.IsFaulted).ToList();
                    Task.WaitAny(taskList.ToArray());
                }
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine("{0} jd商品抓取全部完成 - -", DateTime.Now);
            CleanAll();
        }

        /// <summary>
        /// 清理数据
        /// </summary>
        private static void CleanAll()
        {
            try
            {
                Console.WriteLine("{0} 开始清理重复数据 - -", DateTime.Now);
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < 31; i++)
                {
                    sb.AppendFormat(@"DELETE FROM [dbo].[JD_Commodity_{0}] where productid IN(select productid from [dbo].[JD_Commodity_{0}] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_{0}] group by productid,CategoryId having count(0)>1);", i.ToString("000"));
                }
                #region
                /*
                 DELETE FROM [dbo].[JD_Commodity_001] where productid IN(select productid from [dbo].[JD_Commodity_001] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_001] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_002] where productid IN(select productid from [dbo].[JD_Commodity_002] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_002] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_003] where productid IN(select productid from [dbo].[JD_Commodity_003] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_003] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_004] where productid IN(select productid from [dbo].[JD_Commodity_004] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_004] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_005] where productid IN(select productid from [dbo].[JD_Commodity_005] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_005] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_006] where productid IN(select productid from [dbo].[JD_Commodity_006] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_006] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_007] where productid IN(select productid from [dbo].[JD_Commodity_007] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as IDv from [dbo].[JD_Commodity_007] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_008] where productid IN(select productid from [dbo].[JD_Commodity_008] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_008] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_009] where productid IN(select productid from [dbo].[JD_Commodity_009] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_009] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_010] where productid IN(select productid from [dbo].[JD_Commodity_010] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_010] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_011] where productid IN(select productid from [dbo].[JD_Commodity_011] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_011] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_012] where productid IN(select productid from [dbo].[JD_Commodity_012] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_012] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_013] where productid IN(select productid from [dbo].[JD_Commodity_013] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_013] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_014] where productid IN(select productid from [dbo].[JD_Commodity_014] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_014] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_015] where productid IN(select productid from [dbo].[JD_Commodity_015] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_015] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_016] where productid IN(select productid from [dbo].[JD_Commodity_016] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_016] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_017] where productid IN(select productid from [dbo].[JD_Commodity_017] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_017] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_018] where productid IN(select productid from [dbo].[JD_Commodity_018] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_018] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_019] where productid IN(select productid from [dbo].[JD_Commodity_019] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_019] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_020] where productid IN(select productid from [dbo].[JD_Commodity_020] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_020] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_021] where productid IN(select productid from [dbo].[JD_Commodity_021] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_021] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_022] where productid IN(select productid from [dbo].[JD_Commodity_022] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_022] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_023] where productid IN(select productid from [dbo].[JD_Commodity_023] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_023] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_024] where productid IN(select productid from [dbo].[JD_Commodity_024] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_024] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_025] where productid IN(select productid from [dbo].[JD_Commodity_025] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_025] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_026] where productid IN(select productid from [dbo].[JD_Commodity_026] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_026] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_027] where productid IN(select productid from [dbo].[JD_Commodity_027] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_027] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_028] where productid IN(select productid from [dbo].[JD_Commodity_028] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_028] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_029] where productid IN(select productid from [dbo].[JD_Commodity_029] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_029] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_030] where productid IN(select productid from [dbo].[JD_Commodity_030] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_030] group by productid,CategoryId having count(0)>1);
                 */
                #endregion
                Console.WriteLine("执行清理sql:{0}", sb.ToString());
                SqlHelper.ExecuteNonQuery(sb.ToString());
                Console.WriteLine("{0} 完成清理重复数据 - -", DateTime.Now);
            }
            catch (Exception ex)
            {
                logger.Error("CleanAll出现异常", ex);
            }
            finally
            {
                Console.WriteLine("{0} 结束清理重复数据 - -", DateTime.Now);
            }
        }
    }
}
