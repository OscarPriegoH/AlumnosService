using AlumnosService.Domain.Models.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlumnosService.Persistence.Context.Config.v1
{
    public class TraEscuelaAlumnoConfiguration : IEntityTypeConfiguration<TraEscuelaAlumno>
    {
        public void Configure(EntityTypeBuilder<TraEscuelaAlumno> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Tra_Escu__3214EC0736A3D3D5");

            builder.ToTable("Tra_Escuela_Alumnos", "dbo");

            builder.Property(e => e.ApellidoMaterno)
                .HasMaxLength(70)
                .IsUnicode(false);
            builder.Property(e => e.ApellidoPaterno)
                .HasMaxLength(70)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.TraEscuelaAlumnos)
                .HasForeignKey(d => d.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumnos_Materias");
        }
    }
}
