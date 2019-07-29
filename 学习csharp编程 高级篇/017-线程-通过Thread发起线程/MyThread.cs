using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _017_线程_通过Thread发起线程 {
    class MyThread
    {
        private string filename;
        private string filepath;

        public MyThread(string fileName, string filePath)
        {
            this.filename = fileName;
            this.filepath = filePath;
        }

        public void DownFile()
        {
            Console.WriteLine("开始下载"+filepath+filename);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }

    }
}
