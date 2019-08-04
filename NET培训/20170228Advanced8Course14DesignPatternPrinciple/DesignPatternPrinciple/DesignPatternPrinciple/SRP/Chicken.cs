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
    public class Chicken
    {
        private string _Name = null;
        public Chicken(string name)
        {
            this._Name = name;
        }

        public void Breath()
        {
            Console.WriteLine("{0} 呼吸空气", this._Name);
        }

    }
}
