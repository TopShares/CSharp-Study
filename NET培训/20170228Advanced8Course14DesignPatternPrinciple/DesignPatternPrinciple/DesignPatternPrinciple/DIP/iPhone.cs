using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    /// <summary>
    /// iPhone
    /// </summary>
    public class iPhone : AbstractPhone
    {
        public override void Call()
        {
            Console.WriteLine("User {0} Call", this.GetType().Name);
        }
        public override void Text()
        {
            Console.WriteLine("User {0} Call", this.GetType().Name);
        }
    }
}
