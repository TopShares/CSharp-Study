using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract.Abstract
{
    /// <summary>
    /// 接口不是类，里面可以包含属性、方法、事件   不能包含字段，委托，不能用访问修饰符
    /// 接口只能包含没有实现的方法
    /// 实现接口的话，必须实现全部方法
    /// 接口不能直接实例化，声明的对象只能使用接口里的方法，不能用子类新增的方法
    /// 接口可以实现多个
    /// can do
    /// </summary>
    public interface IExtend
    {
        //event Action DoNothingEvent;
        //int Id { get; set; }
        void Game();
        //List<>
    }

    public interface IPay
    {
        void Pay();
    }
}
