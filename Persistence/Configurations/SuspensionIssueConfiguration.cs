using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SuspensionIssueConfiguration : IEntityTypeConfiguration<SuspensionsIssues>
    {
        public void Configure(EntityTypeBuilder<SuspensionsIssues> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).HasMaxLength(120).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.SourceUrl).HasMaxLength(500);
            builder.Property(i => i.Verified).HasDefaultValue(false);
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("now()");

            builder.HasIndex(i => new { i.SuspensionId, i.Verified });

            builder.HasOne(i => i.Suspension)
                   .WithMany(s => s.SuspensionsIssues)
                   .HasForeignKey(i => i.SuspensionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => t.HasCheckConstraint(
                "ck_suspension_issues_severity", "\"Severity\" BETWEEN 1 AND 5"));
        }
    }
}
