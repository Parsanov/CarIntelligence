namespace Core.Model
{
    /// <summary>Не світить, не гріє, гниє. Кузов, корозія, салон, клімат, проводка.</summary>
    public class BodyIssues
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public short Severity { get; set; }

        /// <summary>Пороги, арки, лонжерони, дах.</summary>
        public string? Zone { get; set; }

        /// <summary>Корозія залежить від віку, а не від пробігу.</summary>
        public short? AppearsAfterYears { get; set; }

        public string? HowToCheck { get; set; }
        public int? RepairCostUahFrom { get; set; }
        public int? RepairCostUahTo { get; set; }
        public string? SourceUrl { get; set; }
        public bool Verified { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Guid GenerationId { get; set; }
        public Generations Generation { get; set; } = null!;
    }
}
