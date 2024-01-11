using System;
using System.Collections.Generic;
using AlumnosService.Domain.Models.v1;
using AlumnosService.Persistence.Context.Config.v1;
using Microsoft.EntityFrameworkCore;

namespace AlumnosService.Persistence.Context.v1;

public partial class DeusContext : DbContext
{
    public DeusContext()
    {
    }

    public DeusContext(DbContextOptions<DeusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TraEscuelaAlumno> TraEscuelaAlumnos { get; set; }

    public virtual DbSet<TraEscuelaMateria> TraEscuelaMaterias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TraEscuelaAlumnoConfiguration());
        modelBuilder.ApplyConfiguration(new TraEscuelaMateriaConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
