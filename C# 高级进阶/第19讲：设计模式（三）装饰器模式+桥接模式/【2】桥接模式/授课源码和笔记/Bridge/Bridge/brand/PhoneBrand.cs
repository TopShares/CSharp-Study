using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// 手机品牌
    /// </summary>
    abstract class PhoneBrand
    {
        protected PhoneSoftware software = null;

        /// <summary>
        /// 安装手机软件--体现是聚合关系
        /// </summary>
        /// <param name="software">软件的父类类型，将来会传递子类对象</param>
        public void InstallSoftware(PhoneSoftware software)
        {
            this.software = software;
        }

        //手机运行
        public abstract void Run();
    }
}
