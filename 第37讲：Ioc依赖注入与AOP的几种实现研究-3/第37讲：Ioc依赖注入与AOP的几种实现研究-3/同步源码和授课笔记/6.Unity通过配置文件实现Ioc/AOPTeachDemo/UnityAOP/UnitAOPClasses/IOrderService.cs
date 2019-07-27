using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAOP
{
    /// <summary>
    /// 学员订单接口:通过Order参数大小决定执行的先后顺序
    /// </summary>
    [CacheHandler(Order = 2)]
    [DataValidateHendler(Order = 1)]
    [ExceptionHander(Order =3)]
    [WriteLogHander(Order =4)]
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
