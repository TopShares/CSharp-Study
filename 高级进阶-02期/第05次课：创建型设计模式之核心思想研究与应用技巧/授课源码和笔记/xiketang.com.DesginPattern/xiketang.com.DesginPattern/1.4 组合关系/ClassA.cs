using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.DesginPattern4
{
    /// <summary>
    /// 类之间的关系（4）：组合关系（Compostion) 
    /// 
    /// 举例：人和手、脚
    /// 
    /// 1. 关系特点：也表示一个对象和另一个对象有关联。但是对象之间是整体与部分的关系！“只不过” 整体和部分“不”可以分开！并且整体和部分共生死！
    /// 
    /// 2. 典型应用：一个对象作为另一个类的《成员》。
    /// 
    /// 3. 组合形式：通过构造方法“内”或者普通方法“内”直接创建。对象是从内部创建的，不用传递。这点是区别与聚合。
    /// </summary>
    public class Person
    {
        private Hand hand;

        public Person()
        {
            this.hand = new Hand(); //代表，人出生就有手
        }      
      
    }
    /// <summary>
    /// 部分
    /// </summary>
    public class Hand 
    {
        public void Coding() { } 
    }  
}
