using Common.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute.Constant
{
    public class DateTimeValidAttribute : ValidationAttribute
    {
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowEmpty { get; set; }
        public override bool IsValid(object value)
        {
            if (AllowEmpty == true)
            {
                return true;
            }
            if (value == null)
            {
                return false;
            }
            else
            {
                DateTime date = (DateTime)value;
                if (date.IsNullOrEmpty())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
