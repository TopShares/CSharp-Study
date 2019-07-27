using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Configuration;

namespace BLFacotry
{
    /// <summary>
    /// 产品工厂（根据接口库生成具体产品）
    /// </summary>
    public class ProductCreator
    {
        static string dalName = ConfigurationManager.AppSettings["dalAssemblyName"].ToString();


        //public static IBLInterface.IStudentLogic CreateStudent()
        //{
        //    return (IBLInterface.IStudentLogic)Assembly.Load(dalName).CreateInstance(dalName + ".StudentLogicImpl");
        //}
        //public static IBLInterface.ITeacherLogic CreateTeacher()
        //{
        //    return (IBLInterface.ITeacherLogic)Assembly.Load(dalName).CreateInstance(dalName + ".TeacherLogicImpl");
        //}

        //以上方法的个数取决于我们创建的接口实现类的个数，太繁琐。。。。。

        //前面我们学了高级泛型，大家会编写泛型方法

        public static T CreateLogicClass<T>(string className) where T : class
        {
            return (T)Assembly.Load(dalName).CreateInstance(dalName + "." + className);
        }

    }
}
