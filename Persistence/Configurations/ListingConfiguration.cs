using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listings>
    {
        public void Configure(EntityTypeBuilder<Listings> builder)
        {
            builder.HasKey(l => l.Id);

            // Природний ключ для upsert — без нього будуть дублі оголошень
            builder.HasIndex(l => l.AutoriaId).IsUnique();

            builder.Property(l => l.Url).HasMaxLength(500).IsRequired();
            builder.Property(l => l.Vin).HasMaxLength(17);
            builder.Property(l => l.PriceUSD).HasPrecision(10, 2);
            builder.Property(l => l.RawPayload).HasColumnType("jsonb").IsRequired();

            // Пошук за VIN потрібен лише там, де VIN є
            builder.HasIndex(l => l.Vin).HasFilter("\"Vin\" IS NOT NULL");

            builder.HasOne(l => l.Powertrain)
                   .WithMany(p => p.Listings)
                   .HasForeignKey(l => l.PowertrainId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_listings_vin_len", "\"Vin\" IS NULL OR length(\"Vin\") = 17"));
        }
    }
}
