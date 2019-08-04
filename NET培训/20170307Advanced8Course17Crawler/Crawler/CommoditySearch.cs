using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Crawler.DataService;

using Crawler.Model;

namespace Crawler
{
    public class CommoditySearch
    {
        private Logger logger = new Logger(typeof(CommoditySearch));
        private WarnRepository warnRepository = new WarnRepository();
        private CommodityRepository commodityRepository = new CommodityRepository();
        private Category category = null;

        public CommoditySearch(Category _category)
        {
            category = _category;
        }

        public void Crawler()
        {
            try
            {
                if (string.IsNullOrEmpty(category.Url))
                {
                    warnRepository.SaveWarn(category, string.Format("Url为空,Name={0} Level={1} Url={2}", category.Name, category.CategoryLevel, category.Url));
                    return;
                }
                string html = HttpHelper.DownloadUrl(category.Url);//下载html

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);//加载html
                string pageNumberPath = @"//*[@id='J_topPage']/span/i";
                HtmlNode pageNumberNode = doc.DocumentNode.SelectSingleNode(pageNumberPath);
                if (pageNumberNode != null)
                {
                    string sNumber = pageNumberNode.InnerText;
                    for (int i = 1; i < int.Parse(sNumber) + 1; i++)
                    {
                        string pageUrl = string.Format("{0}&page={1}", category.Url, i);
                        try
                        {
                            List<Commodity> commodityList = GetCommodityList(category, pageUrl.Replace("&page=1&", string.Format("&page={0}&", i)));
                            //commodityRepository.SaveList(commodityList);
                        }
                        catch (Exception ex)//保证一页的错误不影响另外一页
                        {
                            logger.Error("Crawler的commodityRepository.SaveList(commodityList)出现异常", ex);
                        }
                    }
                }




                //string fristPath = "//*[@id='J_bottomPage']/span[1]/a";
                //HtmlNodeCollection noneNodeList = doc.DocumentNode.SelectNodes(fristPath);//xPath分析
                //if (noneNodeList == null)
                //{
                //    warnRepository.SaveWarn(category, string.Format("分页数据为空,Name={0} Level={1} Url={2}", category.Name, category.CategoryLevel, category.Url));
                //    return;
                //}

                //string pageUrl = null;
                //foreach (var node in noneNodeList)
                //{
                //    string sNum = node.InnerHtml;
                //    if (sNum.Equals("1"))
                //    {
                //        pageUrl = node.Attributes["href"].Value.Replace("&amp;", "&");
                //        if (!pageUrl.StartsWith("http://"))
                //            pageUrl = string.Format("http://list.jd.com{0}", pageUrl);
                //        break;
                //    }
                //}
                //string sMaxPageNumPath = "//*[@id='J_bottomPage']/span[2]/em[1]/b";
                //HtmlNode sMaxPageNumPathNode = doc.DocumentNode.SelectSingleNode(sMaxPageNumPath);
                //string sMaxPageNum = sMaxPageNumPathNode.InnerHtml;
                //for (int i = 1; i < int.Parse(sMaxPageNum) + 1; i++)
                //{
                //    try
                //    {
                //        List<Commodity> commodityList = GetCommodityList(category, pageUrl.Replace("&page=1&", string.Format("&page={0}&", i)));
                //        commodityRepository.SaveList(commodityList);
                //    }
                //    catch (Exception ex)//保证一页的错误不影响另外一页
                //    {
                //        logger.Error("Crawler的commodityRepository.SaveList(commodityList)出现异常", ex);
                //    }
                //}
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
                warnRepository.SaveWarn(category, string.Format("出现异常,Name={0} Level={1} Url={2}", category.Name, category.CategoryLevel, category.Url));
            }
        }

