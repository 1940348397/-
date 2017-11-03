using Common.Attribute.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.ApiRequest
{
    /// <summary>
    /// 用户登入请求
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 登录模式(PassWord,WeChat,Token)
        /// </summary>
        [limitString(Limit = "PassWord|WeChat|Token",ErrorMessage ="登入模式选择错误")]
        public string TransMode { get; set; }
        /// <summary>
        /// 用户图片
        /// </summary>
        public string UserImage { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }
    }
}