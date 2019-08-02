using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_密封类和密封方法 {
    class DerivedClass:BaseCLass {//sealed密封类无法被继承
        public sealed override void Move()//我们可以把重写的方法声明为密封方法，表示该方法不能 被重写 
        {
            base.Move();
        }
    }
}
