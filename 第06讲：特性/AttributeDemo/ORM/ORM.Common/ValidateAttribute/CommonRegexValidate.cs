﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace ORM.Common
{
    /// <summary>
    /// 通用验证类
    /// </summary>
    public class CommonRegexValidate
    {
        /// <summary>
        /// 验证正整数
        /// </summary>     
        public static bool IsInteger(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证是否是Email
        /// </summary>     
        public static bool IsEmail(string txt)
        {
            Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证身份证
        /// </summary>     
        public static bool IsIdentityCard(string txt)
        {
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return objReg.IsMatch(txt);
        }
        //...其他正则表达式的验证，请学员自己根据所给正则表达式自己添加相应的方法



    }
}
