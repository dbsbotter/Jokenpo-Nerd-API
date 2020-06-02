using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jokenpo.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new ObjectResult(new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Type = $"https://httpstatuses.com/{(int)HttpStatusCode.BadRequest}",
                Title = "Error",
                Detail = "Ocorreu um erro",
                Instance = context.HttpContext.Request.Path
            });

            context.ExceptionHandled = true;
        }
    }
}