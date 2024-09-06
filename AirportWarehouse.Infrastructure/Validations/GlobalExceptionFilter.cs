using AirportWarehouse.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
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
                var validation = GenerateError((int)HttpStatusCode.BadRequest, "Bad Request");
                HandleException(context, validation);
            }
            else if (context.Exception.GetType() == typeof(CredentialsException))
            {
                var exception = (CredentialsException)context.Exception;
                var error = GenerateError(460, "Credential error");
                HandleException(context, error);
            }
            else if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                var error = GenerateError((int)HttpStatusCode.NotFound, "The resource was not found");
                HandleException(context, error);
            }
        }


        public void HandleException(ExceptionContext context, object error)
        {
            var statusObject = error.GetType().GetProperty("Status")?.GetValue(error, null);
            int status = Convert.ToInt32(statusObject);
            context.Result = new BadRequestObjectResult(error);
            context.HttpContext.Response.StatusCode = status;
            context.ExceptionHandled = true;
        }

        private object GenerateError(int status, string tittle)
        {
            return new
            {
                Status = status,
                Tittle = tittle,
            };
        }
    }
}
