using Ruanmou.Interface;
using System;
using System.Configuration;
using System.Reflection;

namespace Ruanmou.Project
{
    public class ObjectFactory
    {
        /// <summary>
        /// 简单工厂+配置文件+反射
        /// </summary>
        /// <returns></returns>
        public static IPhone CreatePhone()
        {
            string classModule = ConfigurationManager.AppSettings["iPhoneType"];
            Assembly assemly = Assembly.Load(classModule.Split(',')[1]);
            Type type = assemly.GetType(classModule.Split(',')[0]);
            return (IPhone)Activator.CreateInstance(type);
        }
    }
}
