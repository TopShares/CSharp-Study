using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  _006_类的定义和声明;

namespace _007_匿名类型 {
    class Program {
        static void Main(string[] args)
        {
            int i = 100;
            var j = 1000;
            j = 89;
            //j = "sdf";//这里不允许，以为j的类型已经被确定下来是int类型了
            var a = "sdfdf";
            var v1 = new Vector3();
        }
    }
}
