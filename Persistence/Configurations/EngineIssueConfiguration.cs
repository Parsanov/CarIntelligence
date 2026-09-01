using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EngineIssueConfiguration : IEntityTypeConfiguration<EngineIssues>
    {
        public void Configure(EntityTypeBuilder<EngineIssues> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).HasMaxLength(120).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.SourceUrl).HasMaxLength(500);
            builder.Property(i => i.Verified).HasDefaultValue(false);
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("now()");

            // У звіт іде тільки вичитане — фільтр по Verified є в кожному запиті
            builder.HasIndex(i => new { i.EngineId, i.Verified });

            builder.HasOne(i => i.Engine)
                   .WithMany(e => e.EngineIssues)
                   .HasForeignKey(i => i.EngineId)
                   .OnDelete(DeleteBehavior.Restrict); // болячки писались руками, каскад їх не зносить

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("ck_engine_issues_severity", "\"Severity\" BETWEEN 1 AND 5");
                t.HasCheckConstraint("ck_engine_issues_years",
                    "\"AppliesYearTo\" IS NULL OR \"AppliesYearFrom\" IS NULL OR \"AppliesYearTo\" >= \"AppliesYearFrom\"");
            });
        }
    }
}
