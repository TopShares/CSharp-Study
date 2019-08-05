using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteNotifications a = new ConcreteNotifications();
            a.Add(new ConcreteObserver(a, "A"));
            a.Add(new ConcreteObserver(a, "B"));
            a.Add(new ConcreteObserver(a, "C"));

            a.PulishedMessage = "大家来上课啦！";
            a.Notify();

            Console.Read();

        }
    }
}
