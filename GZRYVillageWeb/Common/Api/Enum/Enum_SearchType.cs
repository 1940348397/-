using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Common.Api.Enum
{
    /// <summary>
    /// 返回信息
    /// </summary>
    public enum Enum_SearchType
    {
        /// <summary>
        /// 适合自己
        /// </summary>
        SuitMe = 0,
        /// <summary>
        /// 距离
        /// </summary>
        Distance = 1,
        /// <summary>
        /// 按销量
        /// </summary>
        SalesVolume = 2,
        /// <summary>
        /// 类型
        /// </summary>
        Type = 3,
        /// <summary>
        /// 餐厅
        /// </summary>
        Restaurant = 4,
        /// <summary>
        /// 菜谱
        /// </summary>
        Recipe = 5,
        /// <summary>
        /// 全部
        /// </summary>
        All = 6,
        /// <summary>
        /// 年
        /// </summary>
        Year = 7,
        /// <summary>
        /// 月
        /// </summary>
        Month = 8,
        /// <summary>
        /// 日
        /// </summary>
        Day = 9,
        /// <summary>
        /// 注册
        /// </summary>
        Registration = 10,
        /// <summary>
        /// 重置密码
        /// </summary>
        ResetPassword = 11,
        /// <summary>
        /// 更换手机
        /// </summary>
        ChangePhone = 12,
        /// <summary>
        /// 更换手机
        /// </summary>
        Article = 13
    }

    public static partial class GetString
    {
        /// <summary>
        /// 根据模型获取对应信息
        /// </summary>
        /// <param name="Enum_Model">当前枚举</param>
        /// <returns></returns>
        public static string Enum_GetString(this Enum_SearchType Enum_Model)
        {
            string result = string.Empty;
            switch (Enum_Model)
            {
                case Enum_SearchType.SuitMe:
                    result = "suitme".ToLower();
                    break;
                case Enum_SearchType.Distance:
                    result = "distance".ToLower();
                    break;
                case Enum_SearchType.SalesVolume:
                    result = "salesvolume".ToLower();
                    break;
                case Enum_SearchType.Type:
                    result = "type".ToLower();
                    break;
                case Enum_SearchType.Restaurant:
                    result = "restaurant".ToLower();
                    break;
                case Enum_SearchType.Recipe:
                    result = "recipe".ToLower();
                    break;
                case Enum_SearchType.All:
                    result = "all".ToLower();
                    break;
                case Enum_SearchType.Year:
                    result = "year".ToLower();
                    break;
                case Enum_SearchType.Month:
                    result = "month".ToLower();
                    break;
                case Enum_SearchType.Day:
                    result = "day".ToLower();
                    break;
                case Enum_SearchType.Registration:
                    result = "registration".ToLower();
                    break;
                case Enum_SearchType.ResetPassword:
                    result = "resetpassword".ToLower();
                    break;
                case Enum_SearchType.ChangePhone:
                    result = "changephone".ToLower();
                    break;
                case Enum_SearchType.Article:
                    result = "Article".ToLower();
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}