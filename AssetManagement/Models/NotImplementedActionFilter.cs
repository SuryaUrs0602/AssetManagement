using System.Net.Http;
using System.Net;
using System.Web.Http.Filters;

namespace AssetManagement.Models
{
    public class NotImplementedActionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}
