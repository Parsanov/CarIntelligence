using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Models>
    {
        public void Configure(EntityTypeBuilder<Models> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(80).IsRequired();

            // Focus може бути один у Ford, але Astra є і в Opel, і у Vauxhall
            builder.HasIndex(m => new { m.MakeId, m.Name }).IsUnique();

            builder.HasOne(m => m.Make)
                   .WithMany(mk => mk.Models)
                   .HasForeignKey(m => m.MakeId)
                   .OnDelete(DeleteBehavior.Restrict); // довідник не каскадимо
        }
    }
}
