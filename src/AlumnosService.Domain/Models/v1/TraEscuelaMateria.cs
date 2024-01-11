using System;
using System.Collections.Generic;

namespace AlumnosService.Domain.Models.v1;

public partial class TraEscuelaMateria
{
    public int Id { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string? DescripcionMateria { get; set; }

    public int CalificacionMinima { get; set; }

    public virtual ICollection<TraEscuelaAlumno> TraEscuelaAlumnos { get; set; } = new List<TraEscuelaAlumno>();
}
