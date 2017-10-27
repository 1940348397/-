using System.Web.Mvc;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Mvc.Filter
{
    /// <summary>
    /// 用户登入验证
    /// </summary>
    public class UserLoginAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 用户登入验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var user = (AUser)actionContext.HttpContext.Session["user"];
            if (user == null)
            {
                actionContext.Result = new RedirectResult("/Login/Index");
            }
            else
            {
                actionContext.Controller.ViewBag.User = user;
            }
        }
    }
}