        private List<Commodity> GetCommodityList(Category category, string url)
        {
            string html = HttpHelper.DownloadUrl(url);
            List<Commodity> commodityList = new List<Commodity>();
            try
            {
                if (string.IsNullOrEmpty(html)) return commodityList;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string liPath = "//*[@id='plist']/ul/li";
                HtmlNodeCollection noneNodeList = doc.DocumentNode.SelectNodes(liPath);
                if (noneNodeList == null || noneNodeList.Count == 0)
                {
                    warnRepository.SaveWarn(category, string.Format("GetCommodityList商品数据为空,Name={0} Level={1} category.Url={2} url={3}", category.Name, category.CategoryLevel, category.Url, url));
                    return commodityList;
                }
                foreach (var node in noneNodeList)
                {
                    HtmlDocument docChild = new HtmlDocument();
                    docChild.LoadHtml(node.OuterHtml);

                    Commodity commodity = new Commodity()
                    {
                        CategoryId = category.Id
                    };

                    string urlPath = "//*[@class='p-name']/a";
                    HtmlNode urlNode = docChild.DocumentNode.SelectSingleNode(urlPath);
                    if (urlNode == null)
                    {
                        continue;
                    }
                    commodity.Url = urlNode.Attributes["href"].Value;
                    if (!commodity.Url.StartsWith("http:"))
                        commodity.Url = "http:" + commodity.Url;

                    string sId = Path.GetFileName(commodity.Url).Replace(".html", "");
                    commodity.ProductId = long.Parse(sId);

                    //*[@id="plist"]/ul/li[1]/div/div[3]/a/em
                    string titlePath = "//*[@class='p-name']/a/em";
                    HtmlNode titleNode = docChild.DocumentNode.SelectSingleNode(titlePath);
                    if (titleNode == null)
                    {
                        //Log.Error(titlePath);
                        continue;
                    }
                    commodity.Title = titleNode.InnerText;

                    string iamgePath = "//*[@class='p-img']/a/img";
                    HtmlNode imageNode = docChild.DocumentNode.SelectSingleNode(iamgePath);
                    if (imageNode == null)
                    {
                        continue;
                    }
                    if (imageNode.Attributes.Contains("src"))
                        commodity.ImageUrl = imageNode.Attributes["src"].Value;
                    else if (imageNode.Attributes.Contains("original"))
                        commodity.ImageUrl = imageNode.Attributes["original"].Value;
                    else if (imageNode.Attributes.Contains("data-lazy-img"))
                        commodity.ImageUrl = imageNode.Attributes["data-lazy-img"].Value;
                    else
                    {
                        continue;
                    }
                    if (!commodity.ImageUrl.StartsWith("http:"))
                        commodity.ImageUrl = "http:" + commodity.ImageUrl;


                    commodityList.Add(commodity);
                }
                Console.WriteLine("{0}一共获取了{1}条数据", url, commodityList.Count);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("GetCommodityList出现异常,url={0}", url), ex);
            }
            return GetCommodityPrice(category, commodityList);
        }

        /// <summary>
        /// 获取商品价格
        /// </summary>
        /// <param name="commodityList"></param>
        /// <returns></returns>
        private List<Commodity> GetCommodityPrice(Category category, List<Commodity> commodityList)
        {
            try
            {
                if (commodityList == null || commodityList.Count() == 0)
                    return commodityList;

                StringBuilder sb = new StringBuilder();
                //sb.Append(@"http://p.3.cn/prices/mgets?my=list_price&type=1&area=1_72_4137&skuIds=");
                //sb.Append(string.Join("%2C", commodityList.Select(c => string.Format("J_{0}", c.ProductId))));
                //
                sb.AppendFormat("http://p.3.cn/prices/mgets?callback=jQuery1069298&type=1&area=1_72_4137_0&skuIds={0}&pdbp=0&pdtk=&pdpin=&pduid=1945966343&_=1469022843655", string.Join("%2C", commodityList.Select(c => string.Format("J_{0}", c.ProductId))));
                string html = HttpHelper.DownloadUrl(sb.ToString());
                if (string.IsNullOrWhiteSpace(html))
                {
                    logger.Warn(string.Format("获取url={0}时获取的html为空", sb.ToString()));
                }
                html = html.Substring(html.IndexOf("(") + 1);
                html = html.Substring(0, html.LastIndexOf(")"));
                List<CommodityPrice> priceList = JsonConvert.DeserializeObject<List<CommodityPrice>>(html);
                commodityList.ForEach(c => c.Price = priceList.FirstOrDefault(p => p.id.Equals(string.Format("J_{0}", c.ProductId))).p);
                //commodityList.ForEach(c => Console.WriteLine(" Title={0}  ImageUrl={1} Url={2} Price={3} Id={4}", c.Title, c.ImageUrl, c.Url, c.Price, c.Id));
            }
            catch (Exception ex)
            {
                logger.Error("GetCommodityPrice出现异常", ex);
            }
            return commodityList;
        }
    }
}
