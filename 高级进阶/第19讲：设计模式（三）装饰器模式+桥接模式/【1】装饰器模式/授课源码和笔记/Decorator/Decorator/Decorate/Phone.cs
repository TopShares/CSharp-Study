using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// 手机抽象类：表示要集中完成的一个任务，这个任务可能会有多个环节，也就是过程不稳定
    /// </summary>
    public abstract class Phone
    {
        //我们在这里编写手机最核心的功能....


        //如果我们考虑到还要做一些额外的，但是不确定的任务...
        public abstract void Show();//这个地方其实是一个任务的集中点

        //比如做上位机开发的学员，我们要完成一个任务，比如统计3个检测点的数据，后面可能会增加其他的...
        //

    }
}
