using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_派生类的构造函数 {
    class BaseClass
    {
        private int x;
        protected int z;
        public BaseClass()
        {
            Console.WriteLine("base class 无参构造函数");
        }

        public BaseClass(int x)
        {
            this.x = x;
            Console.WriteLine("x赋值完成");
        }
    }
}
