using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace StrategyDesignPattern4
{
    /// <summary>
    /// 策略上下文类：完成策略的选择
    /// 好处：让客户端从两个类（工厂类+抽象类）的耦合降低到一个上下文类
    /// </summary>
    public class StrategyContext
    {
        //保存当前的应用策略对象
        private SettlementAbstract settlement = null;

        //保存策略模型
        private List<StrategyModel> modelList = null;

        public StrategyContext()
        {
            //获取所有的策略模型（实际开发中这部分或者从配置文件中读取，获取从数据库中读取...)
            modelList = new List<StrategyModel>
            {
                 new StrategyModel
                 { StrategyName="正常收费",ClassName="NormalSettlement",Param="" },
                  new StrategyModel
                  { StrategyName="每满300减100",ClassName="RebateSettlement",Param="300, 100" },
                  new StrategyModel
                  { StrategyName="打8折",ClassName="DiscountSettlement",Param="0.8" }
            };
        }

        /// <summary>
        /// 初始化的时候，需要设置具体策略（参数就是策略类型）
        /// </summary>
        /// <param name="type"></param>
        public StrategyContext(string strategyName) : this()
        {
            //if (type == "正常收费")
            //    settlement= new NormalSettlement();
            //else if (type == "每满300减100")
            //    settlement = new RebateSettlement(300, 100);
            //else if (type == "打8折")
            //    settlement = new DiscountSettlement(0.8);     


            //找到当前的策略模型
            StrategyModel mode = (from m in modelList
                                  where m.StrategyName.Equals(strategyName)
                                  select m).First();
            //找到策略参数
            object[] param = null;
            if (mode.Param != null && mode.Param.Length != 0)
            {
                param = mode.Param.Split(',');
            }
            //基于反射创建策略对象
            settlement = (SettlementAbstract)Assembly.Load("StrategyDesignPattern4").
                CreateInstance("StrategyDesignPattern4." + mode.ClassName,
                false, BindingFlags.Default, null, param, null, null);

        }

        //进一步的提供一个入口：结算
        public double GetSettlementResult(double money)
        {
            return settlement.Calculate(money);
        }
    }
}
