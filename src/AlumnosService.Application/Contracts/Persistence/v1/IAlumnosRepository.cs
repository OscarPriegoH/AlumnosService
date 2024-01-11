using AlumnosService.Domain.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosService.Application.Contracts.Persistence.v1
{
    public interface IAlumnosRepository
    {
        /// <summary>
        /// Recupera listado de entidades de alumnos.
        /// </summary>
        /// <returns></returns>
        public Task<List<TraEscuelaAlumno>> RecuperarAlumnos();
    }
}
