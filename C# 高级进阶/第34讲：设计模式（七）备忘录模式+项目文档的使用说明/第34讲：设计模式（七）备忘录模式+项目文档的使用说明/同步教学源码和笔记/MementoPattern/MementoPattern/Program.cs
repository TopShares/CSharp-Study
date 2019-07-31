using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建发起人（有需要保存的数据）
            Originator originator = new Originator
            {
                StateParam1="23V",
                StateParam2="10A",
                StateParam3="equipment1"
            };
            Console.WriteLine("初始化的状态："+originator.GetStateParams());

            //创建管理者（获取特定时刻的状态参数，进行备份）类似，我有一样东西，希望别人替我保管
            Caretaker caretaker = new Caretaker
            {
                Memento = originator.CreateMemento() //通过发起者对象直接获取备忘录对象
            };

            //程序运行过程中修改某些参数
            originator.StateParam1 = "45V";
            originator.StateParam2 = "12V";
            originator.StateParam3 = "equipment1";
            Console.WriteLine("运行中的状态："+originator.GetStateParams());
            //在这里继续编写其他逻辑...

            //恢复一个状态（从管理者手中得到备份，并导入）也就是从别人手里拿到以前保管的东西
            originator.RecoveryMemento(caretaker.Memento);
            Console.WriteLine("修复后的状态："+originator.GetStateParams());

            Console.Read();
        }
    }
}
