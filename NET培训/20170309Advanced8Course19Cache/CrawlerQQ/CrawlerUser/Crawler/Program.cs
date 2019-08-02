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
    /// 2 qq加群后在qq客户端右键群访问群空间==>找到http://qun.qzone.qq.com/cgi-bin/get_group_member的ajax请求，修改到QQSearch.Process的urlTemp，注意&groupid={0}换成这样的
    /// ==>找到该请求的cookie信息，替换到HttpHelper.DownloadHtml的request.Headers.Add("Cookie",
    /// 3 qq群号可以在appconfig配置，用分号隔开，然后运行就会按照群号建立文件
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            QQSearch.Process();
            Console.WriteLine("抓取完成");
            Console.ReadKey();
            
        }
    }
}
