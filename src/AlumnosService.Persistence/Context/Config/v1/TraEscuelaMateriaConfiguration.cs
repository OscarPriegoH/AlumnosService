using AlumnosService.Domain.Models.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosService.Persistence.Context.Config.v1
{
    public class TraEscuelaMateriaConfiguration : IEntityTypeConfiguration<TraEscuelaMateria>
    {
        public void Configure(EntityTypeBuilder<TraEscuelaMateria> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Tra_Escu__3214EC0707851E06");

            builder.ToTable("Tra_Escuela_Materias", "dbo");

            builder.HasIndex(e => e.NombreMateria, "UQ_NombreMateria").IsUnique();

            builder.Property(e => e.DescripcionMateria)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
