using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Attribute.Constant;
using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace GZRYVillageWeb.Request.AjaxRequest.Login
{
    public class LoginInRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请填写用户名", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请填写密码", AllowEmptyStrings = false)]
        public string PassWord { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        //[Required(ErrorMessage = "请填写验证码", AllowEmptyStrings = false)]
        [limitStringAttribute(ErrorMessage = "请填写验证码")]
        public string Verification { get; set; }
    }
}