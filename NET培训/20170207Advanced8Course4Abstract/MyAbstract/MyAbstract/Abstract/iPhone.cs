using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract.Abstract
{
    /// <summary>
    /// 手机
    /// </summary>
    public class iPhone : BasePhone, IExtend, IPay
    {
        /// <summary>
        /// 品牌
        /// </summary>
        /// <returns></returns>
        public override string Brand()
        {
            return "iPhone";
        }

        /// <summary>
        /// 系统
        /// </summary>
        /// <returns></returns>
        public override string System()
        {
            return "IOS";
        }

        /// <summary>
        /// 打电话
        /// </summary>
        public override void Call()
        {
            Console.WriteLine("User{0} {1} {2} Call", this.GetType().Name, this.Brand(), this.System());
        }

        /// <summary>
        /// 拍照
        /// </summary>
        public override void Photo()
        {
            Console.WriteLine("User{0} {1} {2} Call", this.GetType().Name, this.Brand(), this.System());
        }


        public override void Do<T>()
        {

        }

        public void Game()
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }
    }
}
