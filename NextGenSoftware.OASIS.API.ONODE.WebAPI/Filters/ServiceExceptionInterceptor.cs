using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NextGenSoftware.OASIS.API.Core.Exception;
using NextGenSoftware.OASIS.API.Core.Helpers;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Filters
{
    public class ServiceExceptionInterceptor: ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exceptionResponse = new OASISResult<object>();
            switch (context.Exception)
            {
                case ProviderMethodNotSupportedException methodNotSupported:
                    exceptionResponse.Message = methodNotSupported.Message;
                    exceptionResponse.IsWarning = true;
                    exceptionResponse.IsError = false;
                    break;
                default:
                    exceptionResponse.Message = context.Exception.Message;
                    exceptionResponse.IsError = true;
                    break;
            }
            ErrorHandling.HandleError(ref exceptionResponse, context.Exception.Message);
            context.Result = new JsonResult(exceptionResponse);
            context.HttpContext.Response.StatusCode = 500;
            return Task.CompletedTask;
        }
    }
}