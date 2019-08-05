using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.DesginPattern3
{
    /// <summary>
    /// 类之间的关系（3）：聚合关系（Aggregation) 是关联关系的一种特例。
    /// 
    /// 举例：汽车和发动机？轮胎？/  电脑和键盘？鼠标...
    /// 
    /// 1. 关系特点：也表示一个对象和另一个对象有关联。但是对象之间是整体与部分的关系！整体和部分可以分开！
    /// 
    /// 2. 典型应用：一个对象作为另一个类的《成员》。
    /// 
    /// 3. 组合形式：通过构造方法或者普通方法为成员赋值。对象是从外面创建的，然后传递进来。
    /// </summary>
    /// 整体
    public class Computer
    {
        private Keyboard keyboard;

        public Computer() { }
        public Computer(Keyboard keyboard)
        {
            this.keyboard = keyboard;
        }

        public void SetKeyboard(Keyboard keyboard)
        {
            this.keyboard = keyboard;
        }
    }
    /// <summary>
    /// 部分
    /// </summary>
    public class Keyboard
    {
        public void Click() { }
    }

    public class TestClass
    {
        private Computer myComputer = new Computer();
        private Computer yourComputer = new Computer(new Keyboard());

        public void Test()
        {
            myComputer.SetKeyboard(new Keyboard());
        }
    }
}
