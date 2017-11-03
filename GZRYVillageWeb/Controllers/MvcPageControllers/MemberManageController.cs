using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.LambdaOpertion;
using Common;
using System.IO;
using System.Data;
using DbOpertion.Cache;
using Common.Result;
using GZRYVillageWeb.Request.MvcRequest.MemberCard;
using Common.Mvc.Filter;

namespace GZRYVillageWeb.Controllers.MvcPageControllers
{
    
    public class MemberManageController : Controller
    {
        // GET: MemberManage
        /// <summary>
        /// 会员卡管理主页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 卡片所对应的优惠券页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult Coupon(MemberShipCardIdRequest request)
        {
            ViewBag.MemberShipTypeId = request.MemberShipTypeId;
            return View();
        }
        
        /// <summary>
        /// 类型对应的会员卡页面
        /// </summary>
        /// <returns></returns>
        [UserLogin]
        public ActionResult MemberView(MemberShipCardIdRequest request)
        {
            ViewBag.MemberShipTypeId = request.MemberShipTypeId;
            return View();
        }
        /// <summary>
        /// 上传卡片图案
        /// </summary>
        /// <param name="upImg"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase upImg)
        {
            string fileName = System.IO.Path.GetFileName(upImg.FileName);
            string filePhysicalPath = Server.MapPath("~/upload/" + fileName);
            string pic = "", error = "";
            try
            {
                upImg.SaveAs(filePhysicalPath);
                pic = "/upload/" + fileName;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                pic = pic,
                error = error
            });
        }
    }
}