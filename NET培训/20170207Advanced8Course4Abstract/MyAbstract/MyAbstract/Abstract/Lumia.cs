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
    public class Lumia : BasePhone,IExtend
    {
        /// <summary>
        /// 品牌
        /// </summary>
        /// <returns></returns>
        public override string Brand()
        {
            return "Nokia";
        }

        /// <summary>
        /// 系统
        /// </summary>
        /// <returns></returns>
        public override string System()
        {
            return "Winphone";
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

        public void Metro()
        {
            Console.WriteLine("This is Metro");
        }
        public override void Do<T>()
        {

        }

        public void Game()
        {
            throw new NotImplementedException();
        }
    }
}
