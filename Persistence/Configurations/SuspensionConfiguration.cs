using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SuspensionConfiguration : IEntityTypeConfiguration<Suspensions>
    {
        public void Configure(EntityTypeBuilder<Suspensions> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).HasMaxLength(30).IsRequired();
            builder.HasIndex(s => s.Code).IsUnique();

            builder.Property(s => s.Kind).HasMaxLength(20).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_suspensions_kind",
                "\"Kind\" IN ('spring','air','adaptive')"));
        }
    }
}
