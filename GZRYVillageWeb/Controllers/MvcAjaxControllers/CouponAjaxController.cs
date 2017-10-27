using Common.Filter.MvcAjax;
using Common.Result;
using DbOpertion.Cache;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GZRYVillageWeb.Controllers.MvcAjaxControllers
{
    /// <summary>
    /// 优惠卷Ajax控制器
    /// </summary>
    public class CouponAjaxController : Controller
    {
        /// <summary>
        /// 获得优惠卷列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Get_Coupon_List(DataTableRequest param)
        {
            var List_Coupon = Cache_Coupon.Instance.SelectByPage(param.SearchKey, param.OrderBy, param.Start, param.Length, param.OrderDir);
            var list_unknow = List_Coupon.Select(p => new{ p.CouponName,p.CouponId }).ToList();
            DataTableResponse<Coupon> Parameter_Tuser = new DataTableResponse<Coupon>();
            var All_Coupon_Count = Cache_Coupon.Instance.SelectAllCount();
            var Search_Coupon_Count = Cache_Coupon.Instance.SelectSearchCount(param.SearchKey);
            Parameter_Tuser.draw = param.Draw;
            Parameter_Tuser.recordsTotal = All_Coupon_Count;
            Parameter_Tuser.recordsFiltered = Search_Coupon_Count;
            Parameter_Tuser.data = List_Coupon;
            return Json(Parameter_Tuser.GetObject(), JsonRequestBehavior.AllowGet);
        }
    }
}