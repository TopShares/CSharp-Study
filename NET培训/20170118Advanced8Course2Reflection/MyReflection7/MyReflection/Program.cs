using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ruanmou.DB.Interface;
using Ruanmou.DB.Sqlserver;
using System.Diagnostics;

namespace MyReflection
{
    /// <summary>
    /// 1 dll-IL-metadata-反射
    /// 2 反射加载dll，读取module、类、方法、特性
    /// 3 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
    /// 4 反射调用实例方法、静态方法、重载方法 选修:调用私有方法 调用泛型方法
    /// 5 反射字段和属性，分别获取值和设置值
    /// 6 反射的好处和局限
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的反射Reflection");
                #region Common
                //DBHelper dbHelper = new DBHelper();
                //dbHelper.Id = 1;
                //dbHelper.Name = "仗劍走天涯";
                //dbHelper.Query();
                #endregion Common

                #region 反射加载dll，读取module、类、方法、特性
                Assembly assembly = Assembly.Load("Ruanmou.DB.Sqlserver");//1 动态加载     默认加载当前路径的dll文件，不需要后缀
                Assembly assembly1 = Assembly.LoadFile(@"E:\online7\20160928Advanced7Course2Reflection\MyReflection\MyReflection\bin\Debug\Ruanmou.DB.Sqlserver.dll");// 必须是完整路径
                Assembly assembly2 = Assembly.LoadFrom("Ruanmou.DB.Sqlserver.dll");// 可以是当前路径  也可以是完整路径

                Console.WriteLine("************GetModules**********");
                foreach (var item in assembly.GetModules())
                {
                    Console.WriteLine(item.FullyQualifiedName);
                }
                foreach (var item in assembly.GetTypes())
                {
                    Console.WriteLine(item.FullName);
                }
                Type typeDBHelper = assembly.GetType("Ruanmou.DB.Sqlserver.DBHelper");//2 获取类型 （获取类型信息的方式不止一个）
                foreach (var item in typeDBHelper.GetConstructors())
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in typeDBHelper.GetProperties())
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in typeDBHelper.GetMethods())
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in typeDBHelper.GetFields())
                {
                    Console.WriteLine(item.Name);
                }

                #endregion

                #region 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
                Console.WriteLine("**************************************************");
                {
                    object oDBHelper = Activator.CreateInstance(typeDBHelper);//3 创建对象
                    IDBHelper dbHelperReflection = (IDBHelper)oDBHelper;
                    dbHelperReflection.Query();

                    IDBHelper dbHelperFactory = SimpleFactory.CreateDBHelper();
                    dbHelperFactory.Query();
                }
                {
                    Console.WriteLine("**************带参数的构造函数****************");
                    Type typeTest = assembly.GetType("Ruanmou.DB.Sqlserver.ReflectionTest");//2 获取类型 （获取类型信息的方式不止一个）
                    foreach (var item in typeTest.GetConstructors())
                    {
                        Console.WriteLine(item.Name);
                    }
                    Activator.CreateInstance(typeTest);
                    Activator.CreateInstance(typeTest, "demon");
                    Activator.CreateInstance(typeTest, 11, "限量版(397-限量版)");
                    //Activator.CreateInstance(typeTest, "限量版(397-限量版)", 11);


                    Type typeSingleton = assembly.GetType("Ruanmou.DB.Sqlserver.Singleton");
                    Activator.CreateInstance(typeSingleton, true);
                    Activator.CreateInstance(typeSingleton, true);

                    Type typeGeneric = assembly.GetType("Ruanmou.DB.Sqlserver.GenericClass`1");
                    typeGeneric = typeGeneric.MakeGenericType(typeof(int));
                    Activator.CreateInstance(typeGeneric);
                }

                #region 反射调用实例方法、静态方法、重载方法 选修:调用私有方法 调用泛型方法
                {
                    Console.WriteLine("**************反射调用实例方法****************");
                    Type typeTest = assembly.GetType("Ruanmou.DB.Sqlserver.ReflectionTest");//2 获取类型 （获取类型信息的方式不止一个）
                    object oTest = Activator.CreateInstance(typeTest);

                    foreach (var item in typeTest.GetMethods())
                    {
                        Console.WriteLine(item.Name);
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show1");
                        method.Invoke(oTest, null);
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show2");
                        method.Invoke(oTest, new object[] { 11 });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("ShowStatic");
                        method.Invoke(null, new object[] { "KOBE→Bryant" });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { });
                        method.Invoke(oTest, null);
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { typeof(int) });
                        method.Invoke(oTest, new object[] { 11 });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { typeof(string) });
                        method.Invoke(oTest, new object[] { "限量版(397-限量版)" });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                        method.Invoke(oTest, new object[] { "书呆熊@拜仁", 22 });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { typeof(int), typeof(string) });
                        method.Invoke(oTest, new object[] { 33, "不懂微软" });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);
                        method.Invoke(oTest, new object[] { "有木有" });
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("ShowGeneric");
                        method = method.MakeGenericMethod(typeof(string));
                        method.Invoke(oTest, new object[] { "有木有" });
                    }
                }
                #endregion

                //DBHelper dbHelperReflection1 = oDBHelper as DBHelper;
                //dbHelperReflection1.Query();

                //oDBHelper.

                #endregion

                #region 反射字段和属性，分别获取值和设置值
                {
                    Console.WriteLine("**************反射字段和属性****************");
                    ReflectionTest test = new ReflectionTest();
                    test.Id = 11;
                    test.Name = "妙为";

                    Type typeTest = assembly.GetType("Ruanmou.DB.Sqlserver.ReflectionTest");
                    object oTest = Activator.CreateInstance(typeTest);
                    //foreach (var item in typeTest.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                    //{
                    //    Console.WriteLine(item.Name);
                    //}
                    foreach (var prop in typeTest.GetProperties())
                    {
                        Console.WriteLine(prop.GetValue(oTest));
                        Console.WriteLine(prop.Name);
                        if (prop.Name.Equals("Id"))
                        {
                            prop.SetValue(oTest, 22);
                        }
                        else if (prop.Name.Equals("Name"))
                        {
                            prop.SetValue(oTest, "Bond(331-object)");
                        }

                        Console.WriteLine(prop.GetValue(oTest));
                    }
                }


                #endregion


                #region 反射的好处和局限   好处就是动态
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100000; i++)
                    {
                        DBHelper dbHelper = new DBHelper();
                        dbHelper.Id = 1;
                        dbHelper.Name = "仗劍走天涯";
                        dbHelper.Query();
                    }
                    watch.Stop();
                    Console.WriteLine("普通方式花费{0}ms", watch.ElapsedMilliseconds);
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100000; i++)
                    {
                        Assembly assemblyTest = Assembly.Load("Ruanmou.DB.Sqlserver");

                        Type typeTest = assemblyTest.GetType("Ruanmou.DB.Sqlserver.DBHelper");
                        object oTest = Activator.CreateInstance(typeTest);

                        foreach (var prop in typeTest.GetProperties())
                        {
                            if (prop.Name.Equals("Id"))
                            {
                                prop.SetValue(oTest, 1);
                            }
                            else if (prop.Name.Equals("Name"))
                            {
                                prop.SetValue(oTest, "仗劍走天涯");
                            }
                        }
                        MethodInfo method = typeTest.GetMethod("Query");
                        method.Invoke(oTest, null);
                    }
                    watch.Stop();
                    Console.WriteLine("反射方式花费{0}ms", watch.ElapsedMilliseconds);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
