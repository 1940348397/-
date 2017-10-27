using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Attribute.Constant
{
    public class limitStringAttribute : ValidationAttribute
    {
        /// <summary>
        /// 限制字符串以|相隔
        /// </summary>
        public string Limit { get; set; }
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowEmpty { get; set; }
        public override bool IsValid(object value)
        {
            
            if (Limit == null)
            {
                return true;
            }
            else if (AllowEmpty == true)
            {
                return true;
            }
            if (value == null)
            {
                return false;
            }
            else
            {
                var ArrayLimit = Limit.Split('|');
                foreach (var item in ArrayLimit)
                {
                    if (item.ToLower() == value.ToString().ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
