namespace Core.Model
{
    /// <summary>Не перемикається, пинається, буксує. КПП, зчеплення, мехатронік.</summary>
    public class GearboxIssues
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public short Severity { get; set; }
        public int? TypicalMileageKm { get; set; }
        public short? AppliesYearFrom { get; set; }
        public short? AppliesYearTo { get; set; }
        public string? HowToCheck { get; set; }
        public int? RepairCostUahFrom { get; set; }
        public int? RepairCostUahTo { get; set; }
        public string? SourceUrl { get; set; }
        public bool Verified { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Guid GearBoxId { get; set; }
        public GearBox GearBox { get; set; } = null!;
    }
}
