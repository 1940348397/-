﻿using Common.Filter.MvcAjax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOpertion.Cache;
using Common.Helper.JsonHelper;
using DbOpertion.Models;
using Common.Result;
using Common.Enum_My;
using System.Diagnostics;
using GZRYVillageWeb.Request.AjaxRequest;

namespace GZRYVillageWeb.Controllers.MvcAjaxControllers
{
    /// <summary>
    /// 用户异步控制器
    /// </summary>
    public class UserAjaxController : Controller
    {
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Get_User_List(DataTableRequest param)
        {
            var List_user = Cache_TUser.Instance.SelectMemberUser(param.SearchKey, param.OrderBy, param.Start, param.Length, param.OrderDir);
            DataTableResponse<TUser> Parameter_Tuser = new DataTableResponse<TUser>();
            var All_User_Count = Cache_TUser.Instance.SelectMemberUserCount(null,param.OrderBy, param.OrderDir);
            var Search_User_Count = Cache_TUser.Instance.SelectMemberUserCount(param.SearchKey, param.OrderBy, param.OrderDir);
            Parameter_Tuser.draw = param.Draw;
            Parameter_Tuser.recordsTotal = All_User_Count;
            Parameter_Tuser.recordsFiltered = Search_User_Count;
            Parameter_Tuser.data = List_user;
            return Json(Parameter_Tuser.GetObject(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得用户信息根据ID
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Get_User_ById(UserIdRequest request)
        {
            var user = Cache_TUser.Instance.MemberGetUserInfo(request.UserId);
            ResultJsonModel<TUser> result = new ResultJsonModel<TUser>();
            if (user == null)
            {
                result.HttpCode = 300;
                result.Message = Enum_Message.NoMoreDataMessage.Enum_GetString();
            }
            else
            {
                result.HttpCode = 200;
                result.Message = Enum_Message.SuccessMessage.Enum_GetString();
                result.Model1 = user;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得购物记录列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Get_Consumption_List(UserDataTableRequest param)
        {
            var Consuption_List = Cache_Consumption.Instance.Consuption_List(param.UserId, param.SearchKey, param.OrderBy, param.Start, param.Length, param.OrderDir);
            DataTableResponse<Consumption> Parameter_Consumption = new DataTableResponse<Consumption>();
            var All_Consuption_Count = Cache_Consumption.Instance.SelectConsuptionCount(param.UserId,null, param.OrderBy, param.OrderDir);
            var Search_Consuption_Count = Cache_Consumption.Instance.SelectConsuptionCount(param.UserId, param.SearchKey, param.OrderBy, param.OrderDir);
            Parameter_Consumption.draw = param.Draw;
            Parameter_Consumption.recordsTotal = All_Consuption_Count;
            Parameter_Consumption.recordsFiltered = Search_Consuption_Count;
            Parameter_Consumption.data = Consuption_List;
            return Json(Parameter_Consumption.GetObject(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得优惠卷列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Get_Coupon_List(UserDataTableRequest param)
        {
            var CouponUserRelation_List = Cache_CouponUserRelation.Instance.SelectByPage(param.UserId, param.SearchKey, param.OrderBy, param.Start, param.Length, param.OrderDir);
            DataTableResponse<CouponUserRelation> Parameter_CouponUserRelation = new DataTableResponse<CouponUserRelation>();
            var All_CouponUserRelation_Count = Cache_CouponUserRelation.Instance.SelectSearchCount(param.UserId, null, param.OrderBy, param.OrderDir);
            var Search_CouponUserRelation_Count = Cache_CouponUserRelation.Instance.SelectSearchCount(param.UserId, param.SearchKey, param.OrderBy, param.OrderDir);
            Parameter_CouponUserRelation.draw = param.Draw;
            Parameter_CouponUserRelation.recordsTotal = All_CouponUserRelation_Count;
            Parameter_CouponUserRelation.recordsFiltered = Search_CouponUserRelation_Count;
            Parameter_CouponUserRelation.data = CouponUserRelation_List;
            return Json(Parameter_CouponUserRelation.GetObject(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MvcAjaxModelValidate]
        [MvcAjaxException]
        public JsonResult Modify_User(UserReqest request)
        {
            TUser UserInfo = new TUser();
            UserInfo.UserId = request.UserId;
            UserInfo.UserImage = request.UserImage;
            UserInfo.UserName = request.UserName;
            UserInfo.UserNickName = request.UserNickName;
            UserInfo.UserPhone = request.UserPhone;
            UserInfo.UserEmail = request.UserEmail;
            UserInfo.ConsumptionTime = request.ConsumptionTime;
            var UpdateFlag = Cache_TUser.Instance.UpdateUserInfo(UserInfo);
            ResultJsonModel<TUser> result = new ResultJsonModel<TUser>();
            if (!UpdateFlag)
            {
                result.HttpCode = 300;
                result.Message = Enum_Message.DataNotSuccessMessage.Enum_GetString();
            }
            else
            {
                result.HttpCode = 200;
                result.Message = Enum_Message.DataInsertSuccessMessage.Enum_GetString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}