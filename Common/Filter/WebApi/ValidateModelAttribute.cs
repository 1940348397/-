using Common.Result;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Common.Enum_My;

namespace Common.Filter
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                ResultJson resultJson = new ResultJson();
                resultJson.HttpCode = 400;
                JObject json = new JObject();
                string ErrorMsg = "";
                bool flagFirst = true;
                bool flagToken = true;
                foreach (var item in actionContext.ModelState.Values)
                {
                    if (item.Errors.Count != 0)
                    {
                        if (item.Errors[0].ErrorMessage.Trim() == Enum_Message.TokenInvalidMessage.Enum_GetString())
                        {
                            resultJson.HttpCode = 700;
                            resultJson.Message = item.Errors[0].ErrorMessage;
                            flagToken = false;
                            break;
                        }
                        if (flagFirst)
                        {
                            flagFirst = false;
                        }
                        else
                        {
                            ErrorMsg += ",";
                        }
                        ErrorMsg += item.Errors[0].ErrorMessage;
                    }
                }
                if (flagToken)
                {
                    resultJson.Message = ErrorMsg;
                }
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, resultJson);
            }
        }
    }
}
