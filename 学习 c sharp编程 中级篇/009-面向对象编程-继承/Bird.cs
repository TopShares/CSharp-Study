using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_面向对象编程_继承 {
     abstract class Bird//一个抽象类 就是一个不完整的模板
    {
        private float speed;

        public void Eat()
        {
            
        }

        public abstract void Fly();
    }
}
