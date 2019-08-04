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
    public class WarnRepository //: IRepository<Commodity>
    {
        private Logger logger = new Logger(typeof(WarnRepository));
        public void SaveWarn(Category category, string msg)
        {
            StreamWriter sw = null;
            try
            {
                string recordFileName = string.Format("warn/{0}/{1}/{2}.txt", category.CategoryLevel, category.ParentCode, category.Id);
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
                sw.WriteLine(msg);
                sw.WriteLine(JsonConvert.SerializeObject(JsonConvert.SerializeObject(category)));
            }
            catch (Exception e)
            {
                logger.Error("SaveWarn出现异常", e);
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
