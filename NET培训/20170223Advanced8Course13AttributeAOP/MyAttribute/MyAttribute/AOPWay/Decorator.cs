using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AOPWay
{
    /// <summary>
    /// 装饰器模式实现静态代理
    /// AOP 在方法前后增加自定义的方法
    /// </summary>
    public class Decorator
    {
        public static void Show()
        {
            User user = new User() { Name = "Eleven", Password = "123123123123" };
            IUserProcessor processor = new UserProcessor();
            processor = new UserProcessorDecorator(processor);
            processor.RegUser(user);
        }

        public interface IUserProcessor
        {
            void RegUser(User user);
        }
        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。Name:{0},PassWord:{1}", user.Name, user.Password);
            }
        }

        /// <summary>
        /// 装饰器的模式去提供一个AOP功能
        /// </summary>
        public class UserProcessorDecorator : IUserProcessor
        {
            private IUserProcessor UserProcessor { get; set; }
            public UserProcessorDecorator(IUserProcessor userprocessor)
            {
                UserProcessor = userprocessor;
            }

            public void RegUser(User user)
            {
                PreProceed(user);
                try
                {
                    this.UserProcessor.RegUser(user);
                }
                catch (Exception)
                {

                    throw;
                }
                PostProceed(user);
            }

            public void PreProceed(User user)
            {
                Console.WriteLine("方法执行前");
            }

            public void PostProceed(User user)
            {
                Console.WriteLine("方法执行后");
            }
        }

    }
}
