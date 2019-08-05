using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern3
{
    /// <summary>
    /// 策略上下文类：完成策略的选择
    /// 好处：让客户端从两个类（工厂类+抽象类）的耦合降低到一个上下文类
    /// </summary>
    public class StrategyContext
    {
        //保存当前的应用策略对象
        private SettlementAbstract settlement = null;

        /// <summary>
        /// 初始化的时候，需要设置具体策略（参数就是策略类型）
        /// </summary>
        /// <param name="type"></param>
        public StrategyContext(string type)
        {
            if (type == "正常收费")
                settlement= new NormalSettlement();
            else if (type == "每满300减100")
                settlement = new RebateSettlement(300, 100);
            else if (type == "打8折")
                settlement = new DiscountSettlement(0.8);          
        }

        //进一步的提供一个入口：结算
        public double GetSettlementResult(double money)
        {
            return settlement.Calculate(money);
        }
    }
}
