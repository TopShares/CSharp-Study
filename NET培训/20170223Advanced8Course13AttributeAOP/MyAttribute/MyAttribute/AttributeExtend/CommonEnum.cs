using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    public enum UserState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Delete = 2
    }

    //public enum UserState1
    //{
    //    /// <summary>
    //    /// 正常
    //    /// </summary>
    //    [Remark("正常")]
    //    正常 = 0,
    //    /// <summary>
    //    /// 冻结
    //    /// </summary>
    //    [Remark("冻结")]
    //    冻结 = 1,
    //    /// <summary>
    //    /// 删除
    //    /// </summary>
    //    [Remark("删除")]
    //    删除 = 2
    //}
}
