using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using FactoryPattern.War3.ServiceExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public class FiveFactory : IFactory
    {
        public IRace CreateRace()
        {
            return new Five();
        }
    }
}
