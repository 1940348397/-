using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common.Enum_My;
using Common.Extend;
using Common.Filter;
using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Cache;
using DbOpertion.Models;
using DbOpertion.Operation;
using GZRYVillageWeb.Common.Api.Enum;
using GZRYVillageWeb.Request.ApiRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GZRYVillageWeb.Controllers
{
    /// <summary>
    /// 用户Api控制器
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户登入
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [WebApiException]
        public ResultJsonModel<TUser> Login(UserLoginRequest request)
        {
            ResultJsonModel<TUser> result = new ResultJsonModel<TUser>();
            #region 用户密码查询
            if (true)
            {
                string UserName = null, UserPassWord = null;
                var userModel = Cache_TUser.Instance.MemberUserLogin(UserName, UserPassWord);
                if (userModel == null)
                {
                    result.HttpCode = 301;
                    result.Message = Enum_Message.UserNameOrPasswordNotRightMessage.Enum_GetString();
                }
                else
                {
                    result.HttpCode = 200;
                    result.Message = Enum_Message.LoginSuccessMessage.Enum_GetString();
                    result.Model1 = userModel;
                }
            }
            #endregion
            #region 微信查询
            else if (true)
            {

            }
            #endregion
            #region 用户密码查询
            else if (true)
            {

            }
            #endregion
            return result;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [WebApiException]
        public ResultJson SendEmail(SendEmailRequest request)
        {
            ResultJson result = new ResultJson();
            if (Cache_TUser.Instance.GetUserResetCode(request.Phone))
            {
                string verification = Cache_TUser.Instance.SetMemberCode(request.Phone);
                Enum_SendEmailCode SendEmail;
                if (request.SendEmailType.IsNullOrEmpty() || request.SendEmailType.ToLower() == Enum_SearchType.Registration.Enum_GetString())
                {
                    SendEmail = Enum_SendEmailCode.UserRegistrationVerificationCode;
                }
                else if (request.SendEmailType.ToLower() == Enum_SearchType.ResetPassword.Enum_GetString())
                {
                    SendEmail = Enum_SendEmailCode.MessageChangeVerificationCode;
                }
                else if (request.SendEmailType.ToLower() == Enum_SearchType.ChangePhone.Enum_GetString())
                {
                    SendEmail = Enum_SendEmailCode.ModifyPasswordAuthenticationCode;
                }
                else
                {
                    SendEmail = Enum_SendEmailCode.AuthenticationCode;
                }
                SendSmsResponse Email = SendMail.Instance.SendEmail(request.Phone, verification, SendEmail);
                if (Email.Code.ToUpper() == "OK")
                {
                    result.HttpCode = 200;
                    result.Message = "发送信息成功";
                }
                else
                {
                    result.HttpCode = 500;
                    result.Message = Email.Message;
                }
            }
            else
            {
                result.HttpCode = 500;
                result.Message = "请过段时间重新发送";
            }
            return result;
        }

        /// <summary>
        /// 手机注册
        /// </summary>
        [HttpPost]
        [ValidateModel]
        [WebApiException]
        public ResultJsonModel<TUser> MailRegister(MailRegisterRequest request)
        {
            ResultJsonModel<TUser> result = new ResultJsonModel<TUser>();
            TUser MemUser = new TUser();
            MemUser.UserPhone = request.Phone;
            var users = Cache_TUser.Instance.SelectByPhone(request.Phone);
            if (users != null)
            {
                result.HttpCode = 300;
                result.Message = "用户已注册";
            }
            else
            {
                var verification = Cache_TUser.Instance.GetMemberCode(request.Phone);
                if (verification == null)
                {
                    result.HttpCode = 500;
                    result.Message = "请重新发送验证码";
                }
                else
                {
                    if (request.Code == verification)
                    {
                        TUser customer = new TUser();
                        customer.UserPhone = request.Phone;
                        customer.UserPassword = request.PassWord;
                        if (TUserOper.Instance.Insert(customer))
                        {
                            Cache_TUser.Instance.ClearMemberCode(request.Phone);
                            var user = Cache_TUser.Instance.SelectByPhone(request.Phone);
                            result.HttpCode = 200;
                            result.Message = "注册成功";
                            result.Model1 = user;
                        }
                        else
                        {
                            result.HttpCode = 300;
                            result.Message = "注册失败";
                        }
                    }
                    else
                    {
                        result.HttpCode = 400;
                        result.Message = "验证码错误";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 忘记密码
        /// </summary>
        [HttpPost]
        [ValidateModel]
        [WebApiException]
        public ResultJsonModel<TUser> ForgotPassword(MailRegisterRequest request)
        {
            ResultJsonModel<TUser> result = new ResultJsonModel<TUser>();
            TUser MemUser = new TUser();
            MemUser.UserPhone = request.Phone;
            var users = Cache_TUser.Instance.SelectByPhone(request.Phone);
            if (users == null)
            {
                result.HttpCode = 300;
                result.Message = "用户尚未注册";
            }
            else
            {
                var verification = Cache_TUser.Instance.GetMemberCode(request.Phone);
                if (verification == null)
                {
                    result.HttpCode = 500;
                    result.Message = "请重新发送验证码";
                }
                else
                {
                    if (request.Code == verification)
                    {
                        TUser customer = new TUser();
                        customer.UserPhone = request.Phone;
                        customer.UserPassword = request.PassWord;
                        if (TUserOper.Instance.Update(customer))
                        {
                            Cache_TUser.Instance.ClearMemberCode(request.Phone);
                            var user = Cache_TUser.Instance.SelectByPhone(request.Phone);
                            result.HttpCode = 200;
                            result.Message = "密码重置成功";
                            result.Model1 = user;
                        }
                        else
                        {
                            result.HttpCode = 300;
                            result.Message = "密码重置失败";
                        }
                    }
                    else
                    {
                        result.HttpCode = 400;
                        result.Message = "验证码错误";
                    }
                }
            }
            return result;
        }
    }
}