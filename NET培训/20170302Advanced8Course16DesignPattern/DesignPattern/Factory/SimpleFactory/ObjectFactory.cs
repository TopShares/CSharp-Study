using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using FactoryPattern.War3.ServiceExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.SimpleFactory
{
    public class ObjectFactory
    {
        public static IRace CreateInstance(RaceType type)
        {
            IRace iRace = null;
            switch (type)
            {
                case RaceType.Human:
                    iRace = new Human("123");
                    break;
                case RaceType.NE:
                    iRace = new NE();
                    break;
                case RaceType.ORC:
                    iRace = new ORC();
                    break;
                case RaceType.Undead:
                    iRace = new Undead();
                    break;
                case RaceType.Five:
                    iRace = new Five();
                    break;
                default:
                    throw new Exception("wrong RaceType");
            }
            return iRace;
        }

        //简单工厂+配置文件

        //简单工厂+配置文件+反射
    }

    public enum RaceType
    {
        Human = 0,
        NE = 1,
        ORC = 2,
        Undead = 3,
        Five = 4
    }
}
