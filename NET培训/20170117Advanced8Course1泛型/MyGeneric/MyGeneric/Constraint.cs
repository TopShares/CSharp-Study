using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Constraint
    {
        /// <summary>
        /// 泛型约束，基类约束：
        /// 1 在泛型方法内可以直接使用基类的属性和方法
        /// 2 调用的时候，只能传递基类或者基类的子类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) where T : People, IWork
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
            //((People)tParameter).Id
            //tParameter.
            Console.WriteLine("id={0} name={1}", tParameter.Id, tParameter.Name);
            tParameter.Hi();

            tParameter.Work();
            //tParameter.Id
            //tParameter.Name
        }


        private void Linq()
        {
            
        }



        public static void ShowPeople(People tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
            //((People)tParameter).Id
            //tParameter.
            Console.WriteLine("id={0} name={1}", tParameter.Id, tParameter.Name);
            tParameter.Hi();

            //tParameter.Work();
            //tParameter.Id
            //tParameter.Name
        }


        public static void ShowInterface<T>(T tParameter) where T : ISports
        {

            tParameter.Pingpang();
        }
        public static T Get<T>(T tParameter)
        //where T : new()//无参数构造
        //where T : class//引用类型
        //where T : struct//值类型
        {
            //T t = new T();
            //return t;

            //return null;

            return default(T);
            //return tParameter;
        }

        /// <summary>
        /// 多重约束，，是而且的关系 and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Many<T>() where T : class, ISports, IWork, new()
        {


        }

    }
}
