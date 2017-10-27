using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliyunHelper.SendMail.SendEmailModel;
using AliyunHelper.SendMail;

namespace AliyunHelper.SendMail
{
    public class SendMail : SingleTon<SendMail>
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="PhoneNumbers">电话号码</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public SendSmsResponse SendEmail(string PhoneNumbers, string code, Enum_SendEmailCode sendEmail)
        {
            String product = "Dysmsapi";//短信API产品名称
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
            String accessKeyId = AliyunVariable.AliyunAccessKeyId;//你的accessKeyId
            String accessKeySecret = AliyunVariable.AliyunAccessKeySecret;//你的accessKeySecret
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = PhoneNumbers;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = AliyunVariable.AliyunSignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = sendEmail.Enum_GetString();
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = new SendEmailModel.UserRegistrationVerification(code, "Health_App").GetString();
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "21212121211";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                return sendSmsResponse;
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="PhoneNumbers">电话号码</param>
        /// <param name="code">验证码</param>
        public SendSmsResponse SendResetEmail(string PhoneNumbers, string code)
        {
            String product = "Dysmsapi";//短信API产品名称
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
            String accessKeyId = AliyunVariable.AliyunAccessKeyId;//你的accessKeyId
            String accessKeySecret = AliyunVariable.AliyunAccessKeySecret;//你的accessKeySecret
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = PhoneNumbers;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = AliyunVariable.AliyunSignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = Enum_SendEmailCode.UserRegistrationVerificationCode.Enum_GetString();
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = new ModifyPasswordAuthentication(code).GetString();
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "21212121211";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                return sendSmsResponse;
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
        }
    }
}
