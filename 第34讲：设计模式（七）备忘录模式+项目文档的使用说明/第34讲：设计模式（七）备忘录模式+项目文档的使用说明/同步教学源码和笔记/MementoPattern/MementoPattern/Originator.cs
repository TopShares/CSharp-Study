using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    /// <summary>
    /// 需要保存的状态参数...可以设置多个
    /// </summary>
    public class Originator
    {
        //需要保存的数据参数，可以是N个...
        public string StateParam1 { get; set; }
        public string StateParam2 { get; set; }
        public string StateParam3 { get; set; }

        public string StateParam4 { get; set; }

        //。。。


        /// <summary>
        /// 创建备忘录：当我们需要保存对象的相关数据时，随时以备忘录对象的形式体现
        /// </summary>
        /// <returns></returns>
        public Memento CreateMemento()
        {
            return new Memento
            {
                StateParam1 = this.StateParam1,//将当前对象部分数据状态，保存到备忘录
                StateParam2 = this.StateParam2,
                StateParam3 = this.StateParam3
            };
        }

        /// <summary>
        /// 恢复备忘录：将Memento导入，并恢复相关数据
        /// </summary>
        /// <param name="memento"></param>
        public void RecoveryMemento(Memento memento)
        {
            this.StateParam1 = memento.StateParam1;//将备忘录状态重新赋值给对象
            this.StateParam2 = memento.StateParam2;
            this.StateParam3 = memento.StateParam3;
        }

        /// <summary>
        /// 读取当前对象的部分状态数据(以下纯属练习使用)
        /// </summary>
        /// <returns></returns>
        public string GetStateParams()
        {
            return $"{this.StateParam1}-{this.StateParam2}-{this.StateParam3}";
        }


    }
}
