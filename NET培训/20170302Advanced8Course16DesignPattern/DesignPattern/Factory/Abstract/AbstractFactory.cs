using FactoryPattern.War3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    /// <summary>
    /// 产品簇
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract IArmy CreateArmy();
        public abstract IRace CreateRace();

        //public abstract IHero CreateHero();
    }
}
