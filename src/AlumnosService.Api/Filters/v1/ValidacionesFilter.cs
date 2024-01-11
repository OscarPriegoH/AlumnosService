using AlumnosService.API.Exceptions.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;

namespace AlumnosService.API.Filters.v1
{
    public class ValidacionesFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.ModelState.Count > 0)
                {
                    context.Result = new BadRequestObjectResult(await ErrorHandlers.ErroresModelState(context.ModelState));
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return;
                }
            }

            await next();
        }
    }
}
