using MyRedisDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisDemo
{
    ///<summary>
    /// 1 Cache和NoSql
    /// 2 String
    /// 3 Hashtable
    /// 4 Set
    /// 5 ZSet
    /// 6 List
    /// 7 分布式异步队列
    /// 
    /// REmote DIctionary Server
    /// ServiceStack.Redis
    /// 6000 Request per hour
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student_1 = new Student()
                {
                    Id = 11,
                    Name = "Eleven"
                };
                Student student_2 = new Student()
                {
                    Id = 12,
                    Name = "Twelve",
                    Remark = "123423245"
                };

                //Student_2_id  12  Student_2_Name  Twelve
                //需要修改对象
                //查询--反序列化--修改--序列化保存
                Console.WriteLine("*****************************************");
                {
                    //RedisStringService service = new RedisStringService();
                    //service.FlushAll();
                    //service.Set("RedisStringService_key1", "RedisStringService_value1");
                    //Console.WriteLine(service.Get("RedisStringService_key1"));
                    //Console.WriteLine(service.GetAndSetValue("RedisStringService_key1", "RedisStringService_value2"));
                    //Console.WriteLine(service.Get("RedisStringService_key1"));

                    //service.Append("RedisStringService_key1", "Append");
                    //Console.WriteLine(service.Get("RedisStringService_key1"));
                    //service.Set("RedisStringService_key1", "RedisStringService_value", DateTime.Now.AddSeconds(5));
                    //Console.WriteLine(service.Get("RedisStringService_key1"));
                    //Thread.Sleep(5000);
                    //Console.WriteLine(service.Get("RedisStringService_key1"));

                }

                Console.WriteLine("*****************************************");
                {
                    //RedisHashService service = new RedisHashService();
                    //service.FlushAll();
                    //service.SetEntryInHash("Student", "id", "13");
                    //service.SetEntryInHash("Student", "Name", "Thirteen");
                    //service.SetEntryInHashIfNotExists("Student", "Remark", "1234567");
                    //var listResult = service.GetHashValues("Student");
                    //listResult = service.GetHashKeys("Student");

                    //var dicList = service.GetAllEntriesFromHash("Student");

                    //service.SetEntryInHash("Student", "id", "14");//同一条数据，覆盖
                    //service.SetEntryInHash("Student", "Name", "Fourteen");
                    //service.SetEntryInHashIfNotExists("Student", "Remark", "2345678");//同一条数据，不覆盖

                    //listResult = service.GetHashValues("Student");
                    //service.RemoveEntryFromHash("Student", "Remark");
                    //service.SetEntryInHashIfNotExists("Student", "Remark", "2345678");
                    //listResult = service.GetHashValues("Student");

                    //service.StoreAsHash<Student>(student_1);
                    //Student student1 = service.GetFromHash<Student>(11);
                    //service.StoreAsHash<Student>(student_2);
                    //Student student2 = service.GetFromHash<Student>(12);
                }
                Console.WriteLine("*****************************************");
                {
                    ////key--values
                    //RedisSetService service = new RedisSetService();
                    //service.FlushAll();
                    //service.Add("Advanced", "111");
                    //service.Add("Advanced", "112");
                    //service.Add("Advanced", "113");
                    //service.Add("Advanced", "114");
                    //service.Add("Advanced", "115");
                    //service.Add("Advanced", "111");

                    //service.Add("Begin", "111");
                    //service.Add("Begin", "112");
                    //service.Add("Begin", "113");
                    //service.Add("Begin", "116");
                    //service.Add("Begin", "117");
                    //service.Add("Begin", "111");

                    //service.Add("Internal", "111");
                    //service.Add("Internal", "112");
                    //service.Add("Internal", "117");
                    //service.Add("Internal", "118");
                    //service.Add("Internal", "119");
                    //service.Add("Internal", "111");

                    //var result = service.GetAllItemsFromSet("Advanced");
                    //var result2 = service.GetRandomItemFromSet("Advanced");
                    //result = service.GetAllItemsFromSet("Begin");
                    //result2 = service.GetRandomItemFromSet("Begin");

                    //var result3 = service.GetIntersectFromSets("Advanced", "Begin", "Internal");//交
                    //result3 = service.GetDifferencesFromSet("Advanced", "Begin", "Internal");//差
                    //result3 = service.GetUnionFromSets("Advanced", "Begin", "Internal");//并

                    //service.RemoveItemFromSet("Advanced", "111");
                    //result = service.GetAllItemsFromSet("Advanced");
                    //service.RandomRemoveItemFromSet("Advanced");
                    //result = service.GetAllItemsFromSet("Advanced");
                }
                Console.WriteLine("*****************************************");
                {
                    //RedisZSetService service = new RedisZSetService();
                    //service.FlushAll();
                    //service.Add("score", "111");
                    //service.Add("score", "112");
                    //service.Add("score", "113");
                    //service.Add("score", "114");
                    //service.Add("score", "115");
                    //service.Add("score", "111");

                    //service.AddItemToSortedSet("user", "Eleven1", 1);

                    //service.AddItemToSortedSet("user", "Eleven2", 2);

                    //var list = service.GetAll("score");
                    //list = service.GetAllDesc("score");
                }
                Console.WriteLine("*****************************************");
                {
                    RedisListService service = new RedisListService();
                    service.FlushAll();

                    List<string> stringList = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        stringList.Add(string.Format("放入任务{0}", i));
                    }

                    service.LPush("test", "这是一个学生1");
                    service.LPush("test", "这是一个学生2");
                    service.LPush("test", "这是一个学生3");
                    service.LPush("test", "这是一个学生4");
                    service.Add("task", stringList);

                    //Console.WriteLine(service.Count("test"));
                    //Console.WriteLine(service.Count("task"));
                    //var list = service.Get("test");
                    //list = service.Get("task", 2, 4);


                    //new Action(() =>
                    //{
                    //    while (true)
                    //    {
                    //        var result = service.BlockingPopItemFromLists(new string[] { "test", "task" }, TimeSpan.FromHours(3));
                    //        Console.WriteLine("这里是队列获取的消息 {0} {1}", result.Id, result.Item);
                    //    }
                    //}).BeginInvoke(null, null);

                    Action act = new Action(() =>
                     {
                         while (true)
                         {
                             Console.WriteLine("************请输入数据**************");
                             string testTask = Console.ReadLine();
                             service.LPush("test", testTask);
                         }
                     });
                    act.EndInvoke(act.BeginInvoke(null, null));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
