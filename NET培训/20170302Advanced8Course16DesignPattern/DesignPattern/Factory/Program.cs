using Factory.Abstract;
using Factory.FactoryMethod;
using Factory.SimpleFactory;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /// <summary>
    /// 三大工厂
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是设计模式的学习");
                {
                    IRace race = ObjectFactory.CreateInstance(RaceType.Human);// new Human();
                    race.ShowKing();
                }
                {
                    IRace race = ObjectFactory.CreateInstance(RaceType.ORC);// new Human();
                    race.ShowKing();
                }
                {
                    IRace race = ObjectFactory.CreateInstance(RaceType.NE);// new Human();
                    race.ShowKing();
                }

                {
                    Human human = new Human("123");

                    IFactory facetory = new HumanFactory();
                    IRace race = facetory.CreateRace();
                    race.ShowKing();
                }
                {
                    //Human human = new Human();

                    IFactory facetory = new FiveFactory();
                    IRace race = facetory.CreateRace();
                    race.ShowKing();
                }
                {
                    AbstractFactory factory = new AHumanFactory();
                    IRace race = factory.CreateRace();
                    race.ShowKing();
                    IArmy army = factory.CreateArmy();
                    army.BuildArmy();
                }
                {
                    AbstractFactory factory = new AUndeadFactory();
                    IRace race = factory.CreateRace();
                    race.ShowKing();
                    IArmy army = factory.CreateArmy();
                    army.BuildArmy();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
