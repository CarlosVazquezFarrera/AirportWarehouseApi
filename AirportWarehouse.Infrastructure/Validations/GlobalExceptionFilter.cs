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
            if (context.Exception.GetType() == typeof(BussinesException))
            {
                var exception = (BussinesException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Tittle = "Bad Request",
                    Dedetails = exception.Message
                };
                var json = new
                {
                    erros = new[] { validation },
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
             }
        }
    }
}
