using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.DB.Sqlserver
{
    /// <summary>
    /// 反射测试类
    /// </summary>
    public class ReflectionTest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Field = null;
        public static string FieldStatic = null;


        #region 构造函数
        public ReflectionTest()
        {
            Console.WriteLine("这里是{0}无参数构造函数", this.GetType());
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine("这里是{0} 有参数构造函数", this.GetType());
        }

        public ReflectionTest(int id, string name)
        {
            Console.WriteLine("这里是{0} 有参数构造函数", this.GetType());
        }
        #endregion

        public static void ShowStatic(string name)
        {
            Console.WriteLine("这里是{0}的ShowStatic", typeof(ReflectionTest));
        }

        public void ShowGeneric<T>(string name)
        {
            Console.WriteLine("这里是{0}的ShowStatic  T={1}", this.GetType(), typeof(T));
        }

        public void Show1()
        {
            Console.WriteLine("这里是{0}的Show1", this.GetType());
        }

        public void Show2(int id)
        {

            Console.WriteLine("这里是{0}的Show2", this.GetType());
        }

        public void Show3()
        {
            Console.WriteLine("这里是{0}的Show3_1", this.GetType());
        }

        public void Show3(int id, string name)
        {
            Console.WriteLine("这里是{0}的Show3", this.GetType());
        }

        public void Show3(string name, int id)
        {
            Console.WriteLine("这里是{0}的Show3_2", this.GetType());
        }

        public void Show3(int id)
        {

            Console.WriteLine("这里是{0}的Show3_3", this.GetType());
        }

        public void Show3(string name)
        {

            Console.WriteLine("这里是{0}的Show3_4", this.GetType());
        }

        private void Show4(string name)
        {
            Console.WriteLine("这里是{0}的Show4", this.GetType());
        }

    }
}
