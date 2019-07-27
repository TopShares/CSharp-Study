using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern2
{
    //原型模式：用原型实例指定创建对象的类型，并通过拷贝这些原型创建新的对象
    //简单理解：原型模式就是从一个对象创建再创建另一个“可定制化的”对象。但是这个对象创建过程，我们可以被封装（细节不需要表露）

    /// <summary>
    /// 原型类
    /// </summary>
    abstract class Prototype
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }

        public abstract Prototype Clone();//提供一个抽象的Clone()方法。
    }

    class PrototypeImpl : Prototype
    {
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();//创建当前对象的浅副本

            //也就是创建了一个新对象，然后将当前对象的非静态字段复制到该新对象里。
            //如果字段是值类型，则这个字段被完整复制。如果字段是引用类型，则复制引用的地址。
        }
    }
}
