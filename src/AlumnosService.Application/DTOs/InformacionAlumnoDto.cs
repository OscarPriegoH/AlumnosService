using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosService.Application.DTOs
{
    public class InformacionAlumnoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }  
        public int Calificacion { get; set; }
        public string Materia { get; set; }
    }
}
