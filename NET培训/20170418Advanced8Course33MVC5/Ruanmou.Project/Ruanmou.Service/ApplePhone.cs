using Microsoft.Practices.Unity;
using Ruanmou.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Service
{
    public class ApplePhone : IPhone
    {
        [Dependency]//属性注入
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }

        public ApplePhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }

        //[InjectionConstructor]//构造函数注入
        public ApplePhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0}带参数构造函数", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name); ;
        }

        [InjectionMethod]//方法注入
        public void Init1234(IPower power)
        {
            this.iPower = power;
        }
    }
}
