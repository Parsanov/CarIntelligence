using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class GearBoxConfiguration : IEntityTypeConfiguration<GearBox>
    {
        public void Configure(EntityTypeBuilder<GearBox> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Code).HasMaxLength(30).IsRequired();
            builder.HasIndex(g => g.Code).IsUnique();

            builder.Property(g => g.Kind).HasMaxLength(20).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_gearboxes_kind",
                "\"Kind\" IN ('manual','auto','dct','cvt')"));
        }
    }
}
