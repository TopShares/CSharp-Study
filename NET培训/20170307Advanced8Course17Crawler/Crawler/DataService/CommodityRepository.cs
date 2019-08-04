using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Model;

namespace Crawler.DataService
{
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
        /// 保存文本记录
        /// </summary>
        /// <param name="commodityList"></param>
        /// <param name="category"></param>
        /// <param name="page"></param>
        public void SaveList(List<Commodity> commodityList, Category category, int page)
        {
            StreamWriter sw = null;
            try
            {
                string recordFileName = string.Format("{0}/{1}/{2}/{3}.txt", category.CategoryLevel, category.ParentCode, category.Id, page);
                string totolPath = Path.Combine(ObjectFactory.DataPath, recordFileName);
                if (!Directory.Exists(Path.GetDirectoryName(totolPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(totolPath));
                    sw = File.CreateText(totolPath);
                }
                else
                {
                    sw = File.AppendText(totolPath);
                }
                sw.WriteLine(JsonConvert.SerializeObject(commodityList));
            }
            catch (Exception e)
            {
                logger.Error("CommodityRepository.SaveList出现异常", e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
