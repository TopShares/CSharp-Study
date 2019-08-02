using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class QQSearch
    {
        private static string QQGroupNumberList = ConfigurationManager.AppSettings["QQGroupNumberList"];

        public static void Process()
        {
            string urlTemp = "http://qun.qzone.qq.com/cgi-bin/get_group_member?uin=57265177&groupid={0}&random=0.9667214127257466&g_tk=761389813";

            string[] groupIdArray = QQGroupNumberList.Split(';');
            List<long> qqList = new List<long>();
            foreach (string groupId in groupIdArray)
            {
                string url = string.Format(urlTemp, groupId);
                string result = HttpHelper.DownloadHtml(url);//_Callback(json);
                if (result.StartsWith("_Callback("))
                    result = result.Substring("_Callback(".Length);
                result = result.Substring(0, result.Length - 2);

                GroupDataModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<GroupDataModel>(result);
                if (model != null && model.data != null && model.data.item != null)
                {
                    foreach (UserInfo user in model.data.item)
                    {
                        if (!qqList.Contains(user.uin))//去重
                        {
                            string content = string.Format("{0}\t{1}", user.uin, user.nick);
                            DataRecord.Save(groupId, 1, content);
                            qqList.Add(user.uin);
                        }

                    }
                }
            }
            DataRecord.Save("existqq", 1, string.Join(",", qqList));
        }
    }
}
