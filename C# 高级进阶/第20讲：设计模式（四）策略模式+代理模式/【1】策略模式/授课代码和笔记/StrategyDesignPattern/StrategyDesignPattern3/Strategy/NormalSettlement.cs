using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern3
{
    /// <summary>
    /// 子类：正常收费
    /// </summary>
    public class NormalSettlement : SettlementAbstract
    {
        public override double Calculate(double money)
        {
            return money;
        }
    }
}
