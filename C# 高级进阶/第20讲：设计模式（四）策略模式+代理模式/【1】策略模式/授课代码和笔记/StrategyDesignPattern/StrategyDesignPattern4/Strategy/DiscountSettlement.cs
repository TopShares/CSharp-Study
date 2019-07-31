using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern4
{
    /// <summary>
    /// 子类：打折收费类
    /// </summary>
    public class DiscountSettlement : SettlementAbstract
    {
        private double discount = 0.0;

        /// <summary>
        /// 初始化的时候必须说明当前的折扣率
        /// </summary>
        /// <param name="discount"></param>
        public DiscountSettlement(string discount)
        {
            this.discount = Convert.ToDouble(discount);
        }

        public override double Calculate(double money)
        {
            return money * discount;
        }
    }
}
