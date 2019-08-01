using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            _Remark = remark;
        }

        private string _Remark;

        public string Remark
        {
            get
            {
                return _Remark;
            }
        }
    }


    public static class RemarkExtend
    {
        public static string GetRemark(this Enum eValue)
        {
            Type type = eValue.GetType();
            FieldInfo field = type.GetField(eValue.ToString());
            RemarkAttribute remarkAttribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute));
            return remarkAttribute.Remark;
        }
    }
}
