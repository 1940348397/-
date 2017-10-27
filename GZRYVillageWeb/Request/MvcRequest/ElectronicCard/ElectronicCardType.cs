using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.MvcRequest.ElectronicCard
{
    /// <summary>
    /// 电子储值卡Id请求
    /// </summary>
    public class ElectronicCardType
    {
        /// <summary>
        /// 电子储值卡类型Id
        /// </summary>
        public int ElectronicTypeId { get; set; }
        /// <summary>
        /// 卡片ID
        /// </summary>
       public int ElectronicId { get; set; }
    }
}