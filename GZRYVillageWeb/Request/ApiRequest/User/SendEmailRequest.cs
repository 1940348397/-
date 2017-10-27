using Common.Attribute;
using Common.Attribute.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.ApiRequest
{
    /// <summary>
    /// 发送邮件请求
    /// </summary>
    public class SendEmailRequest
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        [PhoneValid]
        public string Phone { get; set; }

        /// <summary>
        /// 邮件类型(Registration|ResetPassword|ChangePhone)
        /// </summary>
        [limitString(ErrorMessage = "邮件类型未填写或填写错误", Limit = "Registration|ResetPassword|ChangePhone", AllowEmpty = true)]
        public string SendEmailType { get; set; }
    }
}