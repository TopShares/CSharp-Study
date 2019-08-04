using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    public class M8 : AbstractPhone, IExtend
    {
        public override void Call()
        {
            Console.WriteLine("User {0} Call", this.GetType().Name);
        }

        public override void Text()
        {
            Console.WriteLine("User {0} Call", this.GetType().Name);
        }

        public void Photo()
        {
            Console.WriteLine("User {0} Photo", this.GetType().Name);
        }

        public void Online()
        {
            Console.WriteLine("User {0} Online", this.GetType().Name);
        }

        public void Game()
        {
            Console.WriteLine("User {0} Game", this.GetType().Name);
        }

        //public void Map()
        //{
        //    Console.WriteLine("对不起，我没有这个功能");
        //    //Console.WriteLine("User {0} Map", this.GetType().Name);
        //}

        //public void Pay()
        //{
        //    Console.WriteLine("对不起，我没有这个功能");
        //    //Console.WriteLine("User {0} Pay", this.GetType().Name);
        //}

        public void Record()
        {
            Console.WriteLine("User {0} Record", this.GetType().Name);
        }

        public void Movie()
        {
            Console.WriteLine("User {0} Movie", this.GetType().Name);
        }
    }
}
