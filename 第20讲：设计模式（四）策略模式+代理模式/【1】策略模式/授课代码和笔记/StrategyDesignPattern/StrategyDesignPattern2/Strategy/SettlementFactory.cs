using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern2
{
    /// <summary>
    /// 策略工厂：返回具体的策略对象
    /// </summary>
    public class SettlementFactory
    {
        public static SettlementAbstract GetSettlementType(string type)
        {
            if (type == "正常收费")
                return new NormalSettlement();
            else if (type == "每满300减100")
                return new RebateSettlement(300, 100);
            else if (type == "打8折")
                return new DiscountSettlement(0.8);
            return null;
        }
    }
}
