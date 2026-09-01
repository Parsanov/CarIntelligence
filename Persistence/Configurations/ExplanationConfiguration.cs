using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ExplanationConfiguration : IEntityTypeConfiguration<Explanations>
    {
        public void Configure(EntityTypeBuilder<Explanations> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PriceBand).HasMaxLength(20).IsRequired();
            builder.Property(e => e.ScoreBand).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Body).IsRequired();
            builder.Property(e => e.ModelVersion).HasMaxLength(40);
            builder.Property(e => e.GeneratedAt).HasDefaultValueSql("now()");

            // Ключ кешу — не генеруємо той самий текст двічі
            builder.HasIndex(e => new { e.PowertrainId, e.PriceBand, e.ScoreBand }).IsUnique();

            builder.HasOne(e => e.Powertrain)
                   .WithMany(p => p.Explanations)
                   .HasForeignKey(e => e.PowertrainId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("ck_explanations_price_band",
                    "\"PriceBand\" IN ('below','market','above')");
                t.HasCheckConstraint("ck_explanations_score_band",
                    "\"ScoreBand\" IN ('low','mid','high')");
            });
        }
    }
}
