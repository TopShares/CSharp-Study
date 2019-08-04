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

                //必须要有cookie 否则顺序不对
                request.Headers.Add("Cookie", @"game_market_hislocation=http://game-web.qq.com/market/inc/index_main_2.html; game_market_gender=2; game_market_realgender=2; firstlogin=1; subUser=1; user_id=null; session_id=null; qqmusic_uin=; qqmusic_key=; qqmusic_fromtag=; pt_login_sig=SEzPg9hfRwmeWC-Ss4wGdyuFOtRitUQJlvYLr1KSEN2WMTlJqQdfK-C6ZHCGSMvf; qz_gdt=yrt6svihaiajalqo2mwq; FTN5K=2a172f8d; ptui_loginuin=2755858464; qm_sid=2ff86200932e3631beebf306d62c4a10,qd2hZc0dPTllvejRmQzMqRHN1YnJSM0VoV2RWenB3eDZjMjd5a2d3SERLWV8.; verifysession=h01c2d0abcafa50fa17582b90d9ccf320d87991753e0ccfcdfea5c366ff71e4fe28031cadd7d8e985917ef6423a4dad8a75; qm_username=57265177; RK=LbU2BTe3Xk; o_cookie=57265177; ptwebqq=4f1351808b7b9ffc44d5b0b41d0642207ead29374980987c60eddf9ea68eab49; pt_clientip=5cb60a821c36594c; pt_serverip=d91e0aa693da8c94; ptisp=ctc; ptcz=3836462b262c19773ea384242e1be6734a8f4529c8d31243a5e60a8cf05f87c7; pt2gguin=o0057265177; uin=o0057265177; skey=@NweL8IpGf; pgv_pvi=2252787712; pgv_si=s1256762368; pgv_info=ssid=s916654622; pgv_pvid=6743316430; itkn=3070620359");

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


        public static string DownloadHtmlPost(string keyword, int page)
        {
            string html = string.Empty;
            try
            {
                string url = "http://cgi.find.qq.com/qqfind/qun/search_group_rcmd_v6";
                int sort = 2;//人数
                string dataString = string.Format("k={0}&n=24&st={1}&iso=0&src=1&v=4093&p={2}&isRecommend=false&city_id=0&from=1&ldw=1361580739", keyword, sort, page);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Referer = "http://find.qq.com/index.html";
                request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
                request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
                request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";

                request.Headers.Add("Cookie", @"ptui_loginuin=57265177; tvfe_boss_uuid=2edc84ac23a71b76; eas_sid=N1D4g7J1e385e4d7I4k2a3z5u7; IED_LOG_INFO2=userUin%3D57265177%26nickName%3DEleven%26userLoginTime%3D1471354757; mobileUV=1_156a83b0d77_d99fc; o_cookie=57265177; FTN5K=e5fb252a; pgv_info=ssid=s6999250240&pgvReferrer=; pgv_pvid=8376205210; ptisp=cnc; RK=TSV2VReGQG; ptcz=5fb0fb85fd284302bcf3e36c73674a7c2c8e760b5996d4820d51a0d6a89a46e5; pt2gguin=o0057265177; uin=o0057265177; skey=@8gJzLFREc; itkn=1899567436");
                request.KeepAlive = true;
                //上面的http头看情况而定，但是下面俩必须加  
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
                byte[] postData = encoding.GetBytes(dataString);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    ////如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
                    //if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                    //{
                    //    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    //}

                    using (StreamReader streamReader = new StreamReader(responseStream, encoding))
                    {
                        html = streamReader.ReadToEnd();

                        streamReader.Close();
                        responseStream.Close();
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return html;
        }
    }
}
