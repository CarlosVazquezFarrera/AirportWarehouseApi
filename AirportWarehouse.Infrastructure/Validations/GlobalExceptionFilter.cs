using AirportWarehouse.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Tittle = "Bad Request",
                    Dedetails = exception.Message
                };
                HandleException(context, validation, (int)HttpStatusCode.BadRequest);
            }
            if (context.Exception.GetType() == typeof(CredentialsException))
            {
                var exception = (CredentialsException)context.Exception;
                var error = new
                {
                    Status = 460,
                    Tittle = "Credential error",
                    Dedetails = exception.Message
                };
                HandleException(context, error, 460);
            }
        }


        public void HandleException(ExceptionContext context, object error, int statusCode)
        {
    
            context.Result = new BadRequestObjectResult(error);
            context.HttpContext.Response.StatusCode = statusCode;
            context.ExceptionHandled = true;
        }
    }
}
