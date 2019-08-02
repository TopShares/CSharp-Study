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
                request.Headers.Add("Cookie", @"tvfe_boss_uuid=a3843ffa9475a6b6; qqmusic_uin=0057265177; qqmusic_key=@JfPbTI3qw; qqmusic_fromtag=6; pac_uid=1_2922612671; o_cookie=2922612671; FTN5K=93f8dcf1; p_uin=o0057265177; p_skey=QLepIsA9eFYQKEvOfkxKxTQe45J1wsUaeGOq2DNOfCU_; pt4_token=MMX20ic4FjQr1YTa5iltCaRImN4AYiCTKavivyrx7uM_; verifysession=h0138f3806c12ad2bab4e49c6237eb91a65686c20b75416830d24e1ea6682d9be8dfbc6498a6e5e5086; RK=jTV+RReXFG; ptisp=cnc; ptcz=75f775a5ba2412fa9431b112ad1a4d7cfd48a28f43e44d77c67bea81c28833d1; pt2gguin=o0057265177; uin=o0057265177; skey=@lbR9LDQeX; pgv_info=ssid=s4244891222; pgv_pvid=2503155250");

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
                string url = "http://qun.qq.com/cgi-bin/group_search/pc_group_search";
                int sort = 2;//人数
                string dataString = string.Format("keyword={0}&n=24&st=1&sort={1}&iso=0&src=1&v=4093&p={2}&isRecommend=false&bkn=11061692&city_id=0&from=1&ldw=11061692&k={3}", keyword, sort, page,"交友");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Referer = "http://find.qq.com/index.html";
                request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
                request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
                request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";

                request.Headers.Add("Cookie", @"game_market_hislocation=http://game-web.qq.com/market/inc/index_main_2.html; game_market_gender=2; game_market_realgender=2; firstlogin=1; subUser=1; user_id=null; session_id=null; qqmusic_uin=; qqmusic_key=; qqmusic_fromtag=; pt_login_sig=SEzPg9hfRwmeWC-Ss4wGdyuFOtRitUQJlvYLr1KSEN2WMTlJqQdfK-C6ZHCGSMvf; FTN5K=2a172f8d; ptui_loginuin=2755858464; qm_sid=2ff86200932e3631beebf306d62c4a10,qd2hZc0dPTllvejRmQzMqRHN1YnJSM0VoV2RWenB3eDZjMjd5a2d3SERLWV8.; verifysession=h01c2d0abcafa50fa17582b90d9ccf320d87991753e0ccfcdfea5c366ff71e4fe28031cadd7d8e985917ef6423a4dad8a75; qm_username=57265177; RK=LbU2BTe3Xk; ptwebqq=4f1351808b7b9ffc44d5b0b41d0642207ead29374980987c60eddf9ea68eab49; pgv_pvi=2252787712; pgv_si=s1256762368; pgv_info=ssid=s916654622; pgv_pvid=6743316430; o_cookie=57265177; qz_gdt=tykjcvsdaaaiktrgtkzq; pt_clientip=14480a821c36b432; pt_serverip=4a580a85030c4445; ptisp=ctc; ptcz=3836462b262c19773ea384242e1be6734a8f4529c8d31243a5e60a8cf05f87c7; pt2gguin=o2814208296; uin=o2814208296; skey=@EOtaf2acY; itkn=3070620291");
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
