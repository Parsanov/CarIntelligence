using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AnalysisConfiguration : IEntityTypeConfiguration<Analyses>
    {
        public void Configure(EntityTypeBuilder<Analyses> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Components).HasColumnType("jsonb").IsRequired();
            builder.Property(a => a.MarketMedianUsd).HasPrecision(10, 2);
            builder.Property(a => a.MatchSource).HasMaxLength(20).IsRequired();
            builder.Property(a => a.ComputedAt).HasDefaultValueSql("now()");

            // Один актуальний розбір на оголошення
            builder.HasOne(a => a.Listing)
                   .WithOne(l => l.Analysis)
                   .HasForeignKey<Analyses>(a => a.ListingId)
                   .OnDelete(DeleteBehavior.Cascade); // зникло оголошення — розбір ні до чого

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("ck_analyses_score", "\"Score\" BETWEEN 0 AND 100");
                t.HasCheckConstraint("ck_analyses_match_source",
                    "\"MatchSource\" IN ('vin','params','none')");
            });
        }
    }
}
