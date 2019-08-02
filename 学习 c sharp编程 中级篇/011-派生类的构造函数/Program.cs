using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_派生类的构造函数 {
    class Program {
        static void Main(string[] args) {//public private
            //DerivedClass o1 = new DerivedClass();
            //DerivedClass o2= new DerivedClass(1,2);
            //BaseClass o1 = new BaseClass();

            ClassXyz.z = 100;
            Console.WriteLine(ClassXyz.z);
            ClassXyz.TestMethod();

            Console.ReadKey();
        }
    }
}
