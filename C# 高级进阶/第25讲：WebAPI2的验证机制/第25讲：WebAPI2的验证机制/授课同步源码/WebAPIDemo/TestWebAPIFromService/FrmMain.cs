using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace TestWebAPIFromService
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        //通过服务端调用API的基本过程
        private void btnCallAPI_Click(object sender, EventArgs e)
        {
            //【1】定义要使用的URL
            string url = "http://localhost:12496/api/Score/QueryStudent";

            //【2】封装要传递的数据，需要以JSON格式并且要做编码规范（保证不会出现中文乱码）
            var student = new
            {
                Score = 100,
                StudentId = 2000,
                StudentName = "tidy",
                CSharp = 80,
                DB = 90
            };
            string jsonData = new JavaScriptSerializer().Serialize(student);
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);

            //【3】创建请求对象，并设置相关的属性
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "post";
            webRequest.ContentType="application/json";
            webRequest.ContentLength = byteArray.Length;

            //【4】获取字节流对象，并向流中写入数据
            Stream byteStream = webRequest.GetRequestStream();
            byteStream.Write(byteArray, 0, byteArray.Length);
            byteStream.Close();

            //【5】创建响应对象
            WebResponse webResponse = webRequest.GetResponse();

            //【6】转换成http请求响应
            var httpWebRespose = (HttpWebResponse)webResponse;

            //【7】如果请求成功，则读取所有数据
            if (httpWebRespose.StatusCode == HttpStatusCode.OK)
            {
                //7.1 获取返回的数据流
                byteStream = webResponse.GetResponseStream();
                //7.2 根据返回的数据流创建读取器
                StreamReader reader = new StreamReader(byteStream, Encoding.UTF8);
                //7.3 读取所有数据
                string readContentFromServer = reader.ReadToEnd();

                //显示结果(也可以继续传递...)
                this.txtReturnContent.Text = readContentFromServer;
            }
            else
            {
                //可以自己进一步处理
            }

        }
    }
}
