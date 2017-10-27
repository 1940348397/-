using Common.Extend;
using DbOpertion.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Common.Api.Filter
{
    /// <summary>
    /// 用户Id验证
    /// </summary>
    public class UserIdValidAttribute : ValidationAttribute
    {
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowEmpty { get; set; }

        /// <summary>
        /// 用户Id验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            this.ErrorMessage = "该用户Id为空或用户不存在";
            if (value != null)
            {
                var id = value.ToString().ParseInt();
                if (id != null && id != 0)
                {
                    if (Cache_TUser.Instance.MemberGetUserInfo(id.Value) != null)
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