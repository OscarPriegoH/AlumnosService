using AlumnosService.Application.Contracts.Persistence.v1;
using AlumnosService.Domain.Models.v1;
using AlumnosService.Persistence.Context.v1;
using Microsoft.EntityFrameworkCore;

namespace AlumnosService.Persistence.Repositories.v1
{
    public class AlumnosRepository : IAlumnosRepository
    {
        private readonly DeusContext _context;
        public AlumnosRepository(DeusContext context)
        {
            _context = context;
        }

        public async Task<List<TraEscuelaAlumno>> RecuperarAlumnos()
        {
            return await _context.TraEscuelaAlumnos.ToListAsync();
        }
    }
}
