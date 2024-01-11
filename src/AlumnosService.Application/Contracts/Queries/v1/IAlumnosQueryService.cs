using AlumnosService.Application.DTOs;
using Exodus.Core.Application.DTOs.VYM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosService.Application.Contracts.Queries.v1
{
    public interface IAlumnosQueryService
    {
        public Task<ResponseDto<List<InformacionAlumnoDto>>> RecuperarAlumnos();
    }
}
