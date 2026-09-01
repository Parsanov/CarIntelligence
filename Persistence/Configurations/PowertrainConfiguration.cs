using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PowertrainConfiguration : IEntityTypeConfiguration<Powertrains>
    {
        public void Configure(EntityTypeBuilder<Powertrains> builder)
        {
            builder.HasKey(p => p.Id);

            // Заводська комбінація унікальна — захист від дублів у довіднику
            builder.HasIndex(p => new { p.GenerationId, p.EngineId, p.GearBoxId, p.SuspensionId })
                   .IsUnique();

            builder.Property(p => p.Drive).HasMaxLength(10);

            builder.HasOne(p => p.Generation)
                   .WithMany(g => g.Powertrains)
                   .HasForeignKey(p => p.GenerationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Engine)
                   .WithMany(e => e.Powertrains)
                   .HasForeignKey(p => p.EngineId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GearBox)
                   .WithMany(g => g.Powertrains)
                   .HasForeignKey(p => p.GearBoxId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SuspensionId nullable — у більшості авто варіантів підвіски немає
            builder.HasOne(p => p.Suspension)
                   .WithMany(s => s.Powertrains)
                   .HasForeignKey(p => p.SuspensionId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_powertrains_drive",
                "\"Drive\" IS NULL OR \"Drive\" IN ('fwd','rwd','awd')"));
        }
    }
}
