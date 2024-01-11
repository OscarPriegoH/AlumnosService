using AlumnosService.Application.Contracts.Persistence.v1;
using AlumnosService.Domain.Models.v1;
using AlumnosService.Persistence.Context.v1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosService.Persistence.Repositories.v1
{
    public class MateriasRepository : IMateriasRepository
    {
        private readonly DeusContext _contex;

        public MateriasRepository(DeusContext context)
        {
            _contex = context;
        }

        public async Task<List<TraEscuelaMateria>> RecuperarMaterias()
        {
            return await _contex.TraEscuelaMaterias.ToListAsync();
        }
    }
}
