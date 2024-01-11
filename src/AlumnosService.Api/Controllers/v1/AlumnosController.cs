using AlumnosService.Application.Contracts.Queries.v1;
using AlumnosService.Application.DTOs;
using AlumnosService.Application.Queries.v1;
using Exodus.BaseAPI.Infrastructure.Services;
using Exodus.Core.Application.DTOs.VYM;
using Microsoft.AspNetCore.Mvc;

namespace AlumnosService.API.Controllers.v1
{
    public class AlumnosController : BaseController
    {
        private readonly IAlumnosQueryService _alumnosQueryService;
        public AlumnosController(IAlumnosQueryService alumnosQueryService ) 
        {
            _alumnosQueryService = alumnosQueryService;
        }

        [HttpGet]
        public async Task<ResponseDto<List<InformacionAlumnoDto>>> InformacionAlumnos()
        {
            return await _alumnosQueryService.RecuperarAlumnos();
        }
    }
}
