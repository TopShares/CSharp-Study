using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class GroupSearch
    {
        private static string keywords = ConfigurationManager.AppSettings["Keyword"];

        public static void Process()
        {
            string[] keywordArray = keywords.Split(';');
            List<int> groupCodeList = new List<int>();
            foreach (string keyword in keywordArray)
            {
                bool isGoon = true;
                int page = 0;
                while (isGoon)
                {
                    string result = HttpHelper.DownloadHtmlPost(keyword, page);
                    GroupDataModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<GroupDataModel>(result);
                    if (model != null && model.result != null && model.result.group != null && model.result.group.group_list != null)
                    {
                        foreach (GroupModel group in model.result.group.group_list)
                        {
                            if (!groupCodeList.Contains(group.code))//去重
                            {
                                string content = string.Format("{0}\t{1}\t{2}", group.code, group.member_num, group.name);
                                DataRecord.Save(keyword, page, content);
                                groupCodeList.Add(group.code);
                            }

                        }
                        page++;
                    }
                    else
                    {
                        isGoon = false;
                    }
                }
            }
            DataRecord.Save("existgroup", 1, string.Join(",", groupCodeList));
        }
    }
}
