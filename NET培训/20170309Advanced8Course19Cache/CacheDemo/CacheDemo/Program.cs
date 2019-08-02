using Common;
using Ruanmou.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    /// <summary>
    /// 1 读写分离、分库分表、表分区
    /// 2 各种缓存
    /// 3 本地缓存原理和实现
    /// 4 作业
    /// 
    /// 本地缓存用在哪里：
    /// 1 查询多，修改少
    /// 2 不是要求很即时，容忍延迟
    /// 3 数据不是很多，，太多的话，，就得用分布式缓存
    /// 4 复杂计算(分析报表)后、远程接口、长时间的查询，数据多次查询，也该缓存
    /// 5 缓存可以读写，但是不能保存，因为不是硬盘(服务器重启  IIS死掉)
    /// 6 大批量数据操作，可以缓存后，多次一起操作(比如计数器)
    /// 
    /// 
    /// 缓存更新的问题：
    /// 首先  数据更新途径要统一，在这里可以更新缓存
    /// 然后  如果有不同的途径，得提供清理缓存的方式
    /// 其他  文件依赖、监听
    /// 最后，依赖时间过期，得容忍延迟
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的缓存的学习");
                {
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    List<Program> programList = DBHelper.Query<Program>();
                    //}

                }
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //List<Program> programList = RemoteHelper.Query<Program>();
                        List<Program> programList = null;
                        if (CacheManager.Contains("RemoteHelper"))
                        {
                            programList = CacheManager.GetData<List<Program>>("RemoteHelper");
                        }
                        else
                        {
                            programList = RemoteHelper.Query<Program>();
                            CacheManager.Add("RemoteHelper", programList);
                        }



                    }
                }
                //{
                //    List<Program> programList = DBHelper.Query<Program>();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
