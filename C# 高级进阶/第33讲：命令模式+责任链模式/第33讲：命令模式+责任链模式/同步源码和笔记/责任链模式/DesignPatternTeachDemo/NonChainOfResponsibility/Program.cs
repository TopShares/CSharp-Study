using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Manager> mList = new List<Manager>
            {
                    new Manager {  PostName="部门经理", RightCount=3},
                    new Manager {  PostName="人事经理", RightCount=6},
                    new Manager {  PostName="总经理", RightCount=7}
            };

            //发出一个请假
            Request request = new Request { Name = "外出", DayCount = 4 };

            //请假流转
            foreach (var manager in mList)
            {
                if (manager.RequestAction(request))
                    break;
            }
            Console.Read();
        }
    }
}
