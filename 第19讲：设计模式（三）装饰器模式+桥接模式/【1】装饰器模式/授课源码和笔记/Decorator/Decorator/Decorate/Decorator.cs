using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// 装饰器类：继承了抽象的Phone类，主要是想给Phone扩展功能，但是对于Phone来讲，
    /// 并不知道Decorator的存在
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone = null;//要装饰的对象（要扩展功能的对象）

        /// <summary>
        /// 开始装饰
        /// </summary>
        /// <param name="phone">要装饰的对象，也就是给谁装饰（给谁增加功能）</param>
        public void SetDecorate(Phone phone)
        {
            this.phone = phone;//其实传递过来的是具体的子类
        }

        /// <summary>
        /// 重写方法：
        /// </summary>
        public override void Show()
        {
            if (this.phone != null)
                this.phone.Show();
        }
    }
}
