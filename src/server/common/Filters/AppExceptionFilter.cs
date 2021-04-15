using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Ncc.China.Common.Exceptions;

namespace Ncc.China.Common.Filters
{
    public class AppExceptionFilter : IActionFilter, IOrderedFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is AppException exception)
            {
                context.ExceptionHandled = true;
                var jsonStr =
                    $"{{\"code\":{exception.Code.ToString()},message:\"{exception.Message}\"}}";
                context.HttpContext.Response.WriteAsync(jsonStr).GetAwaiter().GetResult();
            }
        }

        public int Order { get; } = int.MaxValue - 10;
    }
}
