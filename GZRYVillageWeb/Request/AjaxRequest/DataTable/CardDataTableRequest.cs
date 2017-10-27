using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.AjaxRequest.DataTable
{
    /// <summary>
    /// 使用cardId的DataTable
    /// </summary>
    public class CardDataTableRequest: DataTableRequest
    {
        /// <summary>
        /// 卡号ID
        /// </summary>
        public int MemberShipTypeId { get; set; }
    }
}