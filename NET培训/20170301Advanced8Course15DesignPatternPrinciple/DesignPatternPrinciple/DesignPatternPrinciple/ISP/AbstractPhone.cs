using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
    public abstract class AbstractPhone
    {
        public abstract void Call();
        public abstract void Text();
    }

    /// <summary>
    /// 不要定义一个大而全的接口
    /// </summary>
    public interface IExtend //: IExtendAdvanced
    {
        void Photo();
        void Online();
        void Game();
        void Record();
        void Movie();
    }

    //一个方法一个接口

    public interface IExtendAdvanced
    {
        void Map();
        void Pay();
    }

}
