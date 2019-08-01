using MyAttribute.AOPWay;
using MyAttribute.AttributeExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 1 特性attribute，和注释有什么区别
    /// 特性可以影响编译
    /// 特性可以影响运行
    /// 2 声明和使用attribute
    /// 3 应用attribute
    /// 特性就是在不影响类型封装的前提下，额外的添加一些信息
    /// 如果你用这个信息，那特性就有用，
    /// 如果你不管这个信息，那特性就没用
    /// 
    /// 4 AOP面向切面编程 
    /// Aspect Oriented Programming
    /// OOP 面向对象编程
    /// 
    /// 5 多种方式实现AOP
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天的内容是特性和AOP");
                People people = new People();

                UserModel user = new UserModel();
                user.Id = 1;

                string name = user.GetTableName<UserModel>();

                string remark = UserState.Normal.GetRemark();

                BaseDAL.Save<UserModel>(user);


                #region AOP show
                Console.WriteLine("***********************");
                Decorator.Show();
                Console.WriteLine("***********************");
                Proxy.Show();
                Console.WriteLine("***********************");
                CastleProxy.Show();
                Console.WriteLine("***********************");
                UnityAOP.Show();
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
