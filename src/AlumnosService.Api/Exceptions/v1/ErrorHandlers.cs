using Exodus.Core.Application.DTOs.VYM;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace AlumnosService.API.Exceptions.v1
{
    public static class ErrorHandlers
    {
        public static async Task<ResponseDto<string>> ErroresModelState(ModelStateDictionary modelState)
        {
            ResponseDto<string> response = new ResponseDto<string>();
            response.StatusCode = 400;
            response.HuboError = true;
            response.Error.Mensaje = "Uno o más errores de validaciones ocurrieron";

            foreach (var key in modelState.Keys)
            {
                var valores = modelState[key];
                response.Error.ErroresValidaciones.Add(new ErrorValidacionesDto { Campo = key, Errores = valores.Errors.Select(y => y.ErrorMessage).ToList() });
            }

            return response;
        }
    }
}
