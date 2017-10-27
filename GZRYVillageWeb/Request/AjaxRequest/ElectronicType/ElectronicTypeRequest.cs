using Common.Attribute.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GZRYVillageWeb.Request.AjaxRequest.ElectronicType
{
    /// <summary>
    /// 电子储值卡
    /// </summary>
    public class ElectronicTypeRequest
    {

        /// <summary>
        /// 卡片名称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "卡片名称不能为空")]
        public string CardName { get; set; }

        /// <summary>
        /// 卡片图案
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "卡片图案不能为空")]
        public string CardImage { get; set; }

        /// <summary>
        /// 储值金额
        /// </summary>
        [DecimalValid(AllowZero = true, ErrorMessage = "储值金额请输入数字")]
        public decimal CardMoney { get; set; }
    }
}