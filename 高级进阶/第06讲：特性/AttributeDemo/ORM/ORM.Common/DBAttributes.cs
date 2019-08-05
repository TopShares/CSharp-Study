﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Common
{
    /// <summary>
    /// 表示主键属性
    /// </summary>
    public class PrimaryKeyAttribute : Attribute
    {
        public bool IsPKey { get; } = true;

        //public bool IsPKey { get; set; }//如果这样的话，调用的时候写法为： [PrimaryKey(IsPKey = true)]
    }
    /// <summary> 
    /// 作用：说明列是否为自动增长列 
    /// </summary> 
    public class IdentityAttribute : Attribute
    {
        public bool IsIdentity { get; } = true;
    }
    /// <summary>
    /// 非表的字段（自定义扩展属性）
    /// </summary>
    public class NonTableAttribute : Attribute
    {
        public bool IsNonFiled { get; } = true;
    }
}
