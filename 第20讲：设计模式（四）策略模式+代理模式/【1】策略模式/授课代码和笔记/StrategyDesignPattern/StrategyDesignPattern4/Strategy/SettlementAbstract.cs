using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern4
{
    /// <summary>
    /// 抽象类：用于展示变化点的接口
    /// </summary>
    public abstract class SettlementAbstract
    {
        /// <summary>
        /// 抽象方法：根据传递的总金额，计算实际的收款额
        /// </summary>
        /// <param name="money">当前商品的金额</param>
        /// <returns></returns>
        public abstract double Calculate(double money);
    }
}
