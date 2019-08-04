using Ruanmou.SearchEngines.LuceneService.DataService;
using Ruanmou.SearchEngines.LuceneService.Interface;
using Ruanmou.SearchEngines.LuceneService.Model;
using Ruanmou.SearchEngines.LuceneService.Service;
using Ruanmou.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ruanmou.SearchEngines.LuceneService.Processor
{
    public class IndexBuilder
    {
        private static Logger logger = new Logger(typeof(IndexBuilder));
        private static List<string> PathSuffixList = new List<string>();
        private static CancellationTokenSource CTS = null;

        public static void BuildIndex(CancellationTokenSource cts = null)
        {
            try
            {
                logger.Debug(string.Format("{0} BuildIndex开始", DateTime.Now));

                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = new TaskFactory();
                CTS = cts == null ? new CancellationTokenSource() : cts;

                //直接循环线程数n，，每个线程数都是从第一张表开始，，1000条每次，，
                //然后每次间隔 n*1000来获取，，如果获取的数据小于1000，，直接去下一张表，，
                /*
                 foreach(thread in N)//N个线程
                 {    //线程1
                 * //下面是Task
                      for (int i = 1; i < 31; i++)//30张表
                    {
                 *      //表1
                     * while(true)
                     * {
                     * Get(1000)；//1到1000
                     * Skip(1000*n*1) Get(1000)
                      
                     * 把一张表分成N页  每个线程获取一页
                     * 获取的数据<1000  就去下一张表 break
                     * }
                        }
                     }
                 */


                for (int i = 1; i < 31; i++)
                {
                    

                    IndexBuilderPerThread thread = new IndexBuilderPerThread(i, i.ToString("000"), CTS);
                    PathSuffixList.Add(i.ToString("000"));
                    taskList.Add(taskFactory.StartNew(thread.Process));//开启一个线程   里面创建索引
                }
                taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), MergeIndex));
                Task.WaitAll(taskList.ToArray());
                logger.Debug(string.Format("BuildIndex{0}", CTS.IsCancellationRequested ? "失败" : "成功"));
            }
            catch (Exception ex)
            {
                logger.Error("BuildIndex出现异常", ex);
            }
            finally
            {
                logger.Debug(string.Format("{0} BuildIndex结束", DateTime.Now));
            }
        }

        private static void MergeIndex(Task[] tasks)
        {
            try
            {
                if (CTS.IsCancellationRequested) return;
                ILuceneBulid builder = new LuceneBulid();
                builder.MergeIndex(PathSuffixList.ToArray());
            }
            catch (Exception ex)
            {
                CTS.Cancel();
                logger.Error("MergeIndex出现异常", ex);
            }
        }
    }
}
