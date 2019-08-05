using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ORM.Common
{
    /// <summary>
    /// 基于特性验证的父类（参考了MVC中的验证类）
    /// </summary>
    public abstract class ValidateAtrribute : Attribute
    {
        /// <summary>
        /// 给用户显示的实体属性名
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// 是否验证通过
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 验证返回的信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 抽象的验证方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool Validate(object value);
    }

    /// <summary>
    /// 非空验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : ValidateAtrribute
    {
        /// <summary>
        /// 构造方法：给用户要显示的实体属性名
        /// </summary>
        /// <param name="displayName"></param>
        public RequiredAttribute(string displayName)
        {
            base.DisplayName = displayName;
        }
        public override bool Validate(object value)
        {
            if (value == null || value.ToString().Trim().Length == 0)
            {
                base.IsValid = false;
                base.ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                base.IsValid = true;
            }
            return IsValid;
        }
    }
    /// <summary>
    /// 整数范围验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : ValidateAtrribute
    {
        private int min = 0;
        private int max = 0;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="displayName">给用户要显示的实体属性名</param>
        /// <param name="minValue">范围中的最整数值</param>
        /// <param name="maxValue">范围中的最大整数值</param>
        public RangeAttribute(string displayName, int minValue, int maxValue)
        {
            base.DisplayName = displayName;
            this.min = minValue;
            this.max = maxValue;
        }
        public override bool Validate(object value)
        {
            //先非空验证
            if (value == null || value.ToString().Trim().Length == 0)
            {
                IsValid = false;
                ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                //格式验证
                int num = int.Parse(value.ToString());
                if (num < min || num > max)
                {
                    IsValid = false;
                    ErrorMessage = $"{DisplayName}的值必须在{min}和{max}之间！";
                }
                else
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
    /// <summary>
    /// 字符串固定长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FixedLengthAttribute : ValidateAtrribute
    {
        private int fixedLength = 0;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="displayName">给用户要显示的实体属性名</param> 
        /// <param name="fixedLength">指定的字符串长度</param> 
        public FixedLengthAttribute(string displayName, int fixedLength)
        {
            base.DisplayName = displayName;
            this.fixedLength = fixedLength;
        }
        public override bool Validate(object value)
        {
            //先非空验证
            if (value == null || value.ToString().Trim().Length == 0)
            {
                IsValid = false;
                ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                //判断是不是固定长度
                if (fixedLength > 0 && (value.ToString().Length != this.fixedLength))
                {
                    IsValid = false;
                    ErrorMessage = $"{DisplayName}的长度必须是{fixedLength}位！";
                }
                else
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
    /// <summary>
    /// 字符串长度范围验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : ValidateAtrribute
    {
        private int minLength = 0;
        private int maxLength = 0;
        public StringLengthAttribute(string displayName, int minLength, int maxLength)
        {
            base.DisplayName = displayName;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }
        public override bool Validate(object value)
        {
            //先非空验证
            if (value == null || value.ToString().Trim().Length == 0)
            {
                IsValid = false;
                ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                if (value.ToString().Length < minLength || value.ToString().Length > maxLength)
                {
                    IsValid = false;
                    ErrorMessage = $"{DisplayName}的长度必须在{minLength}和{maxLength}之间！";
                }
                else IsValid = true;
            }
            return IsValid;
        }
    }
    /// <summary>
    /// 电子邮件验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidateAtrribute
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="displayName">给用户要显示的实体属性名</param> 
        public EmailAttribute(string displayName)
        {
            base.DisplayName = displayName;
        }
        public override bool Validate(object value)
        {
            //先非空验证
            if (value == null || value.ToString().Trim().Length == 0)
            {
                IsValid = false;
                ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                if (!CommonRegexValidate.IsEmail(value.ToString()))
                {
                    IsValid = false;
                    ErrorMessage = $"{DisplayName}的格式不正确！";
                }
                else
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
    //其他验证请自己写...

    /// <summary>
    /// 通用正则表达式验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RegularExpressionAttribute : ValidateAtrribute
    {
        private string regExp = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="displayName">给用户要显示的实体属性名</param>
        /// <param name="regularExpression">正则表达式规则</param>
        public RegularExpressionAttribute(string displayName, string regularExpression)
        {
            base.DisplayName = displayName;
            this.regExp = regularExpression;
        }
        public override bool Validate(object value)
        {
            //先非空验证
            if (value == null || value.ToString().Trim().Length == 0)
            {
                IsValid = false;
                ErrorMessage = $"{base.DisplayName}不能为空！";
            }
            else
            {
                Regex regex = new Regex(regExp);
                if (!regex.IsMatch(value.ToString()))
                {
                    IsValid = false;
                    ErrorMessage = $"请输入格式正确的{DisplayName}！";
                }
                else
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }

}
