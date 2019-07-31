using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonChainOfResponsibility
{
    /// <summary>
    /// 经理通用类
    /// </summary>
    public class Manager
    {
        public string PostName { get; set; }//职位名称
        public int RightCount { get; set; }//权限天数

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool RequestAction(Request request)
        {
            if (request.DayCount <= RightCount)//如果你的请加天数在我的权限范围内
            {
                Console.WriteLine($"{request.Name } {request.DayCount}天， 被 {PostName} 批准！");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
