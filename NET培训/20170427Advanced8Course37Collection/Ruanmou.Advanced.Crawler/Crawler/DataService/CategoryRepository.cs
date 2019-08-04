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
    public class CategoryRepository //: IRepository<Commodity>
    {
        private Logger logger = new Logger(typeof(CategoryRepository));

        public void Save(List<Category> categoryList)
        {
            SqlHelper.InsertList<Category>(categoryList, "Category");
            new Action<List<Category>>(SaveList).BeginInvoke(categoryList, null, null);
        }

        /// <summary>
        /// 根据Level获取类别列表
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public List<Category> QueryListByLevel(int level)
        {
            string sql = string.Format("SELECT * FROM category WHERE categorylevel={0};", level);
            return SqlHelper.QueryList<Category>(sql);
        }


        /// <summary>
        /// 存文本记录的
        /// </summary>
        /// <param name="categoryList"></param>
        public void SaveList(List<Category> categoryList)
        {
            StreamWriter sw = null;
            try
            {
                string recordFileName = string.Format("{0}_Category.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));
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

                sw.WriteLine(JsonConvert.SerializeObject(categoryList));
            }
            catch (Exception e)
            {
                logger.Error("CategoryRepository.SaveList出现异常", e);
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
