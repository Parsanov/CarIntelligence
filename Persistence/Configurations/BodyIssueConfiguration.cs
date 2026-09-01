using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BodyIssueConfiguration : IEntityTypeConfiguration<BodyIssues>
    {
        public void Configure(EntityTypeBuilder<BodyIssues> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).HasMaxLength(120).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Zone).HasMaxLength(60);
            builder.Property(i => i.SourceUrl).HasMaxLength(500);
            builder.Property(i => i.Verified).HasDefaultValue(false);
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("now()");

            builder.HasIndex(i => new { i.GenerationId, i.Verified });

            builder.HasOne(i => i.Generation)
                   .WithMany(g => g.BodyIssues)
                   .HasForeignKey(i => i.GenerationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_body_issues_severity", "\"Severity\" BETWEEN 1 AND 5"));
        }
    }
}
