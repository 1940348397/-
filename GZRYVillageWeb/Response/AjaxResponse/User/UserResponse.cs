using Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Response.AjaxResponse
{
    /// <summary>
    /// 用户应答
    /// </summary>
    public class UserResponse
    {
       
        /// <summary>
        /// 用户名称
        /// </summary>
        [UserNameValid(ErrorMessage = "用户名称不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户昵称不能为空")]
        public string UserNickName { get; set; }

        /// <summary>
        /// 用户手机号码
        /// </summary>
        [PhoneValid]
        public string UserPhone { get; set; }
    }
}