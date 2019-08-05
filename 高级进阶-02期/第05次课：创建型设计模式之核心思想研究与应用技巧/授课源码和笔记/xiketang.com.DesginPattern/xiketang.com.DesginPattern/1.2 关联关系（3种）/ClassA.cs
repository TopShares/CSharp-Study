using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.DesginPattern2
{
    /// <summary>
    /// 类之间的关系（2）：关联关系（Association)
    /// 举例：比如客户和订单之间就是一种关联关系。一个对象和另一个对象是有关联的。但是这种关系是客观的关系，而非组成关系。
    /// 
    /// 1. 关系特点：一个类A中，“使用” 到了另一个类B。这种 “使用” 是长期的、较强的关系。
    /// 2. 典型应用：一个类作为另一个类中“成员”。可以是一对一，一对多，（集合对象）
    /// 3. 组合形式：单向，双向，自关联
    /// </summary>
    public class ClassA
    {
        private ClassB classB;


    }

    public class ClassB
    {
        private List<ClassA> caList;

        public void Test() { }
    }

    /// <summary>
    /// 自关联
    /// </summary>
    public class ClassC
    {
        private ClassC classc;
    }
}
