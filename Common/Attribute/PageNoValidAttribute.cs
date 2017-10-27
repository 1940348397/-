using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute
{
    /// <summary>
    /// 分页页码验证
    /// </summary>
    public class PageNoValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            this.ErrorMessage = "页码请填写";
            if (value != null)
            {
                int num;
                if (int.TryParse(value.ToString(), out num))
                {
                    if (num >= 1)
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
            else
            {
                return false;
            }
        }
    }
}
