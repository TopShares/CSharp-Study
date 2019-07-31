using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//相关的命名空间
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace UnityAOP
{

    #region 【3】编写想注入的具体行为类

    /// <summary>
    /// 数据校验
    /// </summary>
    public class DataValidateHandler : ICallHandler
    {
        public int Order { get; set; }//决定方法的执行顺序

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //input是传入的参数
            CourseOrder order = input.Inputs[0] as CourseOrder;

            //校验过程
            if (order.StudentId.ToString().Length < 5)
            {
                return input.CreateExceptionMethodReturn(new Exception("学员学号不能小于5位！"));
            }
            if (order.CoursePrice < 0)
            {
                return input.CreateExceptionMethodReturn(new Exception("课程价格不能小于0！"));
            }
            Console.WriteLine("实体数据校验成功！");

            //前进到下一个注入的行为并返回结果
            return getNext.Invoke().Invoke(input, getNext); //简化写法：getNext()(input, getNext)

        }
    }
    /// <summary>
    /// 实体缓存
    /// </summary>
    public class CacheHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //input就是传入的参数
            CourseOrder order = input.Inputs[0] as CourseOrder;

            //在这里编写缓存写入的具体过程....

            Console.WriteLine("缓存写入成功！");

            return getNext()(input, getNext); //前进到下一个注入的行为,并返回结果
        }
    }
    /// <summary>
    /// 日志写入
    /// </summary>
    public class WriteLogHander : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //input就是传入的参数
            CourseOrder order = input.Inputs[0] as CourseOrder;

            //在这里编写日志的具体实现过程....


            Console.WriteLine("日志写入成功！");

            return getNext()(input, getNext);
        }
    }

    /// <summary>
    /// 异常处理
    /// </summary>
    public class ExceptionHander : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //首先调用下一个具体业务
            IMethodReturn returnValue = getNext()(input, getNext);

            //如果有异常，则展示异常信息
            if (returnValue.Exception != null)
            {
                Console.WriteLine($"异常信息：{returnValue.Exception.Message}");
            }
            else
            {
                Console.WriteLine("程序运行全部正确！");
            }

            return returnValue;
        }
    }

    #endregion

    #region 【4】为行为类设计对应的特性类

    public class DataValidateHendlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new DataValidateHandler { Order = this.Order };//返回想注入的具体行为
        }  
    }
    public class CacheHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CacheHandler { Order = this.Order };
        }
    }
    public class WriteLogHanderAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new WriteLogHander { Order = this.Order };
        }
    }
    public class ExceptionHanderAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionHander { Order = this.Order };
        }
    }

    #endregion

}
