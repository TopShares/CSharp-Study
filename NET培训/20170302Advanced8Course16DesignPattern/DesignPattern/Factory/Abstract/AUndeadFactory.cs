using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    public class AUndeadFactory : AbstractFactory
    {
        public override IArmy CreateArmy()
        {
            return new UndeadArmy();
        }
        public override IRace CreateRace()
        {
            return new Undead();
        }
    }
}
