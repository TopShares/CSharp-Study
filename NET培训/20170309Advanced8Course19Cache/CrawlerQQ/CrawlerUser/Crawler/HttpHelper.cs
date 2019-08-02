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
        /// 根据html下载内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url)
        {
            string html = string.Empty;
            try
            {
                var request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //request.Host = "search.yhd.com";
                //request.Referer = "http://www.jd.com/allSort.aspx";

                request.Headers.Add("Cookie", @"game_market_hislocation=http://game-web.qq.com/market/inc/index_main_2.html; game_market_gender=2; game_market_realgender=2; firstlogin=1; cpu_performance=5; subUser=1; dressupsaveok=1; diagnose=photo; nurse=0_3_7; _qz_cdn=_imgcache.qq.com_imgcache.qq.com; zzpaneluin=; zzpanelkey=; user_id=null; session_id=null; qqmusic_uin=; qqmusic_key=; qqmusic_fromtag=; qzmusicplayer=qzone_player_454543971_1426478849364; pt_login_sig=SEzPg9hfRwmeWC-Ss4wGdyuFOtRitUQJlvYLr1KSEN2WMTlJqQdfK-C6ZHCGSMvf; __Q_w_s_hat_seed=1; FTN5K=2a172f8d; verifysession=h01c2d0abcafa50fa17582b90d9ccf320d87991753e0ccfcdfea5c366ff71e4fe28031cadd7d8e985917ef6423a4dad8a75; RK=LbU2BTe3Xk; QZ_FE_WEBP_SUPPORT=1; cpu_performance_v8=49; __Q_w_s__QZN_TodoMsgCnt=1; ptwebqq=4f1351808b7b9ffc44d5b0b41d0642207ead29374980987c60eddf9ea68eab49; qzspeedup=sdch; pgv_pvi=2252787712; pgv_si=s1256762368; qz_gdt=tykjcvsdaaaiktrgtkzq; pt_clientip=ddc90a821c36b08c; pt_serverip=058a0a82584b584d; ptui_loginuin=2993661847; pgv_info=ssid=s916654622; pgv_pvid=6743316430; o_cookie=2814208296; qzone_check=57265177_1452415887; qm_username=57265177; qm_sid=2a68a4920425e3f5e9698451b242b516,qMVV6eDFQMjl1TTl4STloakhWZVV5MFNLWU1oRkJzUnFqVXJlR1dXZ0NXTV8.; ptisp=ctc; ptcz=3836462b262c19773ea384242e1be6734a8f4529c8d31243a5e60a8cf05f87c7; pt2gguin=o0057265177; uin=o0057265177; skey=@AFEngB6b5; p_uin=o0057265177; p_skey=uBu6-3Hi8xnhbWO*ehv6tjS-wxx9Tnf6V*bi5gY5*Ko_; pt4_token=ptk3RFSvEzsts*g9VPt0JpOSnOZMYcb4ev16untzk*0_");

                //request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Referer", "http://list.yhd.com/c0-0/b/a-s1-v0-p1-price-d0-f0-m1-rt0-pid-mid0-kiphone/");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");


                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //Log.Error(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                        return url;
                    }
                    try
                    {

                        StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);//Encoding.GetEncoding("GB2312"));// 
                        html = sr.ReadToEnd();
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        ////Log.Error(string.Format("DownloadHtml抓取{0}保存失败", url), ex);
                        html = null;
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    logger.Error("远程服务器返回错误: (306)。", ex);
                    //Console.WriteLine("DownloadHtml url={0}结果为空,306", url);
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error("异常", ex);
                //Log.Error(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
