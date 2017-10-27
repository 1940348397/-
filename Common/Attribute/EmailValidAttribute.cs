using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Attribute
{
    /// <summary>
    /// 邮箱属性验证
    /// </summary>
    public class EmailValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            this.ErrorMessage = "邮箱验证失败";
            if (value == null)
            {
                return false;
            }
            else
            {
                string Email = @"^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$";
                Regex eReg = new Regex(Email);
                if (eReg.IsMatch(value.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
