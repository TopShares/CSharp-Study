﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NhibernateShow.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类中的字段要设置为virtual
    /// </summary>
    public class Company : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual int? LastModifierId { get; set; }
        public virtual Nullable<DateTime> LastModifyTime { get; set; }
    }
}
