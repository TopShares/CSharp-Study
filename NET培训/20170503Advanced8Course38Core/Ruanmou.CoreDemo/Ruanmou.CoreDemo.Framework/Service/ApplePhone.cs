using Ruanmou.CoreDemo.Framework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.CoreDemo.Framework.Service
{
    public class ApplePhone : IPhone
    {
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }

        public ApplePhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }

        public ApplePhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0}带参数构造函数", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name); ;
        }

        public void Init1234(IPower power)
        {
            this.iPower = power;
        }
    }
}
