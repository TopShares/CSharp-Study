using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern3
{
    /// <summary>
    /// 子类：现金折扣类
    /// </summary>
    public class RebateSettlement : SettlementAbstract
    {
        private double conditionMoney = 0.00;
        private double retrunMoney = 0.00;
        /// <summary>
        /// 在初始化的时候，需要说明满足条件的金额和返利金额
        /// </summary>
        /// <param name="conditionMoney">满足条件的金额</param>
        /// <param name="retrunMoney">返利的金额</param>
        public RebateSettlement(double conditionMoney, double retrunMoney)
        {
            this.conditionMoney = conditionMoney;
            this.retrunMoney = retrunMoney;
        }
        public override double Calculate(double money)
        {
            //800   300*2   200
            if (money >= conditionMoney)
            {
                //总金额 - (总金额/条件金额)取整数  * 返利金额
                return money - Math.Floor(money / conditionMoney) * retrunMoney;
            }
            else
            {
                return money;
            }
        }
    }
}
