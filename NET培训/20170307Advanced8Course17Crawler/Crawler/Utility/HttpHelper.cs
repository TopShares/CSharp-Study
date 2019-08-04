using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    /// <summary>
    /// http://tool.sufeinet.com/HttpHelper.aspx
    /// </summary>
    public class HttpHelper
    {
        private static Logger logger = new Logger(typeof(HttpHelper));

        /// <summary>
        /// 根据url下载内容  之前是GB2312
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadUrl(string url)
        {
            return DownloadHtml(url, Encoding.UTF8);
        }

        /// <summary>
        /// 下载html
        /// http://tool.sufeinet.com/HttpHelper.aspx
        /// HttpWebRequest功能比较丰富，WebClient使用比较简单
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url, Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求
                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 
                //request.Host = "search.yhd.com";

                //request.Headers.Add("Cookie", @"newUserFlag=1; guid=YFT7C9E6TMFU93FKFVEN7TEA5HTCF5DQ26HZ; gray=959782; cid=av9kKvNkAPJ10JGqM_rB_vDhKxKM62PfyjkB4kdFgFY5y5VO; abtest=31; _ga=GA1.2.334889819.1425524072; grouponAreaId=37; provinceId=20; search_showFreeShipping=1; rURL=http%3A%2F%2Fsearch.yhd.com%2Fc0-0%2Fkiphone%2F20%2F%3Ftp%3D1.1.12.0.73.Ko3mjRR-11-FH7eo; aut=5GTM45VFJZ3RCTU21MHT4YCG1QTYXERWBBUFS4; ac=57265177%40qq.com; msessionid=H5ACCUBNPHMJY3HCK4DRF5VD5VA9MYQW; gc=84358431%2C102362736%2C20001585%2C73387122; tma=40580330.95741028.1425524063040.1430288358914.1430790348439.9; tmd=23.40580330.95741028.1425524063040.; search_browse_history=998435%2C1092925%2C32116683%2C1013204%2C6486125%2C38022757%2C36224528%2C24281304%2C22691497%2C26029325; detail_yhdareas=""; cart_cookie_uuid=b64b04b6-fca7-423b-b2d1-ff091d17e5e5; gla=20.237_0_0; JSESSIONID=14F1F4D714C4EE1DD9E11D11DDCD8EBA; wide_screen=1; linkPosition=search");

                //request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Referer", "http://list.yhd.com/c0-0/b/a-s1-v0-p1-price-d0-f0-m1-rt0-pid-mid0-kiphone/");

                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Warn(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format("DownloadHtml抓取{0}保存失败", url), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    logger.Error("远程服务器返回错误: (306)。", ex);
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
