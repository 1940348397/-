using System.Web.Mvc;
using GZRYVillageWeb.Request.AjaxRequest.Login;
using DbOpertion.Cache;
using Common.Result;
using DbOpertion.Models;
using Common.Helper.JsonHelper;
using System;
using System.Linq;
using Common.Filter.MvcAjax;

namespace GZRYVillageWeb.Controllers.MvcAjaxControllers
{
    /// <summary>
    /// 登入Ajax控制器
    /// </summary>
    public class LoginAjaxController : Controller
    {
        /// <summary>
        /// 登入请求
        /// </summary>
        /// <param name="request">登入信息</param>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult LoginIn(LoginInRequest request)
        {
            var User = Cache_AUser.Instance.AdminUserLogin(request.UserName, request.PassWord);
            ResultJsonModel<AUser> result = new ResultJsonModel<AUser>();
            if (User == null)
            {
                result.HttpCode = 300;
                result.Message = "用户登入失败";
            }
            else
            {
                Session.Timeout = 1440;
                Session.Add("user", User);
                result.HttpCode = 200;
                result.Message = "用户登入成功";
                result.Model1 = User;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }

}