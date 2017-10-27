using Common.Mvc.Filter;
using DbOpertion.Cache;
using GZRYVillageWeb.Request.MvcRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GZRYVillageWeb.Controllers.MvcPageControllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// 会员管理页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 优惠卷页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Coupon(UserIdRequest request)
        {
            ViewBag.UserId = request.UserId;
            return View();
        }


        /// <summary>
        /// 优惠卷页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Consumption(UserIdRequest request)
        {
            ViewBag.UserId = request.UserId;
            return View();
        }

        
    }
}