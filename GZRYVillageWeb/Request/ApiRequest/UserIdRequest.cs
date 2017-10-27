using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.ApiRequest
{
    /// <summary>
    /// 用户Id请求
    /// </summary>
    public class UserIdRequest : UserTokenRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }
}