using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPTeachDemo
{
    /// <summary>
    /// 学员订单接口
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int SubmitOrder(CourseOrder order);
        /// <summary>
        /// 查询所有的订单列表
        /// </summary>
        /// <returns></returns>
        List<CourseOrder> GetAllOrders();
    }
}
