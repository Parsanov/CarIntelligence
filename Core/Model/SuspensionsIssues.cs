namespace Core.Model
{
    /// <summary>Стукає, не тримає дорогу, не гальмує. Підвіска, гальма, рульове.</summary>
    public class SuspensionsIssues
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public short Severity { get; set; }
        public int? TypicalMileageKm { get; set; }
        public string? HowToCheck { get; set; }
        public string? SourceUrl { get; set; }
        public bool Verified { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Guid SuspensionId { get; set; }
        public Suspensions Suspension { get; set; } = null!;
    }
}
