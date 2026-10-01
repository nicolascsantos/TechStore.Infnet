using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechStore.Application.Exceptions;

namespace TechStore.API.Filters
{
    public class APIGlobalExceptionHandler : IExceptionFilter
    {
        private const string TITULO_EXCEPTION = "Um ou mais erros ocorreram.";

        private readonly IHostEnvironment _env;

        public APIGlobalExceptionHandler(IHostEnvironment env)
            => _env = env;
       

        public void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            var exception = context.Exception;
            if (_env.IsDevelopment())
                details.Extensions.Add("StackTrace", exception.StackTrace);
            
            if (exception is NotFoundException)
            {
                var ex = exception as NotFoundException;
                details.Title = TITULO_EXCEPTION;
                details.Status = StatusCodes.Status404NotFound;
                details.Detail = ex!.Message;
                details.Type = "NotFound";
            }
            else
            {
                details.Title = TITULO_EXCEPTION;
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = "UnexpectedError";
                details.Detail = exception.Message;
            }
            context.HttpContext.Response.StatusCode = (int)details.Status!;
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
