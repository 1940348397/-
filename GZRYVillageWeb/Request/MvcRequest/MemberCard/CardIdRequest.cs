using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.MvcRequest.MemberCard
{
    /// <summary>
    /// 卡片ID
    /// </summary>
    public class CardIdRequest : DataTableRequest
    {
        /// <summary>
        /// 卡片ID
        /// </summary>
        public int MemberShipCardId { get; set; }
    }
}