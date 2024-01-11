using Exodus.Core.Application.DTOs.VYM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//using SuscripcionService.Comun.Excepciones.DTOs;
using System;
using System.Net;

namespace AlumnosService.API.Filters.v1
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            var validation = new ResponseDto<string>
            {
                HuboError = true,
                StatusCode = 400,
                Data = null,
                Error = new ErrorDto { Mensaje = exception.Message }
            };

            var json = new[] { validation };
            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
