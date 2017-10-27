using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunHelper.SendMail.SendEmailModel
{
    /// <summary>
    /// 身份验证验证码
    /// </summary>
    public class Authentication
    {
        public Authentication(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        public string GetString()
        {
            return "{\"code\":\"" + Code + "\"}";
        }
    }
    /// <summary>
    /// 短信测试
    /// </summary>
    public class SMSTest
    {
        public SMSTest(string Customer)
        {
            customer = Customer;
        }
        /// <summary>
        /// 用户
        /// </summary>
        public string customer { get; set; }
        public string GetString()
        {
            return "{\"customer\":\"" + customer + "\"}";
        }
    }
    /// <summary>
    /// 登录确认验证码
    /// </summary>
    public class LoginConfirmation
    {
        public LoginConfirmation(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        public string GetString()
        {
            return "{\"Code\":\"" + Code + "\"}";
        }
    }
    /// <summary>
    /// 登录异常验证码
    /// </summary>
    public class LoginExceptionAuthentication
    {
        public LoginExceptionAuthentication(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        public string GetString()
        {
            return "{\"Code\":\"" + Code + "\"}";
        }
    }
    /// <summary>
    /// 用户注册验证码
    /// </summary>
    public class UserRegistrationVerification
    {
        public UserRegistrationVerification(string code, string product)
        {
            Code = code;
            Product = product;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public string Product { get; set; }
        public string GetString()
        {
            return "{\"code\":\"" + Code + "\",\"product\":\"" + 123 + "\"}";
        }
    }
    /// <summary>
    /// 修改密码验证码
    /// </summary>
    public class ModifyPasswordAuthentication
    {
        public ModifyPasswordAuthentication(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        public string GetString()
        {
            return "{\"Code\":\"" + Code + "\"}";
        }
    }
    /// <summary>
    /// 信息变更验证码
    /// </summary>
    public class MessageChangeVerification
    {
        public MessageChangeVerification(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        public string GetString()
        {
            return "{\"Code\":\"" + Code + "\"}";
        }
    }
    /// <summary>
    /// 健康饮食app用户注册
    /// </summary>
    public class HealthyEatingAppUserRegistration
    {
        public HealthyEatingAppUserRegistration(string code)
        {
            Code = code;
        }
        /// <summary>
        /// 验证码
        /// </summary>

        public string Code { get; set; }
        public string GetString()
        {
            return "{\"Code\":\"" + Code + "\"}";
        }
    }
}
