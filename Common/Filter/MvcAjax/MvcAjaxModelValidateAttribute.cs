using Common.Result;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using Common.Enum_My;
using System.Web.Mvc;
using Common.Helper;
using Common.Extend;
using Common.Helper.JsonHelper;
using System.Linq;

namespace Common.Filter.MvcAjax
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class MvcAjaxModelValidateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Model验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var Controller = actionContext.Controller;
            ModelStateDictionary ModelState = (ModelStateDictionary)ReflexHelper.Instance.GetPropertyValue(Controller, "ModelState");
            bool? IsValid = null;
            if (ModelState != null)
            {
                IsValid = ModelState.IsValid;
            }
            if (IsValid == false)
            {
                ResultJson result = new ResultJson();
                result.HttpCode = 300;
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        if (!error.ErrorMessage.IsNullOrEmpty())
                        {
                            result.Message += error.ErrorMessage + ",";
                        }
                    }
                }
                if (result.Message != null)
                {
                    result.Message = result.Message.Remove(result.Message.Count() - 1, 1);
                }
                var JsonString = JsonHelper.Instance.SerializeObject(result);
                
                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = result;
                jsonResult.ContentType = "application/json";
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                actionContext.Result = jsonResult;
            }
        }
    }
}
