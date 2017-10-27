using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum_My
{
    /// <summary>
    /// 路径枚举
    /// </summary>
    public enum Enum_URL
    {
        /// <summary>
        /// 用户图片路径
        /// </summary>
        UserImage = 0,
    }

    public static partial class GetString
    {
        public static string Enum_GetString(this Enum_URL Enum_Model)
        {
            string result = string.Empty;
            switch (Enum_Model)
            {
                case Enum_URL.UserImage:
                    result = "~/Content/UserImage";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}
