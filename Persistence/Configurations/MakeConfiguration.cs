using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MakeConfiguration : IEntityTypeConfiguration<Makes>
    {
        public void Configure(EntityTypeBuilder<Makes> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(m => m.Name).IsUnique();
        }
    }
}
