using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BitCoinWatcher.Attributes.ModelStateFilter;

namespace BitCoinWatcher.Attributes
{
    public class ModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK, new ResourceValidationErrorWrapper(actionContext.ModelState));
            }
        }
    }
}