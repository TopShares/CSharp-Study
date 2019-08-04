using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SOA.UnitTest.Web
{
    [TestClass]
    public class WebApiTest
    {
        private static string UrlPrefix = "http://localhost:10008/";

        [TestMethod]
        public void TestMethod()
        {
            //Console.WriteLine(doGetAsync().Result);
            Console.WriteLine(doGet());
            //Console.WriteLine(doPostAsync().Result);
            Console.WriteLine(doPostId());
            Console.WriteLine(doPostUser());
            string putResultAsync = doPutAsync().Result;
            string putResult = doPut();
            //Console.WriteLine();
        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        static async Task<string> doGetAsync()
        {
            string url = "http://localhost:10008/api/users/?username=superman";
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler();//{ AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                return await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// HttpWebRequest实现Get请求
        /// </summary>
        static string doGet()
        {
            string url = "http://localhost:10008/api/users/?username=superman";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30 * 1000;
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        static async Task<string> doPostAsync()
        {
            string url = "http://localhost:10008/api/users/register";
            var userId = "1";
            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                {
                  {"", userId}//键名必须为空
                 });

                //await异步等待回应

                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                return await response.Content.ReadAsStringAsync();
            }

        }

        /// <summary>
        /// HttpWebRequest实现post请求
        /// </summary>
        static string doPost()
        {
            string url = "http://localhost:10008/api/users/register";
            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            //request.Headers.Add("Postdata", postData);
            request.Method = "POST";

            var userId = "1";
            var postData = userId;// string.Format("{{\"id\":{0}}}", userId);// 
            byte[] data = Encoding.Default.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        static string doPostId()
        {
            string url = "http://localhost:10008/api/users/register";
            var userId = "1";
            var postData = userId;// string.Format("{{\"id\":{0}}}", userId);// 
            return doPostBase(url, postData);
        }

        static string doPostUser()
        {
            string url = "http://localhost:10008/api/users/RegisterUser";
            Users user = new Users()
            {
                UserID = 123,
                UserEmail = "57265177@qq.com",
                UserName = "Eleven"
            };
            var postData = string.Format("{{\"\":\"{0}\"}}", string.Format("UserID={0}&UserEmail={1}&UserName={2}", user.UserID, user.UserEmail, user.UserName));// Newtonsoft.Json.JsonConvert.SerializeObject(user));// 
            return doPostBase(url, postData);
        }

        public class Users
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
        }

        static string doPostBase(string url, string postData)
        {

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            //request.Headers.Add("Postdata", postData);
            request.Method = "POST";
            byte[] data = Encoding.Default.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        static async Task<string> doPutAsync()
        {
            try
            {
                string url = "http://localhost:10008/api/users/RegisterUserPut?id=" + 1;
                var userId = "1";
                var handler = new HttpClientHandler();//{ AutomaticDecompression = DecompressionMethods.GZip };
                using (var http = new HttpClient(handler))
                {
                    var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                    {
                       {"", userId}//键名必须为空
                    });

                    var response = await http.PutAsync(url, content);
                    response.EnsureSuccessStatusCode();//确保HTTP成功状态值
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static string doPut()
        {
            string url = "http://localhost:10008/api/users/RegisterUserPut?id=" + 1;
            var postData = "1";
            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            //request.Headers.Add("Postdata", postData);
            request.Method = "PUT";
            byte[] data = Encoding.Default.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}