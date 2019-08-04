using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Delegate
{



    /// <summary>
    /// 轿车工厂
    /// </summary>
    public class CarFactory
    {

        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ElevenWhere<TSource>(IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            List<TSource> studentList = new List<TSource>();
            foreach (TSource item in source)
            {
                bool bResult = func.Invoke(item);
                if (bResult)
                {
                    studentList.Add(item);
                }
            }
            return studentList;
        }

        /// <summary>
        /// 通用的异常处理
        /// </summary>
        /// <param name="act">对应任何的逻辑</param>
        public static void SafeInvoke(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)//按异常类型区分处理
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 生成轿车,
        /// 发动机分三种类型：自然吸气  涡轮增压  电动
        /// 
        /// 传递一个参数给我，然后我来执行不同的逻辑
        /// 传递一个逻辑给我，我去执行
        /// </summary>
        public void BuildCar(BuildEngineDelegate method)
        {

            new List<int>().Where(t => t > 1);

            Console.WriteLine("这里是东风日产乘用车工厂");
            //BuildEngine(engineType);

            //if (engineType == EngineType.NaturalInspiration)
            //{
            //    Console.WriteLine("造一个自然吸气发动机");
            //}
            //else if (engineType == EngineType.Turbo)
            //{
            //    Console.WriteLine("造一个涡轮增压发动机");
            //}
            //else if (engineType == EngineType.Electric)
            //{
            //    Console.WriteLine("造一个电池发动机");
            //}
            method.Invoke();


            Console.WriteLine("造一个外壳");

            Console.WriteLine("造一个底盘");

            Console.WriteLine("造四个轮子");

            Console.WriteLine("组装成一辆车");

            Console.WriteLine("造好了一辆GTR。。");
        }


        public delegate void BuildEngineDelegate();


        public void BuildEngineNaturalInspiration()
        {
            Console.WriteLine("造一个自然吸气发动机");
        }
        public void BuildEngineTurbo()
        {
            Console.WriteLine("造一个涡轮增压发动机");
        }
        public void BuildEngineElectric()
        {
            Console.WriteLine("造一个电池发动机");
        }
        public void BuildEngineFuture()
        {
            Console.WriteLine("造一个光发动机");
        }

        //private void BuildEngine(EngineType engineType)
        //{
        //    if (engineType == EngineType.NaturalInspiration)
        //    {
        //        Console.WriteLine("造一个自然吸气发动机");
        //    }
        //    else if (engineType == EngineType.Turbo)
        //    {
        //        Console.WriteLine("造一个涡轮增压发动机");
        //    }
        //    else if (engineType == EngineType.Electric)
        //    {
        //        Console.WriteLine("造一个电池发动机");
        //    }

        //}
    }

    public enum EngineType
    {
        NaturalInspiration = 0,
        Turbo = 1,
        Electric = 2

    }
}
