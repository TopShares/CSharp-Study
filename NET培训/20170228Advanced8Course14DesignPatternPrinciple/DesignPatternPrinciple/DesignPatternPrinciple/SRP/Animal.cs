using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
    /// <summary>
    /// 封装
    /// 动物类
    /// 简单意味着稳定
    /// </summary>
    public class Animal
    {
        private string _Name = null;
        public Animal(string name)
        {
            this._Name = name;
        }

        /// <summary>
        /// 如果逻辑够简单，方法级别可以违背单一职责
        /// </summary>
        public void Breath()
        {
            if (this._Name.Equals("鱼"))
            {
                Console.WriteLine("{0} 呼吸水", this._Name);
            }
            else if (this._Name.Equals("鸡"))
            {
                Console.WriteLine("{0} 呼吸空气", this._Name);
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 类的角度来说，违背单一职责
        /// 如果类的方法不多，逻辑简单，类级别可以违背单一职责
        /// </summary>
        public void BreathFish()
        {
            Console.WriteLine("{0} 呼吸水", this._Name);
        }

        public void BreathChicken()
        {
            Console.WriteLine("{0} 呼吸空气", this._Name);
        }

        //委托对逻辑解耦
    }
}
