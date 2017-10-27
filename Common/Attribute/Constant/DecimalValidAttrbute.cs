﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute.Constant
{
    public class DecimalValidAttribute : ValidationAttribute
    {
        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowEmpty { get; set; }

        /// <summary>
        /// 是否允许为0
        /// </summary>
        public bool AllowZero { get; set; }
        public override bool IsValid(object value)
        {
            if (AllowEmpty == true)
            {
                return true;
            }
            if (AllowZero && value.ToString() == "0")
            {
                return true;
            }
            if (value == null || value.ToString() == "0")
            {
                return false;
            }
            else
            {
                decimal result;
                if (!decimal.TryParse(value.ToString(), out result))
                {
                    return false;
                }
                if (result < 0)
                {
                    return false;
                }
                if (MaxLength == null && MinLength == null)
                {
                    return true;
                }
                else if (MaxLength == null && MinLength != null)
                {
                    if (value.ToString().Length >= MinLength)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (MaxLength != null && MinLength == null)
                {
                    if (value.ToString().Length <= MaxLength)
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
                    if (value.ToString().Length <= MaxLength && value.ToString().Length >= MinLength)
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
}
