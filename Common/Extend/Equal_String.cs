using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend
{
    public static class Equal_String
    {
        /// <summary>
        /// 2个字符串是否相等
        /// </summary>
        public static bool EqualString(this string str1, string str2)
        {
            if (str1 == null && str2 == null)
            {
                return true;
            }
            else if (str1 != null && str2 == null)
            {
                return false;
            }
            else if (str1 == null && str2 != null)
            {
                return false;
            }
            else
            {
                if (str1.ToLower() == str2.ToLower())
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
