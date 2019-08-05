using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.DesginPattern1 
{
    /// <summary>
    /// 类之间的关系（1）：依赖关系（Dependence)
    /// 1. 关系特点：一个类中，“使用” 到了另一个类。这种 “使用” 是临时的、较弱的关系。
    /// 2. 典型应用：一个类作为另一个类中方法的参数，或者这个方法的局部变量。
    /// </summary>
    public class ClassA
    {
        public void Method1(ClassB cb)
        {
            cb.Test();
        }
        public void Method2()
        {
            ClassB cb = new ClassB();
            cb.Test();
        }
    }

    public class ClassB
    {
        public void Test() { }
    }
}
