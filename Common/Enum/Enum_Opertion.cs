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
    public enum Enum_Opertion
    {
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 0,
        /// <summary>
        /// 插入
        /// </summary>
        Insert = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Update = 2,
        /// <summary>
        /// 查询
        /// </summary>
        Where = 3,
        /// <summary>
        /// 设置
        /// </summary>
        Set = 4
    }

    public static partial class GetString
    {
        public static string Enum_GetString(this Enum_Opertion Enum_Model)
        {
            string result = string.Empty;
            switch (Enum_Model)
            {
                case Enum_Opertion.Delete:
                    result = "delete";
                    break;
                case Enum_Opertion.Insert:
                    result = "insert";
                    break;
                case Enum_Opertion.Update:
                    result = "update";
                    break;
                case Enum_Opertion.Where:
                    result = "Where";
                    break;
                case Enum_Opertion.Set:
                    result = "Set";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}
