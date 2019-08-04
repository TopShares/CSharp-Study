using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    /// <summary>
    /// 动物类
    /// 简单意味着稳定
    /// </summary>
    public class Fish
    {
        private string _Name = null;
        public Fish(string name)
        {
            this._Name = name;
        }

        /// <summary>
        /// 如果逻辑够简单，方法级别可以违背单一职责
        /// </summary>
        public void Breath()
        {
            Console.WriteLine("{0} 呼吸水", this._Name);
        }

    }
}
