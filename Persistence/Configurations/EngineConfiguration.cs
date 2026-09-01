using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasKey(e => e.Id);

            // Код мотора глобально унікальний: DV6 стоїть у Focus, C4, 307, Mazda 3
            builder.Property(e => e.Code).HasMaxLength(30).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.DisplacementL).HasPrecision(3, 1);
            builder.Property(e => e.FuelType).HasMaxLength(20).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_engines_fuel_type",
                "\"FuelType\" IN ('petrol','diesel','lpg','hybrid','electric')"));
        }
    }
}
