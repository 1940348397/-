using Common.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Attribute
{
    public class SearchValidAttribute : ValidationAttribute
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
            if (Regex.Replace(value.ToString(), @"\p{Cs}", "").IsNullOrEmpty())
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
