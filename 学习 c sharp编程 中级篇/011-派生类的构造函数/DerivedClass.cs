using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_派生类的构造函数 {
    class DerivedClass:BaseClass
    {
        private int y;
        public DerivedClass()//调用父类中无参的构造函数 当我们没有在子类的构造函数中显示声明调用父类的构造函数，默认会调用父类中的无参构造函数
        {
            Console.WriteLine("这个是DerivedClass 无参的构造函数");   
        }

        public DerivedClass(int x, int y):base(x)
        {
            this.y = y;
            base.z = 100;
            Console.WriteLine("y赋值完成");
        }
    }
}
