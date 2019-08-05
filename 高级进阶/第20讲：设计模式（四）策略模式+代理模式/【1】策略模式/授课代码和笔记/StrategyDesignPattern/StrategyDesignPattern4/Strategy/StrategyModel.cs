using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern4
{
    /// <summary>
    /// 策略模型
    /// </summary>
    public class StrategyModel
    {
        /// <summary>
        /// 策略名称
        /// </summary>
        public string StrategyName { get; set; }
        /// <summary>
        /// 对应的策略类名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 策略参数
        /// </summary>
        public string Param { get; set; }

    }
}
