using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class GenerationConfiguration : IEntityTypeConfiguration<Generations>
    {
        public void Configure(EntityTypeBuilder<Generations> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(80).IsRequired();

            builder.HasIndex(g => new { g.ModelId, g.Name }).IsUnique();

            builder.HasOne(g => g.Model)
                   .WithMany(m => m.Generations)
                   .HasForeignKey(g => g.ModelId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 1886 — рік першого автомобіля; верхня межа з запасом
            builder.ToTable(t => t.HasCheckConstraint(
                "ck_generations_years",
                "\"YearFrom\" BETWEEN 1886 AND 2100 AND (\"YearTo\" IS NULL OR \"YearTo\" >= \"YearFrom\")"));
        }
    }
}
