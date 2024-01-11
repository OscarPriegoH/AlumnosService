//using Exodus.Core.Application.DTOs.VYM;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Net;
//using System.Text.Json;
//using System.Threading.Tasks;


//namespace GarantiaService.API.Exceptions.v1
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public ExceptionMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext httpContext)
//        {
//            try
//            {
//                await _next(httpContext);
//            }
//            catch (Exception ex)
//            {
//                await HandleExceptionAsync(httpContext, ex);
//            }
//        }

//        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

//            var validation = new ResponseDto<string>
//            {
//                HuboError = true,
//                StatusCode = 400,
//                Data = null,
//                Error = new ErrorDto { Mensaje = exception.Message }
//            };

//            var json = JsonSerializer.Serialize(validation);
//            await context.Response.WriteAsync(json);
//        }
//    }

//    public static class ExceptionMiddlewareExtension
//    {
//        public static void UseExceptionMiddleware(this IApplicationBuilder app)
//        {
//            app.UseMiddleware<ExceptionMiddleware>();
//        }
//    }
//}
