using Common.Attribute.Constant;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.AjaxRequest
{
    /// <summary>
    /// 使用UserId的DataTable
    /// </summary>
    public class UserDataTableRequest: DataTableRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [IntValid]
        public int UserId { get; set; }
    }
}