using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IntValidateAttribute : Attribute
    {

        private int _Min = 0;
        private int _Max = 0;

        public IntValidateAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }

        public bool Validate(int num)
        {
            return num > this._Min && num < this._Max;
        }


    }
}
