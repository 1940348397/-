using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Enum_My;

namespace Common.Attribute
{
    public class PassWordValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            this.ErrorMessage = Enum_Message.PasswordInvalidMessage.Enum_GetString();
            if (value != null)
            {
                var RegexStr = "(?!^\\d+$)(?!^[a-zA-Z]+$)(?!^[_#@]+$).{6,}";
                if (Regex.IsMatch(value.ToString(), RegexStr))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
