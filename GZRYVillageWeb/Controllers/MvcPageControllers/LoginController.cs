using Common.LambdaOpertion;
using Common.Mvc.Filter;
using DbOpertion.Cache;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GZRYVillageWeb.Controllers.MvcPageControllers
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginController : Controller
    {
        // GET: Login
        /// <summary>
        /// 用户登入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登入之后页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Login()
        {
            return View();
        }
    }
}