using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    /// <summary>
    /// 使用说明:
    /// 1 配置config的datapath，目前Data文件夹为数据保存结果 每次重新抓取前清除掉
    /// 2 qq搜索群=>选择一个群=>分享=>到qq好友=>会弹出http://connect.qq.com/自动登录
    /// =>在http://find.qq.com/index.html 进行查询群=>关注网络请求到http://cgi.find.qq.com/qqfind/qun/search_group_rcmd_v6
    /// =>找出cookie配置到HttpHelper.DownloadHtmlPost的request.Headers.Add("Cookie",
    /// 3 关键词可以直接在appconfig配置，用分号隔开
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GroupSearch.Process();
            Console.WriteLine("抓取完成");
            Console.ReadKey();
            //string html = HttpHelper.DownloadHtml("http://qun.qzone.qq.com/cgi-bin/get_group_member?callbackFun=_GroupMember&uin=57265177&groupid=202017583&neednum=1&r=0.6204506570938975&g_tk=486005817&ua=Mozilla%2F5.0%20(Windows%20NT%206.3%3B%20WOW64)%20AppleWebKit%2F537.36%20(KHTML%2C%20like%20Gecko)%20Chrome%2F30.0.1599.69%20Safari%2F537.36");
        }
    }
}
