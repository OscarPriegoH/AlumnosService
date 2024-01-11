using AlumnosService.Application.Contracts.Persistence.v1;
using AlumnosService.Application.Contracts.Queries.v1;
using AlumnosService.Application.DTOs;
using Exodus.Core.Application.DTOs.VYM;
using Microsoft.Extensions.Logging;

namespace AlumnosService.Application.Queries.v1
{
    public class AlumnosQueryService : IAlumnosQueryService
    {
        private readonly ILogger<AlumnosQueryService> _logger;
        private readonly IAlumnosRepository _alumnosRepository;
        private readonly IMateriasRepository _materiasRepository;

        public AlumnosQueryService(ILogger<AlumnosQueryService> _logger, IAlumnosRepository alumnosRepository,
            IMateriasRepository materiasRepository)
        {
            this._logger = _logger;
            _alumnosRepository = alumnosRepository;
            _materiasRepository = materiasRepository;
        }

        public async Task<ResponseDto<List<InformacionAlumnoDto>>> RecuperarAlumnos()
        {
            _logger.LogInformation("Inicia proceso de recuperado de alumnos.");
            var response = new ResponseDto<List<InformacionAlumnoDto>>()
            {
                Data = null,
                HuboError = true,
                StatusCode = 404
            };

            var alumnosBD =  await _alumnosRepository.RecuperarAlumnos();
            var materiasBD =  await _materiasRepository.RecuperarMaterias();

            if(alumnosBD == null || alumnosBD.Count == 0) 
            {
                response.Error.Mensaje = "No se encontraron alumnos";
                _logger.LogInformation("No se encontraron alumnos");
                return response;
            }

            var alumnos = alumnosBD.Select(alumno => new InformacionAlumnoDto
            {
                Nombre = alumno.Nombre,
                ApellidoPaterno = alumno.ApellidoPaterno,
                ApellidoMaterno = alumno.ApellidoMaterno,
                Calificacion = alumno.Calificacion,
                Id = alumno.Id,
                Materia = materiasBD != null ? materiasBD.Where(materia => materia.Id == alumno.IdMateria).Select(materia => materia.NombreMateria).FirstOrDefault() : string.Empty
            }).ToList();

            response.HuboError = false;
            response.StatusCode = 200;
            response.Data = alumnos;
            _logger.LogInformation($"Se recuperaron {alumnos.Count} elementos.");
            _logger.LogInformation("Finaliza proceso de recuperado de alumnos.");
            return response;
        }
    }
}
