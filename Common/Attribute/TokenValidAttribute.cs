using Common.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Health.BLL.Attribute
{
    class TokenValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //if (value != null)
            //{
            //    Token token = CacheForModelUser.Instance.GetUserToken(request.Token);
            //    if (token != null)
            //    {
            //        var usermodel = CacheForModelUser.Instance.GetUserInfo(token.Payload.UserID.ParseInt() == null ? 0 : token.Payload.UserID.ParseInt().Value);

            //        if (usermodel == null)
            //        {
            //            result.HttpCode = 300;
            //            result.Message = "Token失效";
            //        }
            //        else
            //        {
            //            result.HttpCode = 200;
            //            result.Message = "登入成功";
            //            result.ListData = new List<GetUserInfoResponse>();
            //            GetUserInfoResponse user_model = new GetUserInfoResponse(usermodel);
            //            result.ListData.Add(user_model);
            //        }
            //    }
            //    else
            //    {
            //        result.HttpCode = 300;
            //        result.Message = "Token失效";
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            //return true;
            return true;
        }
    }
}
