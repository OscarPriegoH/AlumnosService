using System;
using System.Collections.Generic;

namespace AlumnosService.Domain.Models.v1;

public partial class TraEscuelaAlumno
{
    public int Id { get; set; }

    public int IdMateria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int Calificacion { get; set; }

    public virtual TraEscuelaMateria IdMateriaNavigation { get; set; } = null!;
}